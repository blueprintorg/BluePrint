using BluePrint.Model.Entities.Behaviors;
using Microsoft.AspNetCore.Identity;
using System;

namespace BluePrint.Idm.Model.Entities
{
    public class UserLoginEntity : IdentityUserLogin<int>, IEntity
    {
        public int Id { get ; set ; }

        public string CreatedBy { get ; set ; }

        public DateTime? CreationDate { get ; set ; }

        public string ModifiedBy { get ; set ; }

        public DateTime? ModificationDate { get ; set ; }
    }
}
