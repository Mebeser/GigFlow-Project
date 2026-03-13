using GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting;
using GigFlow.Application.Features.JobPostings.Commands.UpdateJobPosting;
using GigFlow.Application.Features.JobPostings.Commands.DeleteJobPosting;
using GigFlow.Application.Features.JobPostings.Queries.GetAllJobPostings;
using GigFlow.Application.Features.JobPostings.Queries.GetJobPostingById;
using GigFlow.Application.Features.JobPostings.Queries.GetJobPostingsByCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigFlow.Presentation.Controllers;

/// <summary>İş ilanı yönetimi işlemleri</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class JobPostingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobPostingsController(IMediator mediator) => _mediator = mediator;

    /// <summary>İş ilanlarını filtre ve sayfalama ile listeler</summary>
    /// <param name="query">Filtreleme ve sayfalama parametreleri (SearchTerm, CategoryId, PageNumber, PageSize)</param>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllJobPostingsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>Belirtilen ID'ye sahip iş ilanını getirir</summary>
    /// <param name="id">İlan ID'si</param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetJobPostingByIdQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>Belirli bir kategoriye ait iş ilanlarını listeler</summary>
    /// <param name="categoryId">Kategori ID'si</param>
    [HttpGet("by-category/{categoryId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByCategory(Guid categoryId)
    {
        var result = await _mediator.Send(new GetJobPostingsByCategoryQuery { CategoryId = categoryId });
        return Ok(result);
    }

    /// <summary>Yeni iş ilanı oluşturur. BudgetMax >= BudgetMin ve 1-10 arası skill zorunludur.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateJobPostingCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    /// <summary>Mevcut iş ilanını günceller. Tamamlanmış ilanlar güncellenemez.</summary>
    /// <param name="id">Güncellenecek ilan ID'si</param>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateJobPostingCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>İş ilanını siler</summary>
    /// <param name="id">Silinecek ilan ID'si</param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteJobPostingCommand { Id = id });
        return NoContent();
    }
}
