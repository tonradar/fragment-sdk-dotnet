using TonRadar.Fragment.Client;
using TonRadar.Fragment.Enum;

namespace TonRadar.Fragment.Test
{
    [Trait("GitHubActions", "Skip")]
    public class FragmentClientAuctionTests
    {
        [Fact]
        public async Task GetAuctionItems_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync()).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.OnAuction)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_EndingSoon_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.OnAuction, FragmentSortType.EndingSoon)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_PriceHighToLow_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.OnAuction, FragmentSortType.PriceHighToLow)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_PriceLowToHigh_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.OnAuction, FragmentSortType.PriceLowToHigh)).Any());
        }

        [Fact]
        public async Task GetAuctionItems_OnAuction_RecentlyListed_MustWork()
        {
            var client = new FragmentClient();

            Assert.True((await client.Numbers.GetAuctionItemsAsync(FragmentFilterType.OnAuction, FragmentSortType.RecentlyListed)).Any());
        }
    }
}