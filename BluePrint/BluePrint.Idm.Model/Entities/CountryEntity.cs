using BluePrint.Model.Entities.Concretes;
using System.Collections.Generic;

namespace BluePrint.Idm.Model.Entities
{
    public class CountryEntity : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual string OfficialName { get; set; }

        public virtual string CountryCodeTld { get; set; }

        public virtual string Cca2 { get; set; }

        public virtual string Ccn2 { get; set; }

        public virtual string Cca3 { get; set; }

        public virtual string Cioc { get; set; }

        public virtual bool IndependentStatus { get; set; }

        public virtual string AssignedStatus { get; set; }

        public virtual string CallingCode { get; set; }

        public virtual string Capital { get; set; }

        public virtual string Region { get; set; }

        public virtual string Subregion { get; set; }

        public virtual IEnumerable<CityEntity> Cities { get; set; }

        public CountryEntity()
        {
            this.Cities = new List<CityEntity>();
        }
    }
}
