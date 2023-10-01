using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Interfaces.Managers.MaterialTests.Soil;

namespace ProjectServer.Controllers.MaterialTests.Soil
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению влажности грунта.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DensitySoilTestController : ControllerBase
    {
        private readonly IDensitySoilTestManager _densitySoilTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению влажности грунта.
        /// </summary>
        /// <param name="moistureSoilTestManager">Менеджер по работе с базой данных тестов по определению влажности грунта.</param>
        public DensitySoilTestController(IDensitySoilTestManager densitySoilTestManager)
        {
            _densitySoilTestManager = densitySoilTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению влажности грунта по Id.
        /// </summary>
        /// <param name="moistureSoilTestId">Id теста по определению влажности грунта.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению влажности грунта.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _densitySoilTestManager.GetAsync(id);

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
        public async Task<IActionResult> Add([FromBody] DensitySoilTest densitySoilTest)
        {
            var model = await _densitySoilTestManager.AddAsync(densitySoilTest);

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
        public async Task<IActionResult> Update([FromBody] DensitySoilTest densitySoilTest)
        {
            var resultDensitySoilTestUpdate = await _densitySoilTestManager.UpdateAsync(densitySoilTest);

            if (resultDensitySoilTestUpdate)
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultDensitySoilTestRemove = await _densitySoilTestManager.RemoveAsync(id);

            if (resultDensitySoilTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
