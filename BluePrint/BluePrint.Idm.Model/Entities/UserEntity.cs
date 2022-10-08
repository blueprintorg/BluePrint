using BluePrint.Model.Entities.Behaviors;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluePrint.Idm.Model.Entities
{
    [Table("Users")]
    public class UserEntity : IdentityUser<int>, IEntity
    {
        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Password { get; set; }

        public virtual string NewPassword { get; set; }

        public virtual string RoleName { get; set; }

        public virtual bool InUse { get; set; }

        public virtual string OldPasswordHash { get; set; }

        public virtual int OldPasswordHashType { get; set; }

        public virtual int CompanyLocationId { get; set; }

        public virtual int ClientId { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime? CreationDate { get; set; }

        public virtual string ModifiedBy { get; set; }

        public virtual DateTime? ModificationDate { get; set; }

        //public virtual IEnumerable<RoleEntity> Roles { get; set; }

        //public UserEntity()
        //{
        //    this.Roles = new List<RoleEntity>();
        //}
    }
}
