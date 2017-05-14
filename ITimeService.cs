using System;
using System.Security.Claims;

namespace EastFive.Api.Services
{
    public interface ITimeService
    {
        DateTime Utc { get; }
    }
}