using TonRadar.Fragment.Enum;

namespace TonRadar.Fragment.Test
{
    public class FragmentClientBaseTests
    {
        [Fact]
        public async Task GetHtml_MustWork()
        {
            var client = new FragmentNumbersClient();

            var content = await client.GetHtmlAsync(@"https://fragment.com/numbers");
            Assert.NotNull(content);
        }
    }
}