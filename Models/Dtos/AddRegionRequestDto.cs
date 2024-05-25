using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzd.api.Models.Dtos
{
    public class AddRegionRequestDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}