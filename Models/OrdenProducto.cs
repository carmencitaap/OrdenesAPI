namespace OrdenesApi.Models {
    public class OrdenProducto {
        public int Id { get; set; }

        [Required]
        public int OrdenId { get; set; }
        public Ordenes Orden { get; set; }

        [Required]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}