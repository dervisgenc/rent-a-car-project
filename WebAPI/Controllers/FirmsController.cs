using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmsController : ControllerBase
    {
        IFirmService _firmService;
        public FirmsController(IFirmService firmService)
        {
            _firmService = firmService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _firmService.GetFirms();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Firm firm)
        {
            var result = _firmService.Add(firm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _firmService.GetFirmById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
