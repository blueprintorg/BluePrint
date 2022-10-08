using BluePrint.Model.Entities.Behaviors;
using Microsoft.AspNetCore.Identity;
using System;

namespace BluePrint.Idm.Model.Entities
{
    public class RoleClaimEntity : IdentityRoleClaim<int> , IEntity
    {
        public virtual string Name { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime? CreationDate { get; set; }

        public virtual string ModifiedBy { get; set; }

        public virtual DateTime? ModificationDate { get; set; }
    }
}
