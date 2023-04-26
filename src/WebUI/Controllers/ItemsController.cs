using CleanArchitecture.Application.Items.Queries.GetItem;
// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

// [Authorize]
public class ItemsController : ApiControllerBase
{

    /// <summary>
    /// Gets an Item.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /items/T8460-2W
    ///
    /// </remarks>
    /// <param name="id"></param>
    /// <response code="200">Returns the item</response>
    /// <response code="204">If the item is not found</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(object))]
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto>> Get(string id)
    {
        return await Mediator.Send(new GetItemsQuery { ItemNumber = id });
    }
}
