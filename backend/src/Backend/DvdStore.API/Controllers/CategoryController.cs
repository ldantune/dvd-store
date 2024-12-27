using DvdStore.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using DvdStore.Application.UseCases.Categories.Get;
using DvdStore.Application.UseCases.Categories.GetById;
using DvdStore.Application.UseCases.Categories.Register;
using DvdStore.Communication.Requests;
using DvdStore.Application.UseCases.Categories.Update;
using Microsoft.AspNetCore.Http.HttpResults;
using DvdStore.Application.UseCases.Categories.Delete;

namespace DvdStore.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseCategoriesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetCategories(
        [FromServices] IGetCategoriesUseCase useCase,
        [FromQuery] PaginationQuery paginationQuery)
    {
        if (paginationQuery.PageNumber <= 0 || paginationQuery.PageSize <= 0)
        {
            paginationQuery.PageNumber = 1;
            paginationQuery.PageSize = 10;
        }

        var response = await useCase.Execute(paginationQuery.PageNumber, paginationQuery.PageSize, paginationQuery.IsPaged);

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

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCategoryJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterCategoryUseCase useCase,
        [FromBody] RequestCategoryJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateCategoryUseCase useCase,
        [FromRoute] int id,
        [FromBody] RequestCategoryJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteCategoryUseCase useCase,
        [FromRoute] int id)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
