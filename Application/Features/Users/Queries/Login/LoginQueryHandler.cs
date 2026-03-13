using GigFlow.Application.Interfaces;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using MediatR;
using System.Security.Claims;

namespace GigFlow.Application.Features.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
{
    private readonly IAppUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public LoginQueryHandler(IAppUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(u => u.Email == request.Email);
        var user = users.FirstOrDefault();

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new Exception("Geçersiz e-posta veya şifre.");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim("UserType", user.UserType.ToString())
        };

        var accessToken = _tokenService.CreateAccessToken(user, claims);
        var refreshToken = _tokenService.CreateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7); // Refresh token 7 gün geçerli

        await _userRepository.UpdateAsync(user);

        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Expiration = DateTime.Now.AddMinutes(60) // Access token 60 dakika geçerli
        };
    }
}
