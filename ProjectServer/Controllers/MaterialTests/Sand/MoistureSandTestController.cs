using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Sand;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;

namespace ProjectServer.Controllers.MaterialTests.Sand
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению влажности песка.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MoistureSandTestController : ControllerBase
    {
        private readonly IMoistureSandTestManager _moistureSandTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению влажности песка.
        /// </summary>
        /// <param name="moistureSandTestManager">Менеджер по работе с базой данных тестов по определению влажности песка.</param>
        public MoistureSandTestController(IMoistureSandTestManager moistureSandTestManager)
        {
            _moistureSandTestManager = moistureSandTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению влажности песка по Id.
        /// </summary>
        /// <param name="id">Id теста по определению влажности песка.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению влажности песка.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _moistureSandTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению влажности песка.
        /// </summary>
        /// <param name="moistureSandTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MoistureSandTest moistureSandTest)
        {
            var model = await _moistureSandTestManager.AddAsync(moistureSandTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению влажности песка в базе данных.
        /// </summary>
        /// <param name="moistureSandTest">Тест по определению влажности песка для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MoistureSandTest moistureSandTest)
        {
            var resultMoistureSandTestUpdate = await _moistureSandTestManager.UpdateAsync(moistureSandTest);

            if (resultMoistureSandTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению влажности песка в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultMoistureSandTestRemove = await _moistureSandTestManager.RemoveAsync(id);

            if (resultMoistureSandTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
