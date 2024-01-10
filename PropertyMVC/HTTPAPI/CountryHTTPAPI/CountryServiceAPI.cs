using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PropertyEntity;
using System.Text;
using System.Text.Json.Serialization;

namespace PropertyMVC.HTTPAPI.CountryHTTPAPI
{
    public class CountryServiceAPI : ICountryServiceAPI
    {
        const string BaseUrl = "https://localhost:7066/api/Country/";
        public async Task<IEnumerable<Country>> GetAllCountryServiceApi()
        {
            using (HttpClient client = new HttpClient())
            {

                string apiUrl = BaseUrl + "getAllCountryDetails";
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

        public async Task<int> CreateCountryServiceApi(Country country)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = BaseUrl + "InsertCountry";

                try
                {
                    string jsonContent = JsonConvert.SerializeObject(country);
                    StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Assuming the response contains the newly created object or its ID
                        int createdCountryId = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                        return createdCountryId;
                    }
                    else
                    {
                        return -1; // Or throw an exception based on your requirements
                    }
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
        }

        public async Task<bool> UpdateCountryServiceApi(Country updatedCountry)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}UpdateCountry/updatedCountry";

                try
                {
                    string jsonContent = JsonConvert.SerializeObject(updatedCountry);
                    StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    return response.IsSuccessStatusCode;
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
        }

        public async Task<bool> DeleteCountryServiceApi(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}DeleteCountry/{id}";

                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    return response.IsSuccessStatusCode;
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }

        }
        public async Task<Country> GetCountryById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}getCountryDetails/{id}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Country result = JsonConvert.DeserializeObject<Country>(responseBody);
                        return result;
                    }
                    else
                    {
                        // Handle error
                        throw new Exception($"Failed to get country by ID {id}. Status code: {response.StatusCode}");
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
