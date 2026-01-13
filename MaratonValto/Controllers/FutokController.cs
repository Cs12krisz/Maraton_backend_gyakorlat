using MaratonValto.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaratonValto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutokController : ControllerBase
    {
        private readonly IFuto _futo;

        public FutokController(IFuto futo)
        {
            _futo = futo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllData()
        {
            try
            {
                var response = await _futo.GetAllData();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
