using BluePrint.Model.Entities.Concretes;

namespace BluePrint.Idm.Model.Entities
{
    public class PartnerEntity : BaseEntity
    {
        public virtual int CompanyId { get; set; }

        public virtual string PartnerCode { get; set; }

        public virtual CompanyEntity Company { get; set; }
    }
}
