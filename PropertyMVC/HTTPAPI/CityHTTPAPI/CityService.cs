using Newtonsoft.Json;
using PropertyEntity;

namespace PropertyMVC.HTTPAPI.CityHTTPAPI
{
    public class CityService : ICityService
    {
        const string BaseUrl = "https://localhost:7066/api/City/";
        public async Task<IEnumerable<City>> GetAllCityServiceApi()
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
                        IEnumerable<City>? result = JsonConvert.DeserializeObject<IEnumerable<City>>(responseBody);
                        return result ?? Enumerable.Empty<City>();

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
