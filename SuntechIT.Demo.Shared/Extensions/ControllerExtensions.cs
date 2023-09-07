﻿using SuntechIT.Demo.Shared.Identity;
using System.Security.Claims;

namespace SuntechIT.Demo.Shared.Extensions
{
    public static class ControllerExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue("sub");
        }

        public static CurrentUser? GetCurrentUser(this ClaimsPrincipal user)
        {
            string firstValue = user.FindFirstValue("sub");

            if (firstValue.IsNullOrWhiteSpace())
                return null;

            return new CurrentUser()
            {
                Id = firstValue,
                Email = user.FindFirstValue("email"),
                Role = user.FindFirstValue("role")
            };
        }

        public static bool IsSuperAdmin(this ClaimsPrincipal user)
        {
            CurrentUser? currentUser = user.GetCurrentUser();
            return currentUser != null && currentUser.IsSuperAdmin;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            CurrentUser? currentUser = user.GetCurrentUser();
            return currentUser != null && currentUser.IsAdmin;
        }

        public static bool IsNormalUser(this ClaimsPrincipal user)
        {
            CurrentUser? currentUser = user.GetCurrentUser();
            return currentUser != null && currentUser.IsNormalUser;
        }
    }
}
