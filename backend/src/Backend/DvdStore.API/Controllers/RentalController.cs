using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DvdStore.Application.UseCases.Rental.Get;
using DvdStore.Communication.Requests;
using DvdStore.Communication.Responses.Rental;
using Microsoft.AspNetCore.Mvc;

namespace DvdStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        [HttpGet]
        [Route("customer-id/{id}")]
        [ProducesResponseType(typeof(ResponseRentalsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> GetRentalsByCustomerId(
            [FromServices] IGetRentalsByCustomerIdUseCase useCase,
            [FromQuery] PaginationQuery paginationQuery,
            [FromRoute] int id)
        {

            if (paginationQuery.PageNumber <= 0 || paginationQuery.PageSize <= 0)
            {
                paginationQuery.PageNumber = 1;
                paginationQuery.PageSize = 10;
            }

            var response = await useCase.ExecuteAsync(customerId: id, pageNumber: paginationQuery.PageNumber, pageSize: paginationQuery.PageSize);

            if (response.Rentals.Any())
                return Ok(response);

            return NoContent();

        }
    }
}