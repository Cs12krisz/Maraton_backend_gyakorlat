using MaratonValto.Models.Dtos;
using MaratonValto.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaratonValto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EredmenyController : ControllerBase
    {
        private readonly IEredmeny _eredmeny;

        public EredmenyController(IEredmeny eredmeny)
        {
            _eredmeny = eredmeny;
        }

        [HttpPost]
        public async Task<ActionResult> PostOneData(PostEredmenyDto postEredmenyDto)
        {
            try
            {
                var response = await _eredmeny.PostOneData(postEredmenyDto);

                if (response is string)
                {
                    return BadRequest(response);
                }

                return StatusCode(201, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
