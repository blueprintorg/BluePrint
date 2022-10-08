namespace BluePrint.Idm.Model.Resources
{
    public class RoleAssignResource
    {
        public int RoleId { get; set; }

        public int UserId { get; set; }

        public string RoleName { get; set; }

        public bool HasAssign { get; set; }
    }
}
