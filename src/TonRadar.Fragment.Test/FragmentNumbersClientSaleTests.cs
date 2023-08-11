using TonRadar.Fragment.Enum;

namespace TonRadar.Fragment.Test
{
    [Trait("GitHubActions", "Skip")]
    public class FragmentNumbersClientSaleTests
    {
        [Fact]
        public async Task GetAuctionItems_ForSale_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.ForSale)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_ForSale_EndingSoon_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.ForSale, FragmentSortType.EndingSoon)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_ForSale_PriceHighToLow_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.ForSale, FragmentSortType.PriceHighToLow)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_ForSale_PriceLowToHigh_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.ForSale, FragmentSortType.PriceLowToHigh)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_ForSale_RecentlyListed_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.ForSale, FragmentSortType.RecentlyListed)).Any());
        }
    }
}