using TonRadar.Fragment.Enum;

namespace TonRadar.Fragment.Test
{
    [Trait("github-actions", "skip")]
    public class FragmentNumbersClientSoldTests
    {
        [Fact]
        public async Task GetAuctionItems_Sold_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.Sold)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_Sold_EndingSoon_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.Sold, FragmentSortType.EndingSoon)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_Sold_PriceHighToLow_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.Sold, FragmentSortType.PriceHighToLow)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_Sold_PriceLowToHigh_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.Sold, FragmentSortType.PriceLowToHigh)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_Sold_RecentlyListed_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.Sold, FragmentSortType.RecentlyListed)).Any());
        }
    }
}