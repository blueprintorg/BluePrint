using BluePrint.Model.Dtos.Concretes;
using System.Collections.Generic;

namespace BluePrint.Idm.Model.Dtos
{
    public class DistrictDto: BaseDto
    {
        public string Name { get; set; }

        public TownDto Town { get; set; }

        public int TownId { get; set; }

        public IEnumerable<NeighborhoodDto> Neighborhoods { get; set; }

        public DistrictDto()
        {
            this.Neighborhoods = new List<NeighborhoodDto>();  
        }
    }
}
