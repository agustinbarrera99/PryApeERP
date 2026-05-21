using System;
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
    }
}