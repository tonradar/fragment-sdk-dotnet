using TonRadar.Fragment.Enum;
using TonRadar.Fragment.Model;

namespace TonRadar.Fragment;

public class FragmentNumbersClient : FragmentClientBase
{
    public async Task<List<AuctionItem>> GetAuctionItemsAsync(
        FragmentFilterType filter = FragmentFilterType.OnAuction,
        FragmentSortType sort = FragmentSortType.PriceHighToLow)
    {
        var queryParams = CreateQueryParams(filter, sort);
        var content = await GetHtmlAsync($"https://fragment.com/numbers?{queryParams}");
        var auctionItems = filter switch
        {
            FragmentFilterType.OnAuction => Parser.ExtractAuctionItems(content),
            FragmentFilterType.ForSale => Parser.ExtractSaleItems(content),
            FragmentFilterType.Sold => Parser.ExtractSoldItems(content),
            _ => throw new InvalidOperationException($"Unknown filter type: {filter.ToString()}")
        };
        return auctionItems;
    }

    
}