using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.Profiles.Commands.UpdateFreelancerProfile;

public class UpdateFreelancerProfileCommandHandler : IRequestHandler<UpdateFreelancerProfileCommand, Unit>
{
    private readonly IFreelancerProfileRepository _freelancerRepository;

    public UpdateFreelancerProfileCommandHandler(IFreelancerProfileRepository freelancerRepository)
    {
        _freelancerRepository = freelancerRepository;
    }

    public async Task<Unit> Handle(UpdateFreelancerProfileCommand request, CancellationToken cancellationToken)
    {
        var profiles = await _freelancerRepository.GetAllAsync(p => p.UserId == request.UserId);
        var profile = profiles.FirstOrDefault();

        if (profile == null) throw new Exception("Profil bulunamadı.");

        profile.Title = request.Title ?? profile.Title;
        profile.Bio = request.Bio ?? profile.Bio;
        profile.HourlyRate = request.HourlyRate ?? profile.HourlyRate;

        await _freelancerRepository.UpdateAsync(profile);
        return Unit.Value;
    }
}
