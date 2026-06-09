using PryApeERP;
using System;
using System.Data;
using System.Data.OleDb;

public class DomicilioDAO
{
    public DataTable ObtenerPorUsuario(int idUsuario)
    {
        var dt = new DataTable();
        using (var cx = new clsConexion())
        {
            string sql = @"
                SELECT d.Id_domicilio, d.descripcion, d.direccion,
                       d.Id_localidad, l.nombre AS localidad,
                       p.Id_provincia, p.Nombre AS provincia,
                       d.geo_lat, d.geo_lng, d.principal
                FROM (usuario_domicilio d
                LEFT JOIN localidad l ON d.Id_localidad = l.Id_localidad)
                LEFT JOIN provincia p ON l.Id_provincia = p.Id_provincia
                WHERE d.Id_usuario = ?";
            var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
            cmd.Parameters.Add("?", OleDbType.Integer).Value = idUsuario;
            new OleDbDataAdapter(cmd).Fill(dt);
        }
        return dt;
    }

    public void Insertar(int idUsuario, string descripcion, string direccion,
                         int idLocalidad, double lat, double lng, bool principal)
    {
        using (var cx = new clsConexion())
        {
            string sql = @"INSERT INTO usuario_domicilio 
                (Id_usuario, descripcion, direccion, Id_localidad, geo_lat, geo_lng, principal)
                VALUES (?, ?, ?, ?, ?, ?, ?)";
            var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
            cmd.Parameters.Add("?", OleDbType.Integer).Value = idUsuario;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = descripcion;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = direccion;
            cmd.Parameters.Add("?", OleDbType.Integer).Value = idLocalidad;
            cmd.Parameters.Add("?", OleDbType.Double).Value = lat == 0 ? (object)DBNull.Value : lat;
            cmd.Parameters.Add("?", OleDbType.Double).Value = lng == 0 ? (object)DBNull.Value : lng;
            cmd.Parameters.Add("?", OleDbType.Integer).Value = principal ? -1 : 0;
            cmd.ExecuteNonQuery();
        }
    }

    public void Actualizar(int idDomicilio, string descripcion, string direccion,
                           int idLocalidad, double lat, double lng, bool principal)
    { /* similar a Insertar con UPDATE ... WHERE Id_domicilio = ? */ }

    public void Eliminar(int idDomicilio)
    {
        using (var cx = new clsConexion())
        {
            string sql = "DELETE FROM usuario_domicilio WHERE Id_domicilio = ?";
            var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
            cmd.Parameters.Add("?", OleDbType.Integer).Value = idDomicilio;
            cmd.ExecuteNonQuery();
        }
    }

    public void EliminarPorUsuario(int idUsuario)
    {
        using (var cx = new clsConexion())
        {
            string sql = "DELETE FROM usuario_domicilio WHERE Id_usuario = ?";
            var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
            cmd.Parameters.Add("?", OleDbType.Integer).Value = idUsuario;
            cmd.ExecuteNonQuery();
        }
    }
}