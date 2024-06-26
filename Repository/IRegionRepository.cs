using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nzd.api.Models.Domains;

namespace Nzd.api.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id, Region region);

        Task<Region> DeleteAsync(Guid id);

    }
}