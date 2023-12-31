using PropertyEntity;

namespace PropertyAPI.IService
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountry();
        Task InsertCountry(Country country); 
        Task<Country> GetCountryById(int countryId);
        Task UpdateCountry(Country country);
        Task DeleteCountry(int CountryId);
       
        
    }
}
