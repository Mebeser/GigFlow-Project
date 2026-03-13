using GigFlow.Application.Features.Contracts.Commands.UpdateContractStatus;
using GigFlow.Application.Features.Contracts.Queries.GetContractById;
using GigFlow.Application.Features.Contracts.Queries.GetContractsByFreelancer;
using GigFlow.Application.Features.Contracts.Queries.GetContractsByClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigFlow.Presentation.Controllers;

/// <summary>Sözleşme (Contract) yönetimi işlemleri</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ContractsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContractsController(IMediator mediator) => _mediator = mediator;

    /// <summary>Belirtilen ID'ye sahip sözleşmeyi getirir</summary>
    /// <param name="id">Sözleşme ID'si</param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetContractByIdQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>Belirli bir freelancer'a ait sözleşmeleri listeler</summary>
    /// <param name="freelancerId">Freelancer ID'si</param>
    [HttpGet("by-freelancer/{freelancerId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByFreelancer(Guid freelancerId)
    {
        var result = await _mediator.Send(new GetContractsByFreelancerQuery { FreelancerId = freelancerId });
        return Ok(result);
    }

    /// <summary>Belirli bir müşteriye (client) ait sözleşmeleri listeler</summary>
    /// <param name="clientId">Müşteri ID'si</param>
    [HttpGet("by-client/{clientId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByClient(Guid clientId)
    {
        var result = await _mediator.Send(new GetContractsByClientQuery { ClientId = clientId });
        return Ok(result);
    }

    /// <summary>Sözleşme durumunu günceller</summary>
    /// <param name="id">Sözleşme ID'si</param>
    /// <param name="command">Yeni durum bilgileri</param>
    [HttpPatch("{id:guid}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateContractStatusCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }
}
