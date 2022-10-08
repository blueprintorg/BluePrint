namespace BluePrint.CrossCuttingConcern.Authorization.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    /// <summary>
    /// 
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Claimses the specified claim type.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns></returns>
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        /// <summary>
        /// Claims the roles.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns></returns>
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
