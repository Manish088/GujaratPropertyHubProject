using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyAPI.IService;
using PropertyAPI.Service;
using PropertyEntity;
using PropertyEntity.DTO;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly ICountryService _CountryService;
        private readonly IMapper _Mapper;
        public CountryController(ICountryService _CountryService, IMapper _Mapper)
        {
            this._CountryService = _CountryService;
            this._Mapper = _Mapper;
        }
        [HttpGet("getAllCountryDetails")]
        public async Task<IActionResult> GetAllCountryDetails()
        {
            try
            {
                var countries = await _CountryService.GetAllCountry();
                var countryDTOs = _Mapper.Map<List<CountryDTO>>(countries);

                return Ok(countryDTOs);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("deleteCountry/{countryId}")]
        public async Task<ActionResult> DeleteCountry(int countryId)
        {
            try
            {
                
                await _CountryService.DeleteCountry(countryId);

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("insertCountry")]
        public async Task<ActionResult> InsertCountry([FromBody] CountryDTO country)
        {
            try
            {

                 var CounrtyDto=_Mapper.Map<Country>(country);
                await _CountryService.InsertCountry(CounrtyDto);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("getCountryById/{countryId}")]
        public async Task<ActionResult<Country>> GetCountryById(int countryId)
        {
            try
            {
                var country = await _CountryService.GetCountryById(countryId);
                var countryIdDto=_Mapper.Map<CountryDTO>(country);
                if (countryIdDto == null)
                {
                    return NotFound(); 
                }

                return Ok(countryIdDto); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("updateCountry/{countryId}")]
        public async Task<ActionResult> UpdateCountry([FromBody] CountryDTO updatedCountry)
        {
            try
            {
                var CountryUpdateDto = _Mapper.Map<Country>(updatedCountry);
                await _CountryService.UpdateCountry(CountryUpdateDto);

                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}
