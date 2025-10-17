using InventarioTI.Shared.Models;
using System;
using System.Collections.Generic;

namespace InventarioTI.Shared.Interfaces
{
    public interface IAreaRepository
    {
       Task<IEnumerable<Area>> GetAreasAsync();

       Task<Area?> GetAreaByIdAsync(int id);

        Task<Area> AddAreaAsync(Area area);


        Task<Area> UpdateAreaAsync(Area area);

        Task<bool> DeleteAreaAsync(int id);
    }
}
