using BluePrint.Model.Dtos.Concretes;
using System.Collections.Generic;

namespace BluePrint.Idm.Model.Dtos
{
    public class TownDto : BaseDto
    {
        public string Name { get; set; }

        public CityDto City { get; set; }

        public double Latitude { get; set; }

        public double Longtitude { get; set; }

        public int CityId { get; set; }

        public IEnumerable<DistrictDto> Districts { get; set; }

        public TownDto()
        {
            this.Districts = new List<DistrictDto>();
        }
    }
}
