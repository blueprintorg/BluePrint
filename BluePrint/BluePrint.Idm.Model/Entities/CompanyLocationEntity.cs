using BluePrint.Idm.Model.Enumerations;
using BluePrint.Model.Entities.Concretes;

namespace BluePrint.Idm.Model.Entities
{
    public class CompanyLocationEntity : BaseEntity
    {
        public virtual int CompanyId { get; set; }

        public virtual int? PartnerId { get; set; }

        public virtual CompanyLocationType Type { get; set; }

        public virtual string EmailAddress1 { get; set; }

        public virtual string EmailAddress2 { get; set; }

        public virtual string WebSite1 { get; set; }

        public virtual string WebSite2 { get; set; }

        public virtual string Village { get; set; }

        public virtual string Town { get; set; }

        public virtual string Street { get; set; }

        public virtual string ApartmentName { get; set; }

        public virtual string ApartmentNumber { get; set; }

        public virtual string DoorNumber { get; set; }

        public virtual string ZipCode { get; set; }

        public virtual string AddressCode { get; set; }

        public virtual string PhoneNumber1 { get; set; }

        public virtual string PhoneNumber2 { get; set; }

        public virtual int? CityId { get; set; }

        public virtual int? CountryId { get; set; }

        public virtual CountryEntity Country { get; set; }

        public virtual CityEntity City { get; set; }

        public virtual  PartnerEntity Partner { get; set; }
    }
}
