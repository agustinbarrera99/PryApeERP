namespace PryApeERP
{
    // Regla de negocio centralizada de qué perfiles pueden acceder a qué.
    // Si mañana cambia quién puede entrar a estos módulos, se toca acá y no
    // en cada formulario por separado.
    public static class SeguridadHelper
    {
        public const int PERFIL_USUARIO = 1;
        public const int PERFIL_ADMINISTRADOR = 2;
        public const int PERFIL_RRHH = 3;

        public static bool PuedeAccederModuloSeguridad(int idPerfil)
        {
            return idPerfil == PERFIL_ADMINISTRADOR || idPerfil == PERFIL_RRHH;
        }
    }
}
