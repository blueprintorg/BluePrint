using BluePrint.Idm.Model.Enumerations;
using BluePrint.Model.Dtos.Concretes;

namespace BluePrint.Idm.Model.Dtos
{
    public class CompanyLocationDto : BaseDto
    {
        public int CompanyId { get; set; }

        public int? PartnerId { get; set; }
        
        public CompanyLocationType Type { get; set; }

        public string EmailAddress1 { get; set; }

        public string EmailAddress2 { get; set; }

        public string WebSite1 { get; set; }

        public string WebSite2 { get; set; }

        public string Village { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string ApartmentName { get; set; }

        public string ApartmentNumber { get; set; }

        public string DoorNumber { get; set; }

        public string ZipCode { get; set; }

        public string AddressCode { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public int? CityId { get; set; }

        public int? CountryId { get; set; }

        public CountryDto Country { get; set; }

        public CityDto City { get; set; }

        public PartnerDto Partner { get; set; }
 
    }
}
