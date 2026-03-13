using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserType UserType { get; set; }
}
