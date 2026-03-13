using GigFlow.Application.Features.Reviews.Commands.CreateReview;
using GigFlow.Application.Features.Reviews.Queries.GetReviewsByContract;
using GigFlow.Application.Features.Reviews.Queries.GetReviewsByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigFlow.Presentation.Controllers;

/// <summary>Değerlendirme (Review) yönetimi işlemleri</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(IMediator mediator) => _mediator = mediator;

    /// <summary>Bir sözleşmeye ait tüm değerlendirmeleri listeler</summary>
    /// <param name="contractId">Sözleşme ID'si</param>
    [HttpGet("by-contract/{contractId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByContract(Guid contractId)
    {
        var result = await _mediator.Send(new GetReviewsByContractQuery { ContractId = contractId });
        return Ok(result);
    }

    /// <summary>Bir kullanıcı hakkında yapılan değerlendirmeleri listeler </summary>
    /// <param name="userId">Değerlendirilen kullanıcı ID'si</param>
    [HttpGet("by-user/{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByUser(Guid userId)
    {
        var result = await _mediator.Send(new GetReviewsByUserQuery { UserId = userId });
        return Ok(result);
    }

    /// <summary>Yeni değerlendirme oluşturur. Yalnızca Completed sözleşmeler için ve aynı kişi tekrar değerlendirme yapamaz.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateReviewCommand command)
    {
        var id = await _mediator.Send(command);
        return Created($"/api/reviews/{id}", id);
    }
}
