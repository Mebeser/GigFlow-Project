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
public class ProposalsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProposalsController(IMediator mediator) => _mediator = mediator;

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

    /// <summary>Yeni teklif oluşturur. ProposedAmount > 0 ve geçerli bir iş ilanı zorunludur.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProposalCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    /// <summary>Beklemedeki teklifi günceller. Yalnızca Pending durumundaki teklifler güncellenebilir.</summary>
    /// <param name="id">Güncellenecek teklif ID'si</param>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProposalCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>Teklifi geri çeker. Kabul edilmiş teklifler geri çekilemez.</summary>
    /// <param name="id">Geri çekilecek teklif ID'si</param>
    [HttpPatch("{id:guid}/withdraw")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Withdraw(Guid id)
    {
        await _mediator.Send(new WithdrawProposalCommand { Id = id });
        return NoContent();
    }

    /// <summary>Teklifi kabul eder. Diğer tüm Pending teklifler otomatik olarak Rejected olur. Sözleşme otomatik oluşturulur.</summary>
    /// <param name="id">Kabul edilecek teklif ID'si</param>
    [HttpPatch("{id:guid}/accept")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Accept(Guid id)
    {
        await _mediator.Send(new AcceptProposalCommand { Id = id });
        return NoContent();
    }

    /// <summary>Teklifi reddeder. Yalnızca Pending durumundaki teklifler reddedilebilir.</summary>
    /// <param name="id">Reddedilecek teklif ID'si</param>
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
