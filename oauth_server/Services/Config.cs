using System.Collections.Generic;
using IdentityServer4.Models;

namespace netcore_oauth
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("User.info", "Get user infomation")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
                    {
                        new Client
                        {
                            ClientId = "clientID",
                            // no interactive user, use the clientid/secret for authentication
                            AllowedGrantTypes = GrantTypes.ClientCredentials,

                            // secret for authentication
                            ClientSecrets =
                            {
                                new Secret("secretPassword".Sha256())
                            },

                            // scopes that client has access to
                            AllowedScopes = { "User.info" }
                        }
                    };
        }
    }
}