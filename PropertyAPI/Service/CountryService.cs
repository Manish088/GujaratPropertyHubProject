using PropertyAPI.IRepository;
using PropertyAPI.IService;
using PropertyEntity;

namespace PropertyAPI.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            this._countryRepository = countryRepository;
        }

        public Task DeleteCountry(int CountryId)
        {
            return _countryRepository.DeleteCountry(CountryId);
        }

        public Task<IEnumerable<Country>> GetAllCountry()
        {
            return _countryRepository.GetAllCountry();
        }

        public Task<Country> GetCountryById(int countryId)
        {
            return _countryRepository.GetCountryById(countryId);
        }

        public Task InsertCountry(Country country)
        {
            return _countryRepository.InsertCountry(country);
        }

        public Task UpdateCountry(Country country)
        {
            return (_countryRepository.UpdateCountry(country));
        }
    }
}
