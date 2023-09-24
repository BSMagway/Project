using Microsoft.AspNetCore.Mvc;
using ProjectServer.Interfaces.Services;
using ProjectCommon.Models;

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

        [HttpGet]
        public IActionResult Get([FromQuery] Guid moistureSoilTestId) => Ok(_moistureSoilTestService.Get(moistureSoilTestId));

        [HttpPost]
        public IActionResult Add([FromBody] MoistureSoilTest moistureSoilTest) => Ok(_moistureSoilTestService.Add(moistureSoilTest));

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
