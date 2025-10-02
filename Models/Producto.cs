namespace OrdenesApi.Models {
    public class Producto {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public decimal Precio { get; set; }

        public List<OrdenProducto> OrdenProductos { get; set; } = new List<OrdenProducto>();
    }
}