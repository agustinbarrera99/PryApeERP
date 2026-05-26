using System;
using System.Data;
using System.Data.OleDb;

namespace PryApeERP
{
    public class AuditoriaDAO
    {
        public void RegistrarIntento(int idUsuario, string mail, bool exitoso, int intentosRestantes)
        {
            using (var cx = new clsConexion())
            {
                string sql = @"INSERT INTO auditoria_sesion 
                               (Id_usuario, mail, fecha_hora, exitoso, intentos_restantes)
                               VALUES (?, ?, ?, ?, ?)";
                var cmd = new OleDbCommand(sql, cx.ObtenerConexion());

                cmd.Parameters.Add("?", OleDbType.Integer).Value = idUsuario;
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = mail;
                cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("?", OleDbType.Boolean).Value = exitoso;
                cmd.Parameters.Add("?", OleDbType.Integer).Value = intentosRestantes;

                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ObtenerTodos()
        {
            var dt = new DataTable();
            using (var cx = new clsConexion())
            {
                string sql = @"SELECT a.Id_auditoria, a.Id_usuario, a.mail, 
                              a.fecha_hora, a.exitoso, a.intentos_restantes
                       FROM auditoria_sesion a
                       ORDER BY a.fecha_hora DESC";
                new OleDbDataAdapter(new OleDbCommand(sql, cx.ObtenerConexion())).Fill(dt);
            }
            return dt;
        }
    }
}