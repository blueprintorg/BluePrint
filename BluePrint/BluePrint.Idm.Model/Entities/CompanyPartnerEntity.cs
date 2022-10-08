using BluePrint.Idm.Model.Enumerations;
using BluePrint.Model.Entities.Concretes;
using System;

namespace BluePrint.Idm.Model.Entities
{
    public class CompanyPartnerEntity : BaseEntity
    {
        public virtual int CompanyLocationId { get; set; }

        public virtual int? PartnerId { get; set; }

        public virtual CompanyPartnerRelationType RelationType { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }
    }
}
