using Microsoft.AspNetCore.Mvc;
using ProjectServer.Interfaces.Services;

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
        public async Task<IActionResult> GetAllAsync() => Ok(await _fullTestService.GetAsync());
    }
}
