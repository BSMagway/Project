using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models;
using ProjectServer.Interfaces.Managers;

namespace ProjectServer.Controllers
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению влажности грунта.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MoistureSoilTestController : ControllerBase
    {
        private readonly IMoistureSoilTestManager _moistureSoilTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению влажности грунта.
        /// </summary>
        /// <param name="moistureSoilTestManager">Менеджер по работе с базой данных тестов по определению влажности грунта.</param>
        public MoistureSoilTestController(IMoistureSoilTestManager moistureSoilTestManager)
        {
            _moistureSoilTestManager = moistureSoilTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению влажности грунта по Id.
        /// </summary>
        /// <param name="moistureSoilTestId">Id теста по определению влажности грунта.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению влажности грунта.</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int moistureSoilTestId)
        {
            var model = await _moistureSoilTestManager.GetAsync(moistureSoilTestId);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению влажности грунта.
        /// </summary>
        /// <param name="moistureSoilTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MoistureSoilTest moistureSoilTest)
        {
            var model = await _moistureSoilTestManager.AddAsync(moistureSoilTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению влажности грунта в базе данных.
        /// </summary>
        /// <param name="moistureSoilTest">Тест по определению влажности грунта для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MoistureSoilTest moistureSoilTest)
        {
            var resultMoistureSoilTestUpdate = await _moistureSoilTestManager.UpdateAsync(moistureSoilTest);

            if (resultMoistureSoilTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению влажности грунта в базе данных.
        /// </summary>
        /// <param name="moistureSoilTestId">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] int moistureSoilTestId)
        {
            var resultMoistureSoilTestRemove = await _moistureSoilTestManager.RemoveAsync(moistureSoilTestId);

            if (resultMoistureSoilTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
