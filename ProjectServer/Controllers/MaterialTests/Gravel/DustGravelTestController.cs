using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Gravel;

namespace ProjectServer.Controllers.MaterialTests.Gravel
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению содержания пылевидных и глинистых частиц в щебне.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DustGravelTestController : ControllerBase
    {
        private readonly IDustGravelTestManager _dustGravelTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        /// <param name="dustGravelTestManager">Менеджер по работе с базой данных тестов по определению содержания пылевидных и глинистых частиц в щебне.</param>
        public DustGravelTestController(IDustGravelTestManager dustGravelTestManager)
        {
            _dustGravelTestManager = dustGravelTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению содержания пылевидных и глинистых частиц в щебне по Id.
        /// </summary>
        /// <param name="id">Id теста по определению содержания пылевидных и глинистых частиц в щебне.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению содержания пылевидных и глинистых частиц в щебне.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _dustGravelTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        /// <param name="dustGravelTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DustGravelTest dustGravelTest)
        {
            var model = await _dustGravelTestManager.AddAsync(dustGravelTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению содержания пылевидных и глинистых частиц в щебне в базе данных.
        /// </summary>
        /// <param name="dustGravelTest">Тест по определению содержания пылевидных и глинистых частиц в щебне для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DustGravelTest dustGravelTest)
        {
            var resultDustGravelTestUpdate = await _dustGravelTestManager.UpdateAsync(dustGravelTest);

            if (resultDustGravelTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению содержания пылевидных и глинистых частиц в щебне в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultDustGravelTestRemove = await _dustGravelTestManager.RemoveAsync(id);

            if (resultDustGravelTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
