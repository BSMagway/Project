using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Gravel;

namespace ProjectServer.Controllers.MaterialTests.Gravel
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению дробимости щебня.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CrushabilityGravelTestController : ControllerBase
    {
        private readonly ICrushabilityGravelTestManager _crushabilityGravelTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению дробимости щебня.
        /// </summary>
        /// <param name="crushabilityGravelTestManager">Менеджер по работе с базой данных тестов по определению дробимости щебня.</param>
        public CrushabilityGravelTestController(ICrushabilityGravelTestManager crushabilityGravelTestManager)
        {
            _crushabilityGravelTestManager = crushabilityGravelTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению дробимости щебня по Id.
        /// </summary>
        /// <param name="id">Id теста по определению дробимости щебня.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению дробимости щебня.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _crushabilityGravelTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению дробимости щебня.
        /// </summary>
        /// <param name="crushabilityGravelTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CrushabilityGravelTest crushabilityGravelTest)
        {
            var model = await _crushabilityGravelTestManager.AddAsync(crushabilityGravelTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению дробимости щебня в базе данных.
        /// </summary>
        /// <param name="crushabilityGravelTest">Тест по определению дробимости щебня для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CrushabilityGravelTest crushabilityGravelTest)
        {
            var resultCrushabilityGravelTestUpdate = await _crushabilityGravelTestManager.UpdateAsync(crushabilityGravelTest);

            if (resultCrushabilityGravelTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению дробимости щебня в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultCrushabilityGravelTestRemove = await _crushabilityGravelTestManager.RemoveAsync(id);

            if (resultCrushabilityGravelTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
