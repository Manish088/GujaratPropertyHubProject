using Microsoft.AspNetCore.Mvc;
using PropertyMVC.HTTPAPI.CountryHTTPAPI;

namespace PropertyMVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryServiceAPI _countryServiceAPI;
        public CountryController(ICountryServiceAPI _countryServiceAPI)
        {
            this._countryServiceAPI = _countryServiceAPI;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCountryDetails()
        {
            var GetCountryList= await _countryServiceAPI.GetAllCountryServiceApi();
            return View(GetCountryList);
        }
    }
}
