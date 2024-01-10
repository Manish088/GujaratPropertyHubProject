using Microsoft.AspNetCore.Mvc;
using PropertyEntity;
using PropertyMVC.HTTPAPI.StateHTTPAPI;

namespace PropertyMVC.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
                _stateService = stateService;
        }
        [HttpGet]
        public async Task<IActionResult> GetStateAllDetails()
        {
            var result=await _stateService.GetAllStateServiceApi();
            return View(result);
        }
        public async Task<IActionResult> GetAllStateDetails()
        {
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetStateBuyId(int stateId)
        {
            try
            {
                State state = await _stateService.GetStateById(stateId);
                if (state != null)
                {
                    return View(state);
                }
                else
                {
                    
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
