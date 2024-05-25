using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nzd.api.Data;
using Nzd.api.Models.Domains;

namespace Nzd.api.Repository
{
    public class SqlRegionRepository :IRegionRepository
    {
        private readonly RkvWalkContext dbContext;

        public SqlRegionRepository(RkvWalkContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        public async Task<List<Region>>GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();

        }
        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x=> x.Id==id);

        }
        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            dbContext.SaveChangesAsync();
            return existingRegion;
        }
        public async Task<Region> DeleteAsync(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(existingRegion==null)
            {
                
                return null;
            }
            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}