using System;
using System.Data;
using System.Data.OleDb;

namespace PryApeERP
{
    public class PerfilDAO
    {
        public DataTable ObtenerTodos()
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                string sql = "SELECT Id_perfil, nombre FROM perfil ORDER BY nombre";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                new OleDbDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        public void Insertar(string nombre)
        {
            using (var cx = new clsConexion())
            {
                string sql = "INSERT INTO perfil (nombre) VALUES (?)";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", nombre.Trim());
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(int id, string nombre)
        {
            using (var cx = new clsConexion())
            {
                string sql = "UPDATE perfil SET nombre = ? WHERE Id_perfil = ?";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", nombre.Trim());
                cmd.Parameters.AddWithValue("?", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var cx = new clsConexion())
            {
                string sql = "DELETE FROM perfil WHERE Id_perfil = ?";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}