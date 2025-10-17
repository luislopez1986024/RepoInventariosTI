using InventarioTI.Shared.Models;

namespace InventariosTI.Shared.Interfaces
{
    public interface IEquipoRepository
    {
        Task<IEnumerable<Equipo>> GetEquiposAsync();
        Task<Equipo?> GetEquipoByIdAsync(int id);
        Task<Equipo> AddEquipoAsync(Equipo equipo);
        Task<Equipo> UpdateEquipoAsync(Equipo equipo);
        Task<bool> DeleteEquipoAsync(int id);
    }
}
