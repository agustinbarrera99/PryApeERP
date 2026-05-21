using System.Data;
using System.Data.OleDb;

namespace PryApeERP
{
    public class RedSocialDAO
    {
        public DataTable ObtenerTodos()
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                string sql = "SELECT Id, nombre FROM redes_sociales ORDER BY nombre";
                new OleDbDataAdapter(new OleDbCommand(sql, cx.ObtenerConexion())).Fill(dt);
            }
            return dt;
        }

        public DataTable ObtenerPorUsuario(int idUsuario)
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                string sql = @"SELECT ur.Id, ur.Id_red, rs.nombre, ur.url_perfil 
                               FROM usuario_red ur 
                               INNER JOIN redes_sociales rs ON ur.Id_red = rs.Id
                               WHERE ur.Id_usuario = ?";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idUsuario;
                new OleDbDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        public void InsertarUsuarioRed(int idUsuario, int idRed, string urlPerfil)
        {
            using (var cx = new clsConexion())
            {
                string sql = "INSERT INTO usuario_red (Id_usuario, Id_red, url_perfil) VALUES (?, ?, ?)";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idUsuario;
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idRed;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = urlPerfil;
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarPorUsuario(int idUsuario)
        {
            using (var cx = new clsConexion())
            {
                string sql = "DELETE FROM usuario_red WHERE Id_usuario = ?";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idUsuario;
                cmd.ExecuteNonQuery();
            }
        }
    }
}