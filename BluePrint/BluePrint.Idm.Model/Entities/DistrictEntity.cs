using BluePrint.Model.Entities.Concretes;
using System.Collections.Generic;

namespace BluePrint.Idm.Model.Entities
{
    public class DistrictEntity : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual TownEntity Town { get; set; }

        public virtual int TownId { get; set; }

        public IEnumerable<NeighborhoodEntity> Neighborhoods { get; set; }

        public DistrictEntity()
        {
            this.Neighborhoods = new List<NeighborhoodEntity>();
        }
    }
}
