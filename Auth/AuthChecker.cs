using System;
using Microsoft.AspNetCore.Http;
using zuiderzorg.Models;

namespace zuiderzorg.Auth {
    public class AuthChecker {
        public User User { get; }

        public AuthChecker(IHttpContextAccessor accessor) {
            // Get token out of cookies
            var token = accessor.HttpContext.Request.Cookies["JWTAuthToken"];
            if (token == null) {
                return;
            }

            // Try to verify the token and set it as the user
            var jwt = new Jwt();
            User = jwt.Verify(token);
        }

        public bool isLoggedIn() {
            return User != null;
        }

        // Allows for @if (authChecker)
        public static implicit operator bool(AuthChecker checker) => checker.isLoggedIn();
    }
}