namespace TonRadar.Fragment
{
    public class FragmentClient
    {
        public HttpClient HttpClient { get; }

        public FragmentClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        
        public FragmentClient() : this(new HttpClient())
        {
            
        }
    }
}