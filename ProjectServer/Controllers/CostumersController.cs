using Microsoft.AspNetCore.Mvc;
using ProjectServer.Entities;
using ProjectServer.Services;
using ProjectServer.Services.Interface;

namespace ProjectServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostumersController : ControllerBase
    {

        private readonly ICostumersService _costumerService;

        public CostumersController(ICostumersService costumerService)
        {
            _costumerService = costumerService;
        }

        [HttpGet]
        [Route("all")]
        public Costumer[] GetAll() => _costumerService.GetAll();

        [HttpGet]
        public Costumer Get([FromQuery] Guid costumerId) => _costumerService.Get(costumerId);
        [HttpPost]
        public Costumer Add([FromBody] Costumer costumer) => _costumerService.Add(costumer);

        [HttpPut]
        public IActionResult Update([FromBody] Costumer costumer)
        {
            if (_costumerService.Update(costumer))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Remove([FromQuery] Guid costumerId)
        {
            if (_costumerService.Remove(costumerId))
            {
                return Ok();
            }

            return BadRequest();
        }


    }
}
