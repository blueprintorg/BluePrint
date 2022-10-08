using BluePrint.Model.Entities.Concretes;
using System.Collections.Generic;

namespace BluePrint.Idm.Model.Entities
{
    public class CityEntity : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual CountryEntity Country { get; set; }

        public virtual string PlateNumber { get; set; }

        public virtual string CallingCode { get; set; }

        public virtual double Latitude { get; set; }

        public virtual double Longtitude { get; set; }

        public virtual int CountryId { get; set; }

        public virtual IEnumerable<TownEntity> Towns { get; set; }

        public CityEntity()
        {
            this.Towns = new List<TownEntity>();
        }
    }
}
