using Habits_App.Domain.Entities.Auth;
using System.Security.Claims;

namespace Habits_App.Application.Interfaces.Services
{
    public interface ITokenService
    {

        ClaimsPrincipal GetPrincipalFromRefreshToken(string refreshToken);

        string CreateRefreshToken(User _User);

        Task<String> CreateAccessToken(User _User);

    }
}
