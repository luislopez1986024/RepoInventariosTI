using InventariosTI.Shared.Interfaces;
using InventarioTI.Server.Data;

using InventarioTI.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioTI.Server.Repositories
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly AppDbContext _context;

        public EquipoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipo>> GetEquiposAsync()
        {
            return await _context.Equipos.ToListAsync();
        }

        public async Task<Equipo?> GetEquipoByIdAsync(int id)
        {
            return await _context.Equipos.FindAsync(id);
        }

        public async Task<Equipo> AddEquipoAsync(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return equipo;
        }

        public async Task<Equipo> UpdateEquipoAsync(Equipo equipo)
        {
            _context.Equipos.Update(equipo);
            await _context.SaveChangesAsync();
            return equipo;
        }

        public async Task<bool> DeleteEquipoAsync(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return false;

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
