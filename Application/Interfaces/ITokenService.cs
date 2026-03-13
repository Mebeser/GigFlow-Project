using GigFlow.Domain.Entities;
using System.Security.Claims;

namespace GigFlow.Application.Interfaces;

public interface ITokenService
{
    string CreateAccessToken(AppUser user, List<Claim> claims);
    string CreateRefreshToken();
}
