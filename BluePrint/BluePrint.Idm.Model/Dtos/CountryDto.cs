using BluePrint.Model.Dtos.Concretes;
using System.Collections.Generic;

namespace BluePrint.Idm.Model.Dtos
{
    public class CountryDto : BaseDto
    {
        public string Name { get; set; }

        public string OfficialName { get; set; }

        public string CountryCodeTld { get; set; }

        public string Cca2 { get; set; }

        public string Ccn2 { get; set; }

        public string Cca3 { get; set; }

        public string Cioc { get; set; }

        public bool IndependentStatus { get; set; }

        public string AssignedStatus { get; set; }

        public string CallingCode { get; set; }

        public string Capital { get; set; }

        public string Region { get; set; }

        public string Subregion { get; set; }

        public IEnumerable<CityDto> Cities { get; set; }

        public CountryDto()
        {
            this.Cities = new List<CityDto>();
        }

    }
    
}
