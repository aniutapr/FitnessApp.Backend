using System;
using System.Security.Claims;
using FitnessApp.Contracts.Services;
using Microsoft.AspNetCore.Http;

namespace FitnessApp.Application.Services;

public class MyProfileService : IMyProfileService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MyProfileService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetUserId()
    {
        var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
        var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

        return userIdClaim?.Value;
    }
}