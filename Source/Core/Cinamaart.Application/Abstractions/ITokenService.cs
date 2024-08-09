﻿using Cinamaart.Application.DTO;
using Cinamaart.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions
{
    public interface ITokenService
    {
        Task<TokenResultDTO> GenerateTokenAsync(User user);
        Task<TokenResultDTO> GenerateTokenAsync(User user , Claim[] claims);
        Task<TokenResultDTO> GenerateRefreshTokenAsync(long userId, string deviceId);
        Task<bool> ValidateRefreshTokenAsync(long userId, string deviceId, string refreshToken);
        Task RevokeRefreshTokenAsync(long userId , string deviceId);
        Task RevokeAllRefreshTokensAsync(string userId);

    }
}
