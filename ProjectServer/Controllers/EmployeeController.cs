﻿using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models;
using ProjectServer.Interfaces.Services;

namespace ProjectServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeService;

        public EmployeeController(IEmployeeManager employeeService)
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