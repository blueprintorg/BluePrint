using BluePrint.Model.Entities.Concretes;
using System.Collections.Generic;

namespace BluePrint.Idm.Model.Entities
{
    public class TownEntity : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual CityEntity City { get; set; }

        public virtual double Latitude { get; set; }

        public virtual double Longtitude { get; set; }

        public virtual int CityId { get; set; }

        public virtual IEnumerable<DistrictEntity> Districts { get; set; }

        public TownEntity()
        {
            this.Districts = new List<DistrictEntity>();
        }
    }
}
