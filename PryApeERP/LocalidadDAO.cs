using System.Data;
using System.Data.OleDb;

namespace PryApeERP
{
    public class LocalidadDAO
    {
        public DataTable ObtenerPorProvincia(int idProvincia)
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                string sql = "SELECT Id_localidad, nombre FROM localidad WHERE Id_provincia = ? ORDER BY nombre";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idProvincia;
                new OleDbDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }
    }
}