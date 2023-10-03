using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;

namespace ProjectServer.Controllers.MaterialTests.Gravel
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению влажности щебня.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MoistureGravelTestController : ControllerBase
    {
        private readonly IMoistureGravelTestManager _moistureGravelTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению влажности щебня.
        /// </summary>
        /// <param name="moistureGravelTestManager">Менеджер по работе с базой данных тестов по определению влажности щебня.</param>
        public MoistureGravelTestController(IMoistureGravelTestManager moistureGravelTestManager)
        {
            _moistureGravelTestManager = moistureGravelTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению влажности щебня по Id.
        /// </summary>
        /// <param name="id">Id теста по определению влажности щебня.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению влажности щебня.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _moistureGravelTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению влажности щебня.
        /// </summary>
        /// <param name="moistureGravelTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MoistureGravelTest moistureGravelTest)
        {
            var model = await _moistureGravelTestManager.AddAsync(moistureGravelTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению влажности щебня в базе данных.
        /// </summary>
        /// <param name="moistureGravelTest">Тест по определению влажности щебня для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MoistureGravelTest moistureGravelTest)
        {
            var resultMoistureGravelTestUpdate = await _moistureGravelTestManager.UpdateAsync(moistureGravelTest);

            if (resultMoistureGravelTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению влажности щебня в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultMoistureGravelTestRemove = await _moistureGravelTestManager.RemoveAsync(id);

            if (resultMoistureGravelTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
