using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    internal class Resources
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
            return new List<ApiResource> {
                new ApiResource {
                    Name = "api1",
                    DisplayName = "API 1",
                    Description = "API 1 features and data",
                    Scopes = new List<Scope> {
                        new Scope("customAPI.read"),
                        new Scope("customAPI.write")
                    }
                }
            };
        }
    }
}
