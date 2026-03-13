using GigFlow.Application.Features.Skills.Commands.CreateSkill;
using GigFlow.Application.Features.Skills.Commands.UpdateSkill;
using GigFlow.Application.Features.Skills.Commands.DeleteSkill;
using GigFlow.Application.Features.Skills.Queries.GetSkillList;
using GigFlow.Application.Features.Skills.Queries.GetSkillById;
using GigFlow.Application.Features.Skills.Queries.GetSkillsByCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigFlow.Presentation.Controllers;

/// <summary>Yetenek (Skill) yönetimi işlemleri</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SkillsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkillsController(IMediator mediator) => _mediator = mediator;

    /// <summary>Tüm yetenekleri listeler</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetSkillListQuery());
        return Ok(result);
    }

    /// <summary>Belirtilen ID'ye sahip yeteneği getirir</summary>
    /// <param name="id">Yetenek ID'si</param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetSkillByIdQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>Belirli bir kategoriye ait yetenekleri listeler</summary>
    /// <param name="categoryId">Kategori ID'si</param>
    [HttpGet("by-category/{categoryId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByCategory(Guid categoryId)
    {
        var result = await _mediator.Send(new GetSkillsByCategoryQuery { CategoryId = categoryId });
        return Ok(result);
    }

    /// <summary>Yeni yetenek oluşturur</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSkillCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    /// <summary>Mevcut yeteneği günceller</summary>
    /// <param name="id">Güncellenecek yetenek ID'si</param>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSkillCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>Yeteneği siler</summary>
    /// <param name="id">Silinecek yetenek ID'si</param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteSkillCommand { Id = id });
        return NoContent();
    }
}
