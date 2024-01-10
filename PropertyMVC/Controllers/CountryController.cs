using Microsoft.AspNetCore.Mvc;
using PropertyEntity;
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
       
        public IActionResult CountryInsert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CountryInsert(Country country)
        {
            if (ModelState.IsValid)
            {
                await _countryServiceAPI.CreateCountryServiceApi(country);
            }
            return View(country);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCountry(Country updatedCountry)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await _countryServiceAPI.UpdateCountryServiceApi(updatedCountry);

                if (isUpdated)
                {
                    return RedirectToAction("GetAllCountryDetails");
                }
                else
                {
                    ModelState.AddModelError("", "Country update failed");
                }
            }
            return View("CountryDetails", updatedCountry); 
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCountry(int CountryId)
        {
            bool isDeleted = await _countryServiceAPI.DeleteCountryServiceApi(CountryId);

            if (isDeleted)
            {
                return RedirectToAction("GetAllCountryDetails");
            }
            else
            {
                ModelState.AddModelError("", "Country deletion failed");
                return RedirectToAction("GetAllCountryDetails");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCountryById(int CountryId)
        {
            var country = await _countryServiceAPI.GetCountryById(CountryId);

            if (country != null)
            {
                return View(country);
            }
            else
            {
              
                return NotFound();
            }
        }
    }
}
