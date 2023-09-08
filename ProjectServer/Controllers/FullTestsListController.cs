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
        private readonly IFullShortListTestsService _fullTestService;

        public FullTestsListController(IFullShortListTestsService moistureSoilTestService)
        {
            _fullTestService = moistureSoilTestService;
        }

        [HttpGet]
        public List<FullShortListTests> GetAll() => _fullTestService.Get();


    }
}
