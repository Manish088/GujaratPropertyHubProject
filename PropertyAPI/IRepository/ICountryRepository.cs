using PropertyEntity;

namespace PropertyAPI.IRepository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountry();
        Task InsertCountry(Country country);
        Task DeleteCountry(int countryId);
        Task<Country> GetCountryById(int countryId);
        Task UpdateCountry(Country country);
        
    }
}
