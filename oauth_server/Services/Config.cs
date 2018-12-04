using System.Collections.Generic;
using IdentityServer4;
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
                            // Server-Side Client
                            ClientId = "clientID",
                            AllowedGrantTypes = GrantTypes.ClientCredentials,
                            ClientSecrets =
                            {
                                new Secret("secretPassword".Sha256())
                            },
                            AllowedScopes = { "User.info" }
                        },
                        new Client 
                        {
                            // JavaScript Client
                            ClientId = "clientJS",
                            ClientName = "JavaScript Client",
                            AllowedGrantTypes = GrantTypes.Implicit,
                            AllowAccessTokensViaBrowser = true,

                            RedirectUris =           { "http://localhost:5000/callback.html" },
                            PostLogoutRedirectUris = { "http://localhost:5000/restrict_area.html" },
                            AllowedCorsOrigins =     { "http://localhost:5000" },

                            AllowedScopes =
                            {
                                IdentityServerConstants.StandardScopes.Profile,
                                "User.info"
                            }
                        }
                    };
        }
    }
}