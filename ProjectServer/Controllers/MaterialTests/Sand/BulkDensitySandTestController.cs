using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Sand;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;

namespace ProjectServer.Controllers.MaterialTests.Sand
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению насыпной плотности песка.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BulkDensitySandTestController : ControllerBase
    {
        private readonly IBulkDensitySandTestManager _bulkDensitySandTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению насыпной плотности песка.
        /// </summary>
        /// <param name="bulkDensitySandTestManager">Менеджер по работе с базой данных тестов по определению насыпной плотности песка.</param>
        public BulkDensitySandTestController(IBulkDensitySandTestManager bulkDensitySandTestManager)
        {
            _bulkDensitySandTestManager = bulkDensitySandTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению насыпной плотности песка по Id.
        /// </summary>
        /// <param name="id">Id теста по определению насыпной плотности песка.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению насыпной плотности песка.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _bulkDensitySandTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению насыпной плотности песка.
        /// </summary>
        /// <param name="bulkDensitySandTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BulkDensitySandTest bulkDensitySandTest)
        {
            var model = await _bulkDensitySandTestManager.AddAsync(bulkDensitySandTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению насыпной плотности песка в базе данных.
        /// </summary>
        /// <param name="bulkDensitySandTest">Тест по определению насыпной плотности песка для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BulkDensitySandTest bulkDensitySandTest)
        {
            var resultBulkDensitySandTestUpdate = await _bulkDensitySandTestManager.UpdateAsync(bulkDensitySandTest);

            if (resultBulkDensitySandTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению насыпной плотности песка в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultBulkDensitySandTestRemove = await _bulkDensitySandTestManager.RemoveAsync(id);

            if (resultBulkDensitySandTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
