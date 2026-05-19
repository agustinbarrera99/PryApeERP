using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace PryApeERP
{
    public class clsConexion : IDisposable
    {
        private static readonly string _connectionString = ObtenerConnectionString();

        private static string ObtenerConnectionString()
        {
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;

            // sube desde bin/Debug hasta la raíz del proyecto
            string rutaProyecto = Path.GetFullPath(Path.Combine(rutaBase, @"..\..\"));

            string rutaDb = Path.Combine(rutaProyecto, "data", "Barrera.accdb");

            if (!File.Exists(rutaDb))
            {
                MessageBox.Show(
                    $"No se encontró la base de datos en:\n{rutaDb}",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={rutaDb};";
        }

        private OleDbConnection _conexion;
        private bool _disposed = false;

        public OleDbConnection ObtenerConexion()
        {
            if (_conexion == null)
                _conexion = new OleDbConnection(_connectionString);

            if (_conexion.State == System.Data.ConnectionState.Closed)
                _conexion.Open();

            return _conexion;
        }

        public void CerrarConexion()
        {
            if (_conexion != null &&
                _conexion.State == System.Data.ConnectionState.Open)
                _conexion.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    CerrarConexion();
                    _conexion?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}