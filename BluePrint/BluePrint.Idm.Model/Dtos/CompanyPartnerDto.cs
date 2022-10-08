using BluePrint.Idm.Model.Enumerations;
using BluePrint.Model.Dtos.Concretes;
using System;

namespace BluePrint.Idm.Model.Dtos
{
    public class CompanyPartnerDto :BaseDto
    {
        public int CompanyLocationId { get; set; }

        public int? PartnerId { get; set; }

        public CompanyPartnerRelationType RelationType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
