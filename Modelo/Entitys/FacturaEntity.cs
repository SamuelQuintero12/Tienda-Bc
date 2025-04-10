namespace Modelo.Entitys
{
    public class FacturaEntity
    {
        public int id { get; set; }
        public int id_venta { get; set; }
        public decimal monto_total { get; set; }
        public DateTime fecha { get; set; }
    }
}
