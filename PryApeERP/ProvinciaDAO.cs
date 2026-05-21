using System.Data;
using System.Data.OleDb;

namespace PryApeERP
{
    public class ProvinciaDAO
    {
        public DataTable ObtenerTodos()
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                string sql = "SELECT Id_provincia, Nombre FROM provincia ORDER BY Nombre";
                new OleDbDataAdapter(new OleDbCommand(sql, cx.ObtenerConexion())).Fill(dt);
            }
            return dt;
        }
    }
}