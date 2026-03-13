using GigFlow.Application.Features.Profiles.Commands.UpdateFreelancerProfile;
using GigFlow.Application.Features.Profiles.Commands.UpdateFreelancerSkills;
using GigFlow.Application.Features.Profiles.Queries.SearchFreelancers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GigFlow.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfilesController(IMediator mediator) => _mediator = mediator;

    private Guid GetUserId() => Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpPost("update")]
    public async Task<IActionResult> UpdateFreelancerProfile([FromBody] UpdateFreelancerProfileCommand command)
    {
        command.UserId = GetUserId();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("update-skills")]
    public async Task<IActionResult> UpdateFreelancerSkills([FromBody] UpdateFreelancerSkillsCommand command)
    {
        command.UserId = GetUserId();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchFreelancers([FromQuery] SearchFreelancersQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
