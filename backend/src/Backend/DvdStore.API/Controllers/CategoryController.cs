using DvdStore.Communication.Responses;
using DvdStore.Application.UseCases.Categories;
using Microsoft.AspNetCore.Mvc;

namespace DvdStore.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseCategoriesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetCategories(
        [FromServices] IGetCategoriesUseCase useCase)
    {
        var response = await useCase.Execute();

        if(response.Categories.Any())
              return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseCategoryJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetCategoryByIdUseCase useCase,
        [FromRoute] int id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }
}
