namespace TonRadar.Fragment;

public class FragmentClientBase
{
    public HttpClient HttpClient { get; }

    public FragmentClientBase(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public FragmentClientBase() : this(new HttpClient())
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