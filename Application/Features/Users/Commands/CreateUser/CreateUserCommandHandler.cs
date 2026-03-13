using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;
using BCrypt.Net;

namespace GigFlow.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IAppUserRepository _userRepository;
    private readonly IFreelancerProfileRepository _freelancerRepository;
    private readonly IClientProfileRepository _clientRepository;

    public CreateUserCommandHandler(
        IAppUserRepository userRepository,
        IFreelancerProfileRepository freelancerRepository,
        IClientProfileRepository clientRepository)
    {
        _userRepository = userRepository;
        _freelancerRepository = freelancerRepository;
        _clientRepository = clientRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetAllAsync(u => u.Email == request.Email);
        if (existingUser.Any())
        {
            throw new Exception("Bu e-posta adresi zaten kayıtlı.");
        }

        var appUser = new AppUser
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserType = request.UserType,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        await _userRepository.AddAsync(appUser);

        // Kullanıcı tipine göre otomatik profil oluşturuyoruz
        if (request.UserType == UserType.Freelancer)
        {
            await _freelancerRepository.AddAsync(new FreelancerProfile
            {
                Id = Guid.NewGuid(),
                UserId = appUser.Id,
                CreatedDate = DateTime.UtcNow,
                AverageRating = 0,
                TotalEarnings = 0
            });
        }
        else if (request.UserType == UserType.Client)
        {
            await _clientRepository.AddAsync(new ClientProfile
            {
                Id = Guid.NewGuid(),
                UserId = appUser.Id,
                CreatedDate = DateTime.UtcNow,
                TotalSpent = 0
            });
        }

        return appUser.Id;
    }
}
