using GigFlow.Application.Features.Categories.Commands.CreateCategory;
using GigFlow.Application.Features.Categories.Commands.UpdateCategory;
using GigFlow.Application.Features.Categories.Commands.DeleteCategory;
using GigFlow.Application.Features.Categories.Queries.GetCategoryList;
using GigFlow.Application.Features.Categories.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GigFlow.Presentation.Controllers;

/// <summary>Kategori yönetimi işlemleri</summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator) => _mediator = mediator;

    /// <summary>Tüm kategorileri listeler</summary>
    /// <returns>Kategori listesi</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetCategoryListQuery());
        return Ok(result);
    }

    /// <summary>Belirtilen ID'ye sahip kategoriyi getirir</summary>
    /// <param name="id">Kategori ID'si</param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>Yeni kategori oluşturur</summary>
    /// <param name="command">Kategori bilgileri</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    /// <summary>Mevcut kategoriyi günceller</summary>
    /// <param name="id">Güncellenecek kategori ID'si</param>
    /// <param name="command">Yeni kategori bilgileri</param>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>Kategoriyi siler</summary>
    /// <param name="id">Silinecek kategori ID'si</param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteCategoryCommand { Id = id });
        return NoContent();
    }
}
