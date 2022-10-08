using BluePrint.Model.Dtos.Concretes;

namespace BluePrint.Idm.Model.Dtos
{
    public class PartnerDto : BaseDto
    {
        public int CompanyId { get; set; }

        public string PartnerCode { get; set; }

        public CompanyDto Company { get; set; }
    }
}
