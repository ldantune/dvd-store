using DvdStore.Application.UseCases.Categories.GetById;
using DvdStore.Application.UseCases.Films.FilmCategory;
using DvdStore.Application.UseCases.Films.GetByFilmId;
using DvdStore.Communication.Responses;
using DvdStore.Communication.Responses.Film;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DvdStore.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FilmController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseFilmJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetByFilmIdUseCase useCase,
        [FromRoute] int id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpGet]
    [Route("category/{id}")]
    [ProducesResponseType(typeof(ResponseMoviesByCategoryJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IFilmCategoryUseCase useCase,
        [FromRoute] int id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }
}
