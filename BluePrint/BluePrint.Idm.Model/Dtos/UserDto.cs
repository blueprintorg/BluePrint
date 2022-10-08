using BluePrint.Model.Dtos.Concretes;

namespace BluePrint.Idm.Model.Dtos
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string RoleName { get; set; }

        public bool InUse { get; set; }

        public string OldPasswordHash { get; set; }

        public int OldPasswordHashType { get; set; }

        public int CompanyLocationId { get; set; }

        public int ClientId { get; set; }
    }
}
