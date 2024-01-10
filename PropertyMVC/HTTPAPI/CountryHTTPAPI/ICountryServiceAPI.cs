using PropertyEntity;

namespace PropertyMVC.HTTPAPI.CountryHTTPAPI
{
    public interface ICountryServiceAPI
    {
        public Task<IEnumerable<Country>> GetAllCountryServiceApi();
        
        Task<Country> GetCountryById(int id);
        Task<int> CreateCountryServiceApi(Country country);
        Task<bool> UpdateCountryServiceApi(Country updatedCountry);
        Task<bool> DeleteCountryServiceApi(int id);

    }
}
