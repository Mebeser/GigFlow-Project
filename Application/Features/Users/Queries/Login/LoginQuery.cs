using MediatR;

namespace GigFlow.Application.Features.Users.Queries.Login;

public class LoginQuery : IRequest<LoginResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
