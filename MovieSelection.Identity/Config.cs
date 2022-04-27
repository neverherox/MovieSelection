// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;

namespace MovieSelection.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new ProfileWithRoleIdentityResource()
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("movieSelectionApi", "The MovieSelection API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("movieSelectionApi", "The MovieSelection API", new[] { JwtClaimTypes.Role, JwtClaimTypes.Name })
                {
                    Scopes = { "movieSelectionApi" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "movieSelection",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost:5020" },
                    AllowedScopes =
                    {
                        "openid",
                        "profile",
                        "movieSelectionApi"
                    },
                    RedirectUris = { "https://localhost:5020/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:5020/authentication/logout-callback" }
                },
            };
    }

    public class ProfileWithRoleIdentityResource
        : IdentityResources.Profile
    {
        public ProfileWithRoleIdentityResource()
        {
            this.UserClaims.Add(JwtClaimTypes.Role);
        }
    }
}