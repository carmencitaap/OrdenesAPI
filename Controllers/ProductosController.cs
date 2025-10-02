using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OrdenesApi.Data;
using OrdenesApi.Models;

namespace OrdenesApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context) {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos() {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id) {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null) {
                return NotFound();
            }

            return producto;
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto) {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }
}