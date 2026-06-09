using System;
using System.Data;
using System.Data.OleDb;

namespace PryApeERP
{
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

            // Por cada usuario, busca su domicilio principal
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

        public (int idUsuario, int idPerfil) ValidarLogin(string mail, string password)
        {
            using (var cx = new clsConexion())
            {
                string sql = @"SELECT u.Id_usuario, r.Id_perfil 
               FROM usuario u
               LEFT JOIN usuario_perfil r ON u.Id_usuario = r.Id_usuario
               WHERE u.mail = ? AND u.Contraseña = ? AND u.activo = -1";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", mail);
                cmd.Parameters.AddWithValue("?", password);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return (Convert.ToInt32(reader["Id_usuario"]),
                                reader["Id_perfil"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id_perfil"]));
                }
                return (-1, -1);
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
