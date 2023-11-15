using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Sand;
using ProjectCommon.Models.Material.SandAndGravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;
using ProjectServer.Interfaces.Managers.MaterialTests.SandAndGravel;

namespace ProjectServer.Controllers.MaterialTests.SandAndGravel
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению насыпной плотности ПГС.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BulkDensitySandAndGravelTestController : ControllerBase
    {
        private readonly IBulkDensitySandAndGravelTestManager _bulkDensitySandAndGravelTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению насыпной плотности ПГС.
        /// </summary>
        /// <param name="bulkDensitySandAndGravelTestManager">Менеджер по работе с базой данных тестов по определению насыпной плотности ПГС.</param>
        public BulkDensitySandAndGravelTestController(IBulkDensitySandAndGravelTestManager bulkDensitySandAndGravelTestManager)
        {
            _bulkDensitySandAndGravelTestManager = bulkDensitySandAndGravelTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению насыпной плотности ПГС по Id.
        /// </summary>
        /// <param name="id">Id теста по определению насыпной плотности ПГС.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению насыпной плотности ПГС.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _bulkDensitySandAndGravelTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению насыпной плотности ПГС.
        /// </summary>
        /// <param name="bulkDensitySandAndGravelTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BulkDensitySandAndGravelTest bulkDensitySandAndGravelTest)
        {
            var model = await _bulkDensitySandAndGravelTestManager.AddAsync(bulkDensitySandAndGravelTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению насыпной плотности ПГС в базе данных.
        /// </summary>
        /// <param name="bulkDensitySandAndGravelTest">Тест по определению насыпной плотности ПГС для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BulkDensitySandAndGravelTest bulkDensitySandAndGravelTest)
        {
            var resultBulkDensitySandAndGravelTestUpdate = await _bulkDensitySandAndGravelTestManager.UpdateAsync(bulkDensitySandAndGravelTest);

            if (resultBulkDensitySandAndGravelTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению насыпной плотности ПГС в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultBulkDensitySandAndGravelTestRemove = await _bulkDensitySandAndGravelTestManager.RemoveAsync(id);

            if (resultBulkDensitySandAndGravelTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
