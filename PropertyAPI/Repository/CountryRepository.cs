using Microsoft.EntityFrameworkCore;
using PropertyAPI.IRepository;
using PropertyEntity;
using PropertyEntity.Data;

namespace PropertyAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
           private readonly ApplicationDbContext _applicationDbContext;
        public CountryRepository(ApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;
        }

        public async Task DeleteCountry(int countryId)
        {
            var countryToDelete = await _applicationDbContext.country.FindAsync(countryId);

            if (countryToDelete != null)
            {
                _applicationDbContext.country.Remove(countryToDelete);
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    

        public async Task<IEnumerable<Country>> GetAllCountry()
        {
            var countryList =await  _applicationDbContext.country.ToListAsync();
            
            return countryList;
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            var country = await _applicationDbContext.country.FindAsync(countryId);
            return country;
        }

        public async Task InsertCountry(Country country)
        {
            _applicationDbContext.country.Add(country);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateCountry(Country country)
        {
            _applicationDbContext.Entry(country).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
