using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DvdStore.Application.UseCases.Actors.Get;
using DvdStore.Communication.Requests;
using DvdStore.Communication.Responses.Actors;
using Microsoft.AspNetCore.Mvc;

namespace DvdStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseActorsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetActors(
        [FromServices] IGetActorsUseCase useCase,
        [FromQuery] PaginationQuery paginationQuery)
    {
        if (paginationQuery.PageNumber <= 0 || paginationQuery.PageSize <= 0)
        {
            paginationQuery.PageNumber = 1;
            paginationQuery.PageSize = 10;
        }

        var response = await useCase.Execute(pageNumber: paginationQuery.PageNumber, pageSize: paginationQuery.PageSize);

        if(response.Actors.Any())
            return Ok(response);

        return NoContent();
        
    }


}
