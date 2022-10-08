using BluePrint.Model.Dtos.Concretes;
using System.Collections.Generic;

namespace BluePrint.Idm.Model.Dtos
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }
        
        public IEnumerable<RoleClaimDto> Claims { get; set; }

        public RoleDto()
        {
            this.Claims = new List<RoleClaimDto>();
        }
    }
}
