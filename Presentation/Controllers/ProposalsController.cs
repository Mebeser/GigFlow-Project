using GigFlow.Application.Features.Proposals.Commands.CreateProposal;
using GigFlow.Application.Features.Proposals.Commands.UpdateProposal;
using GigFlow.Application.Features.Proposals.Commands.WithdrawProposal;
using GigFlow.Application.Features.Proposals.Commands.AcceptProposal;
using GigFlow.Application.Features.Proposals.Commands.RejectProposal;
using GigFlow.Application.Features.Proposals.Queries.GetProposalsByJobPosting;
using GigFlow.Application.Features.Proposals.Queries.GetProposalById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigFlow.Presentation.Controllers;

/// <summary>Teklif (Proposal) yönetimi işlemleri</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Microsoft.AspNetCore.Authorization.Authorize]
public class ProposalsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProposalsController(IMediator mediator) => _mediator = mediator;

    private Guid GetUserId() => Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!);

    /// <summary>Belirli bir iş ilanına ait tüm teklifleri listeler</summary>
    /// <param name="jobPostingId">İş ilanı ID'si</param>
    [HttpGet("by-jobposting/{jobPostingId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByJobPosting(Guid jobPostingId)
    {
        var result = await _mediator.Send(new GetProposalsByJobPostingQuery { JobPostingId = jobPostingId });
        return Ok(result);
    }

    /// <summary>Belirtilen ID'ye sahip teklifi getirir</summary>
    /// <param name="id">Teklif ID'si</param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetProposalByIdQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>Yeni bir teklif oluşturur</summary>
    /// <param name="command">Teklif detayları</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProposalCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    /// <summary>Teklifi günceller</summary>
    /// <param name="id">Teklif ID'si</param>
    /// <param name="command">Güncel teklif bilgileri</param>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProposalCommand command)
    {
        var proposal = await _mediator.Send(new GetProposalByIdQuery { Id = id });
        if (proposal == null) return NotFound();
        
        // Burada teklif sahibi kontrolü yapılacak
        
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>Teklifi geri çeker</summary>
    /// <param name="id">Teklif ID'si</param>
    [HttpPatch("{id:guid}/withdraw")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Withdraw(Guid id)
    {
        await _mediator.Send(new WithdrawProposalCommand { Id = id });
        return NoContent();
    }

    /// <summary>Teklifi kabul eder</summary>
    /// <param name="id">Teklif ID'si</param>
    [HttpPatch("{id:guid}/accept")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Accept(Guid id)
    {
        await _mediator.Send(new AcceptProposalCommand { Id = id });
        return NoContent();
    }

    /// <summary>Teklifi reddeder</summary>
    /// <param name="id">Teklif ID'si</param>
    [HttpPatch("{id:guid}/reject")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Reject(Guid id)
    {
        await _mediator.Send(new RejectProposalCommand { Id = id });
        return NoContent();
    }
}
