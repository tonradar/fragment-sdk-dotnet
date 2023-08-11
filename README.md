# Fragment .NET SDK
A C# library to read auctions in [fragment.com](fragment.com)
## Samples
```csharp
var client = new FragmentClient();
var auctionItems = await client.Numbers.GetAuctionsAsync(FilterType.OnAuction, SortType.EndingSoon);
var saleItems = await client.Numbers.GetAuctionsAsync(FilterType.ForSale);
var soldItems = await client.Numbers.GetAuctionsAsync(FilterType.Sold);
```
