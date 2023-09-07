using Microsoft.AspNetCore.Mvc;
using ProjectServer.Entities;
using ProjectServer.Services;
using ProjectServer.Services.Interface;

namespace ProjectServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FullTestsListController : ControllerBase
    {
        private readonly IFullTestsListService _fullTestService;

        public FullTestsListController(IFullTestsListService moistureSoilTestService)
        {
            _fullTestService = moistureSoilTestService;
        }

        [HttpGet]
        public List<FullTestsList> GetAll() => _fullTestService.Get();


    }
}
