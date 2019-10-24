using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4;
using IdentityModel;

namespace AuthServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                 new ApiResource("hoxrofinance", "HoxroFinance")
                {
                    Scopes = {new Scope("hoxrofinance.read") },
                    ApiSecrets = {new Secret("hxr_fin_2019_sec@api/1".Sha256())}
                 },
                 new ApiResource("api2", "api2")
                {
                    Scopes = {new Scope("api2.read")},
                     
                },
                //  new ApiResource
                //{
                //    Name = "api2",

                //    // secret for using introspection endpoint
                //    ApiSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },

                //    // include the following using claims in access token (in addition to subject id)
                //    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email },

                //    // this API defines two scopes
                //    Scopes =
                //    {
                //        new Scope()
                //        {
                //            Name = "api2.full_access",
                //            DisplayName = "Full access to API 2",
                //        },
                //        new Scope
                //        {
                //            Name = "api2.read_only",
                //            DisplayName = "Read only access to API 2"
                //        }
                //    }
                //}
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client {
                    RequireConsent = false,
                    ClientId = "finance_spa",
                    ClientName = "Finance SPA",
                    AccessTokenType = AccessTokenType.Reference,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "hoxrofinance.read"
                    },
                    ClientSecrets = {new Secret("hxr_fin_2019_sec@api/1".Sha256())},
                    RedirectUris = {"http://localhost:4200/auth-callback"},
                    PostLogoutRedirectUris = {"http://localhost:4200/?postLogout=true"},
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600
                },
                new Client {
                    RequireConsent = false,
                    ClientId = "angular_spa2",
                    ClientName = "Angular SPA2",
                   // AccessTokenType = AccessTokenType.Reference,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api2.read"
                    },
                    RedirectUris = {"http://localhost:4100/auth-callback"},
                    PostLogoutRedirectUris = {"http://localhost:4100/?postLogout=true"},
                    AllowedCorsOrigins = {"http://localhost:4100"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600
                },
            };
        }
    }
}
