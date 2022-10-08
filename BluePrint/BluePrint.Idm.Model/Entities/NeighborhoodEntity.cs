using BluePrint.Model.Entities.Concretes;

namespace BluePrint.Idm.Model.Entities
{
    public class NeighborhoodEntity : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual string ZipCode { get; set; }

        public virtual DistrictEntity District { get; set; }

        public virtual int DistrictId { get; set; }
    }
}
