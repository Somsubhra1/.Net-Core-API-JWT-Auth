﻿using System;
namespace JWTAuth.Utils
{
    public interface IJwtTokenManager
    {
        public string? Authenticate(string userName, string password);

        public string DecodeToken(string token);
    }
}
