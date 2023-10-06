using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Interfaces.Managers.MaterialTests.Soil;

namespace ProjectServer.Controllers.MaterialTests.Soil
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению границы текучести грунта.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class YieldLimitSoilTestController : ControllerBase
    {
        private readonly IYieldLimitSoilTestManager _yieldLimitSoilTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению границы текучести грунта.
        /// </summary>
        /// <param name="moistureSoilTestManager">Менеджер по работе с базой данных тестов по определению границы текучести грунта.</param>
        public YieldLimitSoilTestController(IYieldLimitSoilTestManager yieldLimitSoilTestManager)
        {
            _yieldLimitSoilTestManager = yieldLimitSoilTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению границы текучести грунта по Id.
        /// </summary>
        /// <param name="id">Id теста по определению границы текучести грунта.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению границы текучести грунта.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _yieldLimitSoilTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению границы текучести грунта.
        /// </summary>
        /// <param name="yieldLimitSoilTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] YieldLimitSoilTest yieldLimitSoilTest)
        {
            var model = await _yieldLimitSoilTestManager.AddAsync(yieldLimitSoilTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению границы текучести грунта в базе данных.
        /// </summary>
        /// <param name="yieldLimitSoilTest">Тест по определению границы текучести грунта для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] YieldLimitSoilTest yieldLimitSoilTest)
        {
            var resultYieldLimitSoilTestUpdate = await _yieldLimitSoilTestManager.UpdateAsync(yieldLimitSoilTest);

            if (resultYieldLimitSoilTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению границы текучести грунта в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultYieldLimitSoilTestRemove = await _yieldLimitSoilTestManager.RemoveAsync(id);

            if (resultYieldLimitSoilTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
