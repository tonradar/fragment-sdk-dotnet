using TonRadar.Fragment.Client;

namespace TonRadar.Fragment
{
    public class FragmentClient
    {
        private HttpClient HttpClient { get; }
        public FragmentNumbersClient Numbers { get; }
        public FragmentClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
            Numbers = new FragmentNumbersClient(httpClient);
        }
        
        public FragmentClient() : this(new HttpClient())
        {
            
        }
    }
}