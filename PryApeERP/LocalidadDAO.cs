using System;
using System.Data;
using System.Data.OleDb;

namespace PryApeERP
{
    public class LocalidadDAO
    {
        /// Todas las localidades (uso general si se necesita)
        public DataTable ObtenerTodas()
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                string sql = @"SELECT l.Id_localidad, l.nombre, l.Id_provincia
                               FROM localidad l
                               ORDER BY l.nombre";
                new OleDbDataAdapter(new OleDbCommand(sql, cx.ObtenerConexion())).Fill(dt);
            }
            return dt;
        }

        /// Localidades filtradas por provincia (para el ComboBox en cascada)
        public DataTable ObtenerPorProvincia(int idProvincia)
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                string sql = @"SELECT Id_localidad, nombre
                               FROM localidad
                               WHERE Id_provincia = ?
                               ORDER BY nombre";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", idProvincia);
                new OleDbDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        /// Devuelve el Id_provincia al que pertenece una localidad dada
        public int ObtenerIdProvinciaPorLocalidad(int idLocalidad)
        {
            using (var cx = new clsConexion())
            {
                string sql = "SELECT Id_provincia FROM localidad WHERE Id_localidad = ?";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                cmd.Parameters.AddWithValue("?", idLocalidad);
                var resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToInt32(resultado) : 0;
            }
        }
    }
}