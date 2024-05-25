using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Nzd.api.Models.Domains;

namespace Nzd.api.Data
{
    public class RkvWalkContext : DbContext
    {
        public RkvWalkContext(DbContextOptions dbcontextcptions) : base(dbcontextcptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties {get; set;}

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}