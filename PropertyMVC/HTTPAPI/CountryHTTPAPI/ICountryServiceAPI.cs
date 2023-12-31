using PropertyEntity;

namespace PropertyMVC.HTTPAPI.CountryHTTPAPI
{
    public interface ICountryServiceAPI
    {
        public Task<IEnumerable<Country>> GetAllCountryServiceApi();

        
    }
}
