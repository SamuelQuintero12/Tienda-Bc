namespace Modelo.Entitys
{
    public class InventarioEntity
    {
        public int id { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public string tipo_accion { get; set; }  // 'entrada' o 'salida'
        public DateTime fecha { get; set; }
    }
}
