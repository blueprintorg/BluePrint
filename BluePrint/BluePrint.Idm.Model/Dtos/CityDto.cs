using BluePrint.Model.Dtos.Concretes;
using System.Collections.Generic;

namespace BluePrint.Idm.Model.Dtos
{
    public class CityDto : BaseDto
    {
        public string Name { get; set; }

        public CountryDto Country { get; set; }

        public string PlateNumber { get; set; }

        public string CallingCode { get; set; }

        public double Latitude { get; set; }

        public double Longtitude { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<TownDto> Towns { get; set; }

        public CityDto()
        {
            this.Towns = new List<TownDto>(); 
        }
    }
}
