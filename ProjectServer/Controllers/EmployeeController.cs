using Microsoft.AspNetCore.Mvc;
using ProjectServer.Entities;
using ProjectServer.Services;
using ProjectServer.Services.Interface;

namespace ProjectServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public Employee Get([FromBody] Employee employee) => _employeeService.Get(employee);

        [HttpPost]
        [Route("add")]
        public Employee Add([FromBody] Employee employee) => _employeeService.Add(employee);


    }
}
