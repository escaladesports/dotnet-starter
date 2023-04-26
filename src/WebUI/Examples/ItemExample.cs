using CleanArchitecture.Application.Items.Queries.GetItem;
using NSwag.Examples;

public class ItemExample : IExampleProvider<ItemDto>
{
    public ItemDto GetExample()
    {
        return new ItemDto()
        {
            ItemNumber = "T8460-2W",
            ItemTermType = "W",
            ItemType = "P",
            ItemDescription = "STG SPACE SAVER WOODGRAIN",
            ItemProdLine = 60,
            ItemWeight = 76.500M
        };
    }
}