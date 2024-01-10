using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyAPI.IService;
using PropertyAPI.Service;
using PropertyEntity.DTO;
using PropertyEntity;
using AutoMapper;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        private readonly IMapper _Mapper;
        public StateController(IStateService _stateService, IMapper _Mapper)
        {
            this._stateService = _stateService;
            this._Mapper = _Mapper;
        }
        [HttpGet("getAllStateDetails")]
        public async Task<IActionResult> getAllStateDetails()
        {
            var GetStateList=await _stateService.GetAllState();
            return Ok();
        }
        [HttpDelete("DeleteState/{stateId}")]
        public async Task<IActionResult> DeleteState(int stateId)
        {
            try
            {

                await _stateService.DeleteState(stateId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("getStateById/{stateId}")]
        public async Task<ActionResult<State>> GetstateById(int stateId)
        {
            try
            {
                var state = await _stateService.GetStateById(stateId);
                var stateIdDto = _Mapper.Map<StateDTO>(state);
                if (stateIdDto == null)
                {
                    return NotFound();
                }

                return Ok(stateIdDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}
