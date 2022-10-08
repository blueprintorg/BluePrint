using BluePrint.Model.Dtos.Concretes;

namespace BluePrint.Idm.Model.Dtos
{
    public class CompanyDto : BaseDto
    {
        public string Title { get; set; }

        public string TaxNo { get; set; }
        
        public bool IsPartner { get; set; }
        
        public int? ParentCompanyId { get; set; }
        
        public int? ReferencedById { get; set; }
        
        public int IndustryId { get; set; }
        
        public int CompanyTypeId { get; set; }
        
        public int TaxOfficeId { get; set; }
        
        public string WorkingDays { get; set; }
        
        public double DailyWorkHours { get; set; }
        
        public string CustomerNo { get; set; }
    }
}
