namespace Modelo.Entitys
{
    public class VentaEntity
    {
        public int id { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha_venta { get; set; }
        public decimal total { get; set; }
    }
}
