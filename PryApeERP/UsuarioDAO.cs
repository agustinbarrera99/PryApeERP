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
                string sql = "SELECT Id_usuario, nombre, apellido, mail, Contraseña, activo FROM usuario";
                new OleDbDataAdapter(new OleDbCommand(sql, cx.ObtenerConexion())).Fill(dt);
            }
            return dt;
        }

        public void Insertar(string nombre, string apellido, string mail,
                             string password, bool activo)
        {
            using (var cx = new clsConexion())
            {
                string sql = @"INSERT INTO usuario (nombre, apellido, mail, Contraseña, activo)
                               VALUES (?, ?, ?, ?, ?)";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", nombre);
                cmd.Parameters.AddWithValue("?", apellido);
                cmd.Parameters.AddWithValue("?", mail);
                cmd.Parameters.AddWithValue("?", password);
                cmd.Parameters.AddWithValue("?", activo);
                cmd.ExecuteNonQuery();
            }
        }

        public bool ValidarLogin(string mail, string password)
        {
            using (var cx = new clsConexion())
            {
                string sql = @"SELECT COUNT(*) 
                       FROM usuario 
                       WHERE mail = ? 
                       AND Contraseña = ? 
                       AND activo = true";

                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());

                cmd.Parameters.AddWithValue("?", mail);
                cmd.Parameters.AddWithValue("?", password);

                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                return cantidad > 0;
            }
        }

        public void Actualizar(int id, string nombre, string apellido,
                               string mail, string password, bool activo)
        {
            using (var cx = new clsConexion())
            {
                // Si no escribieron contraseña nueva, no la pisamos
                string sql = string.IsNullOrWhiteSpace(password)
                    ? "UPDATE usuario SET nombre=?, apellido=?, mail=?, activo=? WHERE Id_usuario=?"
                    : "UPDATE usuario SET nombre=?, apellido=?, mail=?, Contraseña=?, activo=? WHERE Id_usuario=?";

                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", nombre);
                cmd.Parameters.AddWithValue("?", apellido);
                cmd.Parameters.AddWithValue("?", mail);

                if (!string.IsNullOrWhiteSpace(password))
                    cmd.Parameters.AddWithValue("?", password);

                cmd.Parameters.AddWithValue("?", activo);
                cmd.Parameters.AddWithValue("?", id);
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
