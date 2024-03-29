using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    public class AdminController : ControllerBase
    {
        // Actions that require "Admin" role
    }
}