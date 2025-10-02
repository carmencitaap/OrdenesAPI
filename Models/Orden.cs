namespace OrdenesApi.Models {
    public class Orden {
        public int Id { get; set; }

        [Required]
        public string Cliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal Total { get; set; }

        public List<OrdenProducto> OrdenProductos { get; set; } = new List<OrdenProducto>();
    }
}