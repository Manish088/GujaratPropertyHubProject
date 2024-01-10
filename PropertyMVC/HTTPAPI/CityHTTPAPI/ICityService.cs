using PropertyEntity;

namespace PropertyMVC.HTTPAPI.CityHTTPAPI
{
    public interface ICityService
    {
        public Task<IEnumerable<City>> GetAllCityServiceApi();
    }
}
