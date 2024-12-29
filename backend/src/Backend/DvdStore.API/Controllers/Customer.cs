using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DvdStore.Application.UseCases.Customers.Get;
using DvdStore.Communication.Requests;
using DvdStore.Communication.Responses.Customer;
using Microsoft.AspNetCore.Mvc;

namespace DvdStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Customer : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseCustomersJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetActors(
    [FromServices] IGetCustomersUseCase useCase,
    [FromQuery] PaginationQuery paginationQuery)
    {
        if (paginationQuery.PageNumber <= 0 || paginationQuery.PageSize <= 0)
        {
            paginationQuery.PageNumber = 1;
            paginationQuery.PageSize = 10;
        }

        var response = await useCase.ExecuteAsync(pageNumber: paginationQuery.PageNumber, pageSize: paginationQuery.PageSize);

        if (response.Customers.Any())
            return Ok(response);

        return NoContent();

    }
}
