[![NuGet version (TonRadar.Fragment)](https://img.shields.io/nuget/v/TonRadar.Fragment.svg?style=flat-square)](https://www.nuget.org/packages/TonRadar.Fragment/)
[![Build and Deploy](https://github.com/tonradar/fragment-sdk-dotnet/actions/workflows/build.yml/badge.svg)](https://github.com/tonradar/fragment-sdk-dotnet/actions/workflows/build.yml)
[![Build and Deploy](https://github.com/tonradar/fragment-sdk-dotnet/actions/workflows/publish-nuget.yml/badge.svg)](https://github.com/tonradar/fragment-sdk-dotnet/actions/workflows/publish-nuget.yml)

# TON Fragment .NET SDK
A C# library to read auctions in [fragment.com](fragment.com)
## How To Use
```csharp
// A unified client to work with fragment.com different auctions.
var client = new FragmentClient();

// Reading all auctions with EndingSoon filter.
var auctionItems = await client.Numbers.GetAuctionsItemsAsync(SortType.EndingSoon);
// Reading all for-sale items.
var saleItems = await client.Numbers.GetSaleItemsAsync(FilterType.ForSale);

// Reading all sold items.
var soldItems = await client.Numbers.GetSoldItemsAuctionsAsync(FilterType.Sold);
```

## How To Install
Install the package using:
```cmd
dotnet add package TonRadar.Fragment
```
