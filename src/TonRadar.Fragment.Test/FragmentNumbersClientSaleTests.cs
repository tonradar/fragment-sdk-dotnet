using TonRadar.Fragment.Client;
using TonRadar.Fragment.Enum;

namespace TonRadar.Fragment.Test
{
    [Trait("GitHubActions", "Skip")]
    public class FragmentClientSaleTests
    {
        [Fact]
        public async Task GetAuctionItems_ForSale_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.ForSale)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_ForSale_EndingSoon_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.ForSale, FragmentSortType.EndingSoon)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_ForSale_PriceHighToLow_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.ForSale, FragmentSortType.PriceHighToLow)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_ForSale_PriceLowToHigh_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.ForSale, FragmentSortType.PriceLowToHigh)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_ForSale_RecentlyListed_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.ForSale, FragmentSortType.RecentlyListed)).Any());
        }
    }
}