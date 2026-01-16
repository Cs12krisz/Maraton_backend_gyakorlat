using MaratonValto.Models.Dtos;
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOneData(int id)
        {
            try
            {
                var response = await _futo.GetOneData(id);
                if (response is string)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutOneData(PutEredmenyDto putEredmenyDto)
        {
            try
            {
                var response = await _futo.PutOneData(putEredmenyDto);
                if (response is string)
                {
                    return NotFound(response);
                }
                return StatusCode(201, response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOneData(int id)
        {
            try
            {
                var response = await _futo.DeleteOneData(id);
                if (response is string)
                {
                    return NotFound(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("FemalesData")]
        public async Task<ActionResult> GetFemalesData()
        {
            try
            {
                var response = await _futo.GetFemalesData();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
