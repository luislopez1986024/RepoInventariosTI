﻿using InventarioTI.Server.Data;
using InventarioTI.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventariosTI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquiposController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Equipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipos()
        {
            return await _context.Equipos.ToListAsync();
        }

        // GET: api/Equipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipo>> GetEquipo(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);

            if (equipo == null)
            {
                return NotFound();
            }

            return equipo;
        }

        // POST: api/Equipos
        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id_Equip }, equipo);
        }

        // PUT: api/Equipos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipo(int id, Equipo equipo)
        {
            if (id != equipo.Id_Equip)
            {
                return BadRequest();
            }

            _context.Entry(equipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Equipos.Any(e => e.Id_Equip == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Equipos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
