using System;
using System.Collections.Generic;
namespace PryApeERP
{
    // Guarda los datos del usuario logueado para que cualquier formulario
    // pueda consultarlos sin necesidad de recibirlos por parámetro.
    // Se completa una única vez, en frmInicioSesion, apenas el login es exitoso.
    public static class Sesion
    {
        public static int IdUsuario { get; set; }
        public static string Mail { get; set; }
        public static int IdPerfil { get; set; }

        public static void Limpiar()
        {
            IdUsuario = 0;
            Mail = null;
            IdPerfil = 0;
        }
    }
}
