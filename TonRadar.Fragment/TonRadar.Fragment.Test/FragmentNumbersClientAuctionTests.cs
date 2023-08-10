using TonRadar.Fragment.Enum;

namespace TonRadar.Fragment.Test
{
    public class FragmentNumbersClientAuctionTests
    {
        [Fact]
        public async Task GetAuctionItems_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync()).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.OnAuction)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_EndingSoon_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.OnAuction, FragmentSortType.EndingSoon)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_PriceHighToLow_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.OnAuction, FragmentSortType.PriceHighToLow)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_PriceLowToHigh_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.OnAuction, FragmentSortType.PriceLowToHigh)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_RecentlyListed_MustWork()
        {
            var client = new FragmentNumbersClient();

            Assert.True((await client.GetAuctionItemsAsync(FragmentFilterType.OnAuction, FragmentSortType.RecentlyListed)).Any());
        }
    }
}