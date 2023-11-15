using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;

namespace ProjectServer.Controllers.MaterialTests.Gravel
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению насыпной плотности щебня.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BulkDensityGravelTestController : ControllerBase
    {
        private readonly IBulkDensityGravelTestManager _bulkDensityGravelTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению насыпной плотности щебня.
        /// </summary>
        /// <param name="bulkDensityGravelTestManager">Менеджер по работе с базой данных тестов по определению насыпной плотности щебня.</param>
        public BulkDensityGravelTestController(IBulkDensityGravelTestManager bulkDensityGravelTestManager)
        {
            _bulkDensityGravelTestManager = bulkDensityGravelTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению насыпной плотности щебня по Id.
        /// </summary>
        /// <param name="id">Id теста по определению насыпной плотности щебня.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению насыпной плотности щебня.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _bulkDensityGravelTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению насыпной плотности щебня.
        /// </summary>
        /// <param name="bulkDensityGravelTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BulkDensityGravelTest bulkDensityGravelTest)
        {
            var model = await _bulkDensityGravelTestManager.AddAsync(bulkDensityGravelTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению насыпной плотности щебня в базе данных.
        /// </summary>
        /// <param name="bulkDensityGravelTest">Тест по определению насыпной плотности щебня для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BulkDensityGravelTest bulkDensityGravelTest)
        {
            var resultBulkDensityGravelTestUpdate = await _bulkDensityGravelTestManager.UpdateAsync(bulkDensityGravelTest);

            if (resultBulkDensityGravelTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению насыпной плотности щебня в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultBulkDensityGravelTestRemove = await _bulkDensityGravelTestManager.RemoveAsync(id);

            if (resultBulkDensityGravelTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
