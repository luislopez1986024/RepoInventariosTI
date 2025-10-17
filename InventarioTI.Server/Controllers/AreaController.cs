using InventarioTI.Server.Data;
using InventarioTI.Shared.Interfaces;
using InventarioTI.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioTI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AreaController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/Area
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            return await _context.Areas.ToListAsync();
        }
        // GET: api/Area/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            return area;
        }
        // POST: api/Area
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(Area area)
        {
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArea), new { id = area.Id_Area }, area);
        }
        // PUT: api/Area/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(int id, Area area)
        {
            if (id != area.Id_Area)
            {
                return BadRequest();
            }
            _context.Entry(area).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/Area/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool AreaExists(int id)
        {
            return _context.Areas.Any(e => e.Id_Area == id);
        }
    }
}
