using Newtonsoft.Json;
using PropertyEntity;
using PropertyEntity.ViewModel;
using System.Net.Http;

namespace PropertyMVC.HTTPAPI.AccountHTTPAPI
{
    public class AccountService : IAccountService
    {
        const string BaseUrl = "https://localhost:7066/api/Account/";
        public async Task<string> Login(LoginVM model)
        {
            using (HttpClient client = new HttpClient())
            {

                string apiUrl = BaseUrl ;
                try
                {
                    var data = new
                    {
                        key1 = model.Email,
                        key2 = model.Password
                    };
                    var queryString = $"?Email={data.key1}&Password={data.key2}";
                    var requestUrl = apiUrl + queryString;
                    var res = await client.GetAsync(requestUrl);

                    if (res.IsSuccessStatusCode)
                    {
                        var content = await res.Content.ReadAsStringAsync();
                        return content;
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
