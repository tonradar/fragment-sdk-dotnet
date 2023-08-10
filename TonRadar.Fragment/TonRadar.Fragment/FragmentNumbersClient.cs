using TonRadar.Fragment.Enum;
using TonRadar.Fragment.Model;

namespace TonRadar.Fragment;

public class FragmentNumbersClient : FragmentClientBase
{
    public async Task<List<AuctionItem>> GetAuctionItemsAsync(
        FragmentFilterType? filter = null,
        FragmentSortType? sort = null)
    {
        var queryParams = CreateQueryParams(filter, sort);
        var content = await GetHtmlAsync($"https://fragment.com/numbers?{queryParams}");
        var auctionItems = Parser.ExtractAuctionItems(content);
        return auctionItems;
    }

    
}