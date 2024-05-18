using CleanArchitecture.Application.Items.Queries.GetItem;

namespace CleanArchitecture.Web.Endpoints;

public class Items : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetItem, "{id}");
    }

    public Task<ItemDto> GetItem(ISender sender, string id)
    {
        return sender.Send(new GetItemsQuery { ItemNumber = id });
    }

}
