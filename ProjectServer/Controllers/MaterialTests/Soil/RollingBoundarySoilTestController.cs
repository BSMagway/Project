using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Interfaces.Managers.MaterialTests.Soil;

namespace ProjectServer.Controllers.MaterialTests.Soil
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению границы раскатывания грунта.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RollingBoundarySoilTestController : ControllerBase
    {
        private readonly IRollingBoundarySoilTestManager _rollingBoundarySoilTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению границы раскатывания грунта.
        /// </summary>
        /// <param name="rollingBoundarySoilTest">Менеджер по работе с базой данных тестов по определению границы раскатывания грунта.</param>
        public RollingBoundarySoilTestController(IRollingBoundarySoilTestManager rollingBoundarySoilTest)
        {
            _rollingBoundarySoilTestManager = rollingBoundarySoilTest;
        }

        /// <summary>
        /// Получение из базы данных теста по определению границы раскатывания грунта по Id.
        /// </summary>
        /// <param name="id">Id теста по определению границы раскатывания грунта.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению границы раскатывания грунта.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _rollingBoundarySoilTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению границы раскатывания грунта.
        /// </summary>
        /// <param name="rollingBoundarySoilTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RollingBoundarySoilTest rollingBoundarySoilTest)
        {
            var model = await _rollingBoundarySoilTestManager.AddAsync(rollingBoundarySoilTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению границы раскатывания грунта в базе данных.
        /// </summary>
        /// <param name="rollingBoundarySoilTest">Тест по определению границы раскатывания грунта для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RollingBoundarySoilTest rollingBoundarySoilTest)
        {
            var resultRollingBoundarySoilTestUpdate = await _rollingBoundarySoilTestManager.UpdateAsync(rollingBoundarySoilTest);

            if (resultRollingBoundarySoilTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению границы раскатывания грунта в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultRollingBoundarySoilTestUpdate = await _rollingBoundarySoilTestManager.RemoveAsync(id);

            if (resultRollingBoundarySoilTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
