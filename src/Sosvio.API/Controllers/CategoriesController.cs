using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sosvio.Application.Features.Categories.Commands.CreateCategory;
using Sosvio.Application.Features.Categories.Commands.UpdateCategory;
using Sosvio.Application.Features.Categories.Commands.DeleteCategory;
using Sosvio.Application.Features.Categories.Queries.GetCategoriesList;
using Sosvio.Application.Features.Categories.Queries.GetCategoryById;

namespace Sosvio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Tüm kategorileri listeler
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var query = new GetCategoriesListQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// ID'ye göre kategori getirir
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var query = new GetCategoryByIdQuery { Id = id };
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound(new { message = "Kategori bulunamadı" });

        return Ok(result);
    }

    /// <summary>
    /// Yeni kategori oluşturur
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var categoryId = await _mediator.Send(command);
        return CreatedAtAction(
            nameof(GetCategoryById),
            new { id = categoryId },
            new { id = categoryId });
    }

    /// <summary>
    /// Kategori günceller
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { message = "ID uyuşmazlığı" });

        try
        {
            await _mediator.Send(command);
            return NoContent(); // 204 No Content
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Kategori siler (soft delete)
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        try
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent(); // 204 No Content
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}