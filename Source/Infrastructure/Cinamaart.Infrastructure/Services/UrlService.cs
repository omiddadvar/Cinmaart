﻿using Cinamaart.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;

namespace Cinamaart.Infrastructure.Services
{
    public class UrlService : IUrlService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GenerateBaseUri()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            return $"{request.Scheme}://{request.Host.Value}";
        }

        public string GenerateEmailConfirmationUri(string userId, string token)
        {
            var baseUri = GenerateBaseUri();
            return $"{baseUri}/api/auth/confirmemail?userId={userId}&token={token}";
        }
    }
}
