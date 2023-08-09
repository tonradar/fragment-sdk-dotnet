namespace TonRadar.Fragment;

public class FragmentNumbersClient
{
    public HttpClient HttpClient { get; }

    public FragmentNumbersClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public FragmentNumbersClient() : this(new HttpClient())
    {

    }

    public async Task<string> GetHtmlAsync(string url)
    {
        using HttpResponseMessage response = HttpClient.GetAsync(url).Result;
        using HttpContent content = response.Content;
        string result = content.ReadAsStringAsync().Result;
        return result;
    }
}