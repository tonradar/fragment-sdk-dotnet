using System.Reflection;
using TonRadar.Fragment.Model;
using TonRadar.Fragment.Parser;
using TonRadar.Fragment.Test.Util;

namespace TonRadar.Fragment.Test;

public class FragmentParserTests
{
    [Fact]
    public async Task ParseAuctionItems_MustWork()
    {
        var parser = new FragmentHtmlParser();

        var content = await ResourceUtil.LoadResourceAsync("TonRadar.Fragment.Test.HtmlSample.numbers-auction-01.html");
        var items = parser.ExtractAuctionItems(content); 
        Assert.True(items.Any());

        Assert.True(items[0] is { Title: "+888 0000 0055", PriceInTon:6170, PriceInUsd:7713, EndTimeDescription:"3 days 18 hours" });
        Assert.True(items[1] is { Title: "+888 0000 5454" });
        Assert.True(items[434] is { Title: "+888 0732 5237" });
    }

    [Fact]
    public async Task ParseSaleItems_MustWork()
    {
        var parser = new FragmentHtmlParser();

        var content = await ResourceUtil.LoadResourceAsync("TonRadar.Fragment.Test.HtmlSample.numbers-sale-01.html");
        var items = parser.ExtractSaleItems(content);
        Assert.True(items.Any());

        Assert.True(items[0] is { Title: "+888 0612 7459", PriceInTon: 376, EndTimeDescription: "6 days 23 hours" });
        Assert.True(items[1] is { Title: "+888 0673 2591" });
        Assert.True(items[499] is { Title: "+888 0617 1035" });
    }

    [Fact]
    public async Task ParseSoldItems_MustWork()
    {
        var parser = new FragmentHtmlParser();

        var content = await ResourceUtil.LoadResourceAsync("TonRadar.Fragment.Test.HtmlSample.numbers-sold-01.html");
        var items = parser.ExtractSoldItems(content);
        Assert.True(items.Any());

        Assert.True(items[0] is { Title: "+888 8 888", PriceInTon: 300_000 });
        Assert.True(items[1] is { Title: "+888 8 177" });
        Assert.True(items[499] is { Title: "+888 0099 0011" });
    }


}