using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PropertyEntity;
using System.Text.Json.Serialization;

namespace PropertyMVC.HTTPAPI.CountryHTTPAPI
{
    public class CountryServiceAPI : ICountryServiceAPI
    {
        const string BaseUrl= "https://localhost:7066/api/Country/";
        public async Task<IEnumerable<Country>> GetAllCountryServiceApi()
        {
            using (HttpClient client = new HttpClient())
            {
                
                string apiUrl = BaseUrl+"getAllCountryDetails";
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        IEnumerable<Country>? result = JsonConvert.DeserializeObject<IEnumerable<Country>>(responseBody);
                        return result ?? Enumerable.Empty<Country>();
                        
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
