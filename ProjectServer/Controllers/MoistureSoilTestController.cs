using Microsoft.AspNetCore.Mvc;
using ProjectServer.Entities;
using ProjectServer.Services;
using ProjectServer.Services.Interface;

namespace ProjectServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoistureSoilTestController : ControllerBase
    {
        private readonly IMoistureSoilTestService _moistureSoilTestService;

        public MoistureSoilTestController(IMoistureSoilTestService moistureSoilTestService)
        {
            _moistureSoilTestService = moistureSoilTestService;
        }

        //[HttpGet]
        //public Note[] GetAll([FromQuery] Guid notepadId) => _noteService.GetAll(notepadId);

        [HttpPost]
        public MoistureSoilTest Add([FromBody] MoistureSoilTest moistureSoilTest) => _moistureSoilTestService.Add(moistureSoilTest);

        [HttpPut]
        public IActionResult Update([FromBody] MoistureSoilTest moistureSoilTest)
        {
            if (_moistureSoilTestService.Update(moistureSoilTest))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Remove([FromQuery] Guid moistureSoilTestId)
        {
            if (_moistureSoilTestService.Remove(moistureSoilTestId))
            {
                return Ok();
            }

            return BadRequest();
        }
    }


}

