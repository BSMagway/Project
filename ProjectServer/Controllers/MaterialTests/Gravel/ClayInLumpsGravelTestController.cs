using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Gravel;

namespace ProjectServer.Controllers.MaterialTests.Gravel
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению содержания глины в комках в щебне.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClayInLumpsGravelTestController : ControllerBase
    {
        private readonly IClayInLumpsGravelTestManager _clayInLumpsGravelTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению содержания глины в комках в щебне.
        /// </summary>
        /// <param name="clayInLumpsGravelTestManager">Менеджер по работе с базой данных тестов по определению содержания глины в комках в щебне.</param>
        public ClayInLumpsGravelTestController(IClayInLumpsGravelTestManager clayInLumpsGravelTestManager)
        {
            _clayInLumpsGravelTestManager = clayInLumpsGravelTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению содержания глины в комках в щебне по Id.
        /// </summary>
        /// <param name="id">Id теста по определению содержания глины в комках в щебне.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению содержания глины в комках в щебне.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _clayInLumpsGravelTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению содержания глины в комках в щебне.
        /// </summary>
        /// <param name="clayInLumpsGravelTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClayInLumpsGravelTest clayInLumpsGravelTest)
        {
            var model = await _clayInLumpsGravelTestManager.AddAsync(clayInLumpsGravelTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению содержания глины в комках в щебне в базе данных.
        /// </summary>
        /// <param name="clayInLumpsGravelTest">Тест по определению содержания глины в комках в щебне для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClayInLumpsGravelTest clayInLumpsGravelTest)
        {
            var resultClayInLumpsGravelTestUpdate = await _clayInLumpsGravelTestManager.UpdateAsync(clayInLumpsGravelTest);

            if (resultClayInLumpsGravelTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению содержания глины в комках в щебне в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultClayInLumpsGravelTestRemove = await _clayInLumpsGravelTestManager.RemoveAsync(id);

            if (resultClayInLumpsGravelTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
