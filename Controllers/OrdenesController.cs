using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OrdenesApi.Data;
using OrdenesApi.Models;

namespace OrdenesApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase {
        private readonly AppDbContext _context;

        public OrdenesController(AppDbContext context) {
            _context = context;
        }

        // GET: api/Ordenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenes() {
            return await _context.Ordenes.ToListAsync();
        }

        // GET: api/Ordenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orden>> GetOrden(int id) {
            var orden = await _context.Ordenes.FindAsync(id);

            if (orden == null) {
                return NotFound();
            }

            return orden;
        }

        // POST: api/Ordenes
        [HttpPost]
        public async Task<ActionResult<Orden>> PostOrden(Orden orden) {
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrden), new { id = orden.Id }, orden);
        }

        // PUT: api/Ordenes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrden(int id, Orden orden) {
            if (id != orden.Id) {
                return BadRequest();
            }

            _context.Entry(orden).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!OrdenExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Ordenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrden(int id) {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null) {
                return NotFound();
            }

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenExists(int id) {
            return _context.Ordenes.Any(e => e.Id == id);
        }
    }
}