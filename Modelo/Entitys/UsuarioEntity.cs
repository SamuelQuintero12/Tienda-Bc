namespace Modelo.Entitys
{
    public class UsuarioEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string rol { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}
