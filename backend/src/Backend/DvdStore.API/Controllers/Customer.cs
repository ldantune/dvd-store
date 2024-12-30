using DvdStore.Application.UseCases.Customers.Get;
using DvdStore.Application.UseCases.Customers.GetByCustomerId;
using DvdStore.Communication.Requests;
using DvdStore.Communication.Responses;
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

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseCustomerJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
    [FromServices] IGetByCustomerIdUseCase useCase,
    [FromRoute] int id)
    {
        var response = await useCase.ExecuteAsync(id);

        return Ok(response);
    }
}
