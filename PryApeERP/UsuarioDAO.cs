using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PryApeERP
{
    // Resultado posible de un intento de login. Antes esto era un bool implícito
    // (idUsuario > 0) que no permitía distinguir "credenciales mal" de "usuario
    // deshabilitado". Ahora el DAO devuelve explícitamente cuál fue el motivo.
    public enum ResultadoLogin
    {
        Ok,
        CredencialesInvalidas,
        UsuarioInactivo
    }

    public class UsuarioDAO
    {
        public DataTable ObtenerTodos()
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                // Trae los usuarios base
                string sql = @"SELECT u.Id_usuario, u.nombre, u.apellido, 
                              u.mail, u.Contraseña, u.activo, 
                              u.dni, u.telefono
                       FROM usuario u";
                new OleDbDataAdapter(new OleDbCommand(sql, cx.ObtenerConexion())).Fill(dt);
            }

            // Agrega columnas para el domicilio principal
            dt.Columns.Add("direccion", typeof(string));
            dt.Columns.Add("localidad", typeof(string));
            dt.Columns.Add("provincia", typeof(string));

            // Agrega columna para las redes sociales (nombres concatenados)
            dt.Columns.Add("redes", typeof(string));

            // Por cada usuario, busca su domicilio principal y sus redes sociales
            foreach (DataRow row in dt.Rows)
            {
                int idUsuario = Convert.ToInt32(row["Id_usuario"]);

                DataRow dom = ObtenerDomicilioPrincipal(idUsuario);
                if (dom != null)
                {
                    row["direccion"] = dom["direccion"];
                    row["localidad"] = dom["localidad"];
                    row["provincia"] = dom["provincia"];
                }

                row["redes"] = ObtenerRedesConcatenadas(idUsuario);
            }

            return dt;
        }

        // Método separado para obtener el domicilio principal de un usuario
        public DataRow ObtenerDomicilioPrincipal(int idUsuario)
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                string sql = @"SELECT ud.direccion, l.nombre AS localidad, p.Nombre AS provincia
                       FROM (usuario_domicilio ud
                       LEFT JOIN localidad l ON ud.Id_localidad = l.Id_localidad)
                       LEFT JOIN provincia p ON l.Id_provincia = p.Id_provincia
                       WHERE ud.Id_usuario = ? AND ud.principal = -1";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idUsuario;
                new OleDbDataAdapter(cmd).Fill(dt);
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Devuelve los nombres de las redes sociales del usuario, separados por
        // coma (ej: "Instagram, LinkedIn, Twitter"), para mostrar en la grilla
        // sin tener que traer también las URLs (que suelen ser largas).
        // Access/OleDb no tiene GROUP_CONCAT, así que se arma el string en código.
        public string ObtenerRedesConcatenadas(int idUsuario)
        {
            var nombres = new List<string>();
            using (var cx = new clsConexion())
            {
                string sql = @"SELECT rs.nombre
                       FROM usuario_red ur
                       INNER JOIN redes_sociales rs ON ur.Id_red = rs.Id
                       WHERE ur.Id_usuario = ?
                       ORDER BY rs.nombre";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idUsuario;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        nombres.Add(reader["nombre"].ToString());
                }
            }
            return string.Join(", ", nombres);
        }

        public int Insertar(string nombre, string apellido, string mail, string password,
                    bool activo, string dni, string telefono)
        {
            using (var cx = new clsConexion())
            {
                string sql = @"INSERT INTO usuario 
                       (nombre, apellido, mail, Contraseña, activo, dni, telefono)
                       VALUES (?, ?, ?, ?, ?, ?, ?)";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = apellido;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = mail;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = password;
                cmd.Parameters.Add("?", OleDbType.Integer).Value = activo ? -1 : 0;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = dni;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = telefono;
                cmd.ExecuteNonQuery();

                var cmdId = new OleDbCommand("SELECT @@IDENTITY", cx.ObtenerConexion());
                return Convert.ToInt32(cmdId.ExecuteScalar());
            }
        }

        // FIX: ya no filtramos por "activo" en el WHERE. Si lo hacíamos ahí,
        // un usuario deshabilitado simplemente no devolvía fila y quedaba
        // indistinguible de "mail/contraseña incorrectos". Ahora buscamos por
        // mail+password (que es lo que realmente identifica credenciales
        // válidas) y chequeamos "activo" en código aparte, para poder devolver
        // un resultado diferenciado.
        public ResultadoLogin ValidarLogin(string mail, string password, out int idUsuario, out int idPerfil)
        {
            idUsuario = -1;
            idPerfil = -1;

            using (var cx = new clsConexion())
            {
                string sql = @"SELECT u.Id_usuario, u.activo, r.Id_perfil 
               FROM usuario u
               LEFT JOIN usuario_perfil r ON u.Id_usuario = r.Id_usuario
               WHERE u.mail = ? AND u.Contraseña = ?";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", mail);
                cmd.Parameters.AddWithValue("?", password);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return ResultadoLogin.CredencialesInvalidas;

                    bool activo = Convert.ToBoolean(reader["activo"]);
                    if (!activo)
                        return ResultadoLogin.UsuarioInactivo;

                    idUsuario = Convert.ToInt32(reader["Id_usuario"]);
                    idPerfil = reader["Id_perfil"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id_perfil"]);
                    return ResultadoLogin.Ok;
                }
            }
        }

        public void Actualizar(int id, string nombre, string apellido, string mail,
                        string password, bool activo, string dni, string telefono)
        {
            using (var cx = new clsConexion())
            {
                string sql = string.IsNullOrWhiteSpace(password)
                    ? @"UPDATE usuario SET nombre=?, apellido=?, mail=?, activo=?,
                dni=?, telefono=? WHERE Id_usuario=?"
                    : @"UPDATE usuario SET nombre=?, apellido=?, mail=?, Contraseña=?,
                activo=?, dni=?, telefono=? WHERE Id_usuario=?";

                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = apellido;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = mail;
                if (!string.IsNullOrWhiteSpace(password))
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = password;
                cmd.Parameters.Add("?", OleDbType.Integer).Value = activo ? -1 : 0;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = dni;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = telefono;
                cmd.Parameters.Add("?", OleDbType.Integer).Value = id;
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var cx = new clsConexion())
            {
                string sql = "DELETE FROM usuario WHERE Id_usuario = ?";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}