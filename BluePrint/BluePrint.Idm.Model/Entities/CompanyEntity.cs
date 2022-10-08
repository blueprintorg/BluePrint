using BluePrint.Model.Entities.Concretes;

namespace BluePrint.Idm.Model.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public virtual string Title { get; set; }

        public virtual string TaxNo { get; set; }

        public virtual bool IsPartner { get; set; }

        public virtual int? ParentCompanyId { get; set; }

        public virtual int? ReferencedById { get; set; }

        public virtual int IndustryId { get; set; }

        public virtual int CompanyTypeId { get; set; }

        public virtual int TaxOfficeId { get; set; }

        public virtual string WorkingDays { get; set; }

        public virtual double DailyWorkHours { get; set; }

        public virtual string CustomerNo { get; set; }
    }
}
