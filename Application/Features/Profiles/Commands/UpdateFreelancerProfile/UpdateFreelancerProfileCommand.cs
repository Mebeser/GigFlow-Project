using MediatR;

namespace GigFlow.Application.Features.Profiles.Commands.UpdateFreelancerProfile;

public class UpdateFreelancerProfileCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public string? Title { get; set; }
    public string? Bio { get; set; }
    public decimal? HourlyRate { get; set; }
}
