namespace PryApeERP
{
    public class RedSocialItem
    {
        public int Id { get; set; }          // Id de usuario_red (o temporal negativo si es nuevo)
        public int IdRed { get; set; }        // FK a redes_sociales
        public string NombreRed { get; set; } // Para mostrar en la grilla sin JOIN extra
        public string UrlPerfil { get; set; }
    }
}
