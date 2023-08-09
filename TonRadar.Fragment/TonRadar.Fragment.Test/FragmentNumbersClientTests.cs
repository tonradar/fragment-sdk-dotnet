namespace TonRadar.Fragment.Test
{
    public class FragmentNumbersClientTests
    {
        [Fact]
        public void GetHtml_MustWork()
        {
            var client = new FragmentNumbersClient();

            var content = client.GetHtmlAsync(@"https://fragment.com/numbers");
            Assert.NotNull(content);
        }
    }
}