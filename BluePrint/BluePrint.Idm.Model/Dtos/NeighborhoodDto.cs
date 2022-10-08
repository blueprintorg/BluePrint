using BluePrint.Model.Dtos.Concretes;

namespace BluePrint.Idm.Model.Dtos
{
    public class NeighborhoodDto : BaseDto
    {
        public string Name { get; set; }
        
        public string ZipCode { get; set; }

        public DistrictDto District { get; set; }

        public int DistrictId { get; set; }
    }
}
