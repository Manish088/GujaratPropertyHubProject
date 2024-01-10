using Microsoft.AspNetCore.Mvc;
using PropertyMVC.HTTPAPI.CityHTTPAPI;

namespace PropertyMVC.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        public IActionResult GetAllCityDetails()
        {
           
            return View();
        }
    }
}
