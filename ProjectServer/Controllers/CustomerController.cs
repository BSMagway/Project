using Microsoft.AspNetCore.Mvc;
using ProjectServer.Interfaces.Services;
using ProjectCommon.Models;

// REST архитектура

namespace ProjectServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_customerService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromQuery] Guid CustomerId)
        {
            var customer = await _customerService.GetAsync(CustomerId);
            if (customer is null)
            {
                return NotFound();
            }

            return Ok(_customerService.GetAsync(CustomerId));
        }

        [HttpPost]
        public IActionResult Add([FromBody] Customer Customer) => Ok(_customerService.Add(Customer));

        [HttpPut]
        public IActionResult Update([FromBody] Customer Customer)
        {
            if (_customerService.Update(Customer))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Remove([FromQuery] Guid CustomerId)
        {
            if (_customerService.Remove(CustomerId))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
