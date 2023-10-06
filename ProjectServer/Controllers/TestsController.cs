using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectServer.Interfaces.Managers;

namespace ProjectServer.Controllers
{
    /// <summary>
    /// Контролер для обработки запроса по получению короткого списка всех протоколов.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly ITestsManager _testManager;

        /// <summary>
        /// Конструктор контролера по получению короткого списка всех протоколов.
        /// </summary>
        /// <param name="moistureSoilTestService">Интерфейс по работе с базой данный для получения короткого списка всех протоколов.</param>
        public TestsController(ITestsManager testManager)
        {
            _testManager = testManager;
        }

        /// <summary>
        /// Получение короткого списка запросов.
        /// </summary>
        /// <returns>Статус запроса. В случае успешного запроса возвращается короткий список всех протоколов.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var model = await _testManager.GetAsync();

            if (model is null)
            {
                return BadRequest();
            }

            return Ok(model);
        }

    }
}
