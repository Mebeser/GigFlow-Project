using GigFlow.Application.Features.Milestones.Commands.CreateMilestone;
using GigFlow.Application.Features.Milestones.Commands.UpdateMilestoneStatus;
using GigFlow.Application.Features.Milestones.Queries.GetMilestonesByContract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigFlow.Presentation.Controllers;

/// <summary>Hakediş (Milestone) yönetimi işlemleri</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class MilestonesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MilestonesController(IMediator mediator) => _mediator = mediator;

    /// <summary>Bir sözleşmeye ait tüm hakedişleri listeler</summary>
    /// <param name="contractId">Sözleşme ID'si</param>
    [HttpGet("by-contract/{contractId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByContract(Guid contractId)
    {
        var result = await _mediator.Send(new GetMilestonesByContractQuery { ContractId = contractId });
        return Ok(result);
    }

    /// <summary>Sözleşmeye yeni hakediş ekler. Toplam tutar sözleşme tutarını geçemez.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateMilestoneCommand command)
    {
        var id = await _mediator.Send(command);
        return Created($"/api/milestones/{id}", id);
    }

    /// <summary>Hakediş durumunu günceller. Tüm hakedişler Approved olursa sözleşme otomatik kapanır.</summary>
    /// <param name="id">Güncellenecek hakediş ID'si</param>
    [HttpPatch("{id:guid}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateMilestoneStatusCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }
}
