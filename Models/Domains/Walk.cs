using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzd.api.Models.Domains
{
    public class Walk
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public Double LengthInKm { get; set; }

        public String? WalkImageUrl { get; set; }


        public Guid DifficultyId {get; set;}

        public Guid RegionId { get; set; }


        //Navigation properties


        public Difficulty Difficulty { get; set; }

        public Region Region { get; set; }


        
    }
}