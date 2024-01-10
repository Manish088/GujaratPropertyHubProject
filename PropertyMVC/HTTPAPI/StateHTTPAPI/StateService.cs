using Newtonsoft.Json;
using PropertyEntity;

namespace PropertyMVC.HTTPAPI.StateHTTPAPI
{
    public class StateService : IStateService
    {
        const string BaseUrl = "https://localhost:7066/api/State/";
        public async Task<IEnumerable<State>> GetAllStateServiceApi()
        {
            using (HttpClient client = new HttpClient())
            {

                string apiUrl = BaseUrl + "getAllStateDetails";
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        IEnumerable<State>? result = JsonConvert.DeserializeObject<IEnumerable<State>>(responseBody);
                        return result ?? Enumerable.Empty<State>();

                    }
                    else
                    {
                        return null;

                    }
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
        }

        public async Task<State> GetStateById(int stateId)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}getStateById/{stateId}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        State result = JsonConvert.DeserializeObject<State>(responseBody);
                        return result;
                    }
                    else
                    {
                        
                        return null;
                    }
                }
                catch (HttpRequestException e)
                {
                    
                    throw e;
                }
            }
        }

    }
}
