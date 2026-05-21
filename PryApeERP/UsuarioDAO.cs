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
                string sql = @"SELECT u.Id_usuario, u.nombre, u.apellido, u.mail, u.Contraseña,
                              u.activo, u.dni, u.direccion, u.telefono,
                              u.geolocalizacion_lat, u.geolocalizacion_lng,
                              u.Id_localidad, l.nombre AS localidad, p.Nombre AS provincia
                       FROM (usuario u 
                       LEFT JOIN localidad l ON u.Id_localidad = l.Id_localidad)
                       LEFT JOIN provincia p ON l.Id_provincia = p.Id_provincia";
                new OleDbDataAdapter(new OleDbCommand(sql, cx.ObtenerConexion())).Fill(dt);
            }
            return dt;
        }

        public void Insertar(string nombre, string apellido, string mail, string password,
                             bool activo, string dni, string direccion, string telefono,
                             int idLocalidad, double lat, double lng)
        {
            using (var cx = new clsConexion())
            {
                string sql = @"INSERT INTO usuario (nombre, apellido, mail, Contraseña, activo,
                                           dni, direccion, telefono, Id_localidad,
                                           geolocalizacion_lat, geolocalizacion_lng)
                       VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = apellido;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = mail;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = password;
                cmd.Parameters.Add("?", OleDbType.Boolean).Value = activo;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = dni;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = direccion;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = telefono;
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idLocalidad;
                cmd.Parameters.Add("?", OleDbType.Double).Value = lat;
                cmd.Parameters.Add("?", OleDbType.Double).Value = lng;
                cmd.ExecuteNonQuery();
            }
        }

        public int ValidarLogin(string mail, string password)
        {
            using (var cx = new clsConexion())
            {
                string sql = @"SELECT Id_usuario FROM usuario 
                       WHERE mail = ? AND Contraseña = ? AND activo = -1";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", mail);
                cmd.Parameters.AddWithValue("?", password);
                var resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToInt32(resultado) : -1;
            }
        }

        public void Actualizar(int id, string nombre, string apellido, string mail, string password,
                               bool activo, string dni, string direccion, string telefono,
                               int idLocalidad, double lat, double lng)
        {
            using (var cx = new clsConexion())
            {
                string sql = string.IsNullOrWhiteSpace(password)
                    ? @"UPDATE usuario SET nombre=?, apellido=?, mail=?, activo=?, dni=?,
                direccion=?, telefono=?, Id_localidad=?, geolocalizacion_lat=?,
                geolocalizacion_lng=? WHERE Id_usuario=?"
                    : @"UPDATE usuario SET nombre=?, apellido=?, mail=?, Contraseña=?, activo=?, dni=?,
                direccion=?, telefono=?, Id_localidad=?, geolocalizacion_lat=?,
                geolocalizacion_lng=? WHERE Id_usuario=?";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = apellido;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = mail;
                if (!string.IsNullOrWhiteSpace(password))
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = password;
                cmd.Parameters.Add("?", OleDbType.Boolean).Value = activo;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = dni;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = direccion;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = telefono;
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idLocalidad;
                cmd.Parameters.Add("?", OleDbType.Double).Value = lat;
                cmd.Parameters.Add("?", OleDbType.Double).Value = lng;
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
