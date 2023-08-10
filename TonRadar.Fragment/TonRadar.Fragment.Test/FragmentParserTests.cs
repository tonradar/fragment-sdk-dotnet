using System.Reflection;
using TonRadar.Fragment.Model;
using TonRadar.Fragment.Test.Util;

namespace TonRadar.Fragment.Test;

public class FragmentParserTests
{
    [Fact]
    public async Task GetHtml_MustWork()
    {
        var parser = new FragmentHtmlParser();

        var content = await ResourceUtil.LoadResourceAsync("TonRadar.Fragment.Test.HtmlSample.numbers-auction-01.html");
        var items = parser.ExtractAuctionItems(content); 
        Assert.True(items.Any());

        Assert.True(items[0] is { Title: "+888 0000 0055", PriceInTon:6170, PriceInUsd:7713, EndTimeDescription:"3 days 18 hours" });
        Assert.True(items[1] is { Title: "+888 0000 5454" });
        Assert.True(items[434] is { Title: "+888 0732 5237" });
    }

   
}