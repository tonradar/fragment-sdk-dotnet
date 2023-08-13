using System.Text;
using TonRadar.Fragment.Enum;
using TonRadar.Fragment.Parser;

namespace TonRadar.Fragment.Client;

public class FragmentClientBase
{
    public HttpClient HttpClient { get; }
    public FragmentHtmlParser Parser { get; }
    public FragmentClientBase(HttpClient httpClient)
    {
        HttpClient = httpClient;
        Parser = new FragmentHtmlParser();
    }

    public FragmentClientBase() : this(new HttpClient())
    {
    }

    public async Task<string> GetHtmlAsync(string url)
    {
        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        using HttpContent content = response.Content;
        string result = await content.ReadAsStringAsync();
        return result;
    }

    protected string GetFilterCode(FragmentFilterType filterType) => filterType switch
    {
        FragmentFilterType.ForSale => "sale",
        FragmentFilterType.OnAuction => "auction",
        FragmentFilterType.Sold => "sold",
        _ => throw new InvalidOperationException($"Unknown filter type: {filterType.ToString()}")
    };

    protected string GetSortCode(FragmentSortType sortType) => sortType switch
    {
        FragmentSortType.EndingSoon => "ending",
        FragmentSortType.PriceHighToLow => "price_desc",
        FragmentSortType.PriceLowToHigh => "price_asc",
        FragmentSortType.RecentlyListed => "listed",
        _ => throw new InvalidOperationException($"Unknown sort type: {sortType.ToString()}")
    };

    protected string CreateQueryParams(FragmentFilterType? filterType = null, FragmentSortType? sortType = null)
    {
        var queryParams = new List<string>();

        if (sortType is not null)
        {
            queryParams.Add($"sort={GetSortCode(sortType.Value)}");
        }

        if (filterType is not null)
        {
            queryParams.Add($"filter={GetFilterCode(filterType.Value)}");
        }

        return string.Join("&", queryParams);
    }


}