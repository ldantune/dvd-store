using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DvdStore.Application.UseCases.Inventory.GetByInventoryId;
using DvdStore.Communication.Responses;
using DvdStore.Communication.Responses.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace DvdStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseInventoryJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetByInventoryIdUseCase useCase,
            [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }
    }
}