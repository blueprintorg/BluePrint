namespace BluePrint.Idm.IdentityServer
{
    using IdentityServer4.Models;
    using System.Collections.Generic;
    using System.Security.Claims;

    /// <summary>
    /// 
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Gets the ids.
        /// </summary>
        /// <value>
        /// The ids.
        /// </value>
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        /// <summary>
        /// Gets the apis.
        /// </summary>
        /// <value>
        /// The apis.
        /// </value>
        public static IEnumerable<ApiResource> Apis =>
                new List<ApiResource>
                {
                    new ApiResource("api1", "My API")
                };

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <value>
        /// The clients.
        /// </value>
        public static IEnumerable<Client> Clients =>
                new List<Client>
                {
                    new Client
                    {
                        ClientId = "client",

                        // no interactive user, use the clientid/secret for authentication
                        AllowedGrantTypes = GrantTypes.ClientCredentials,

                        // secret for authentication
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },

                        // scopes that client has access to
                        AllowedScopes = { "api1" },

                        //claims
                         Claims = new[]
                         {
                            new Claim("Role", "Admin"),
                         }
                    }
                };

    }
}