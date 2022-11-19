using System;
namespace JWTAuth.Utils
{
    public interface IJwtTokenManager
    {
        public string? Authenticate(string userName);

        public string DecodeToken(string token);
    }
}

