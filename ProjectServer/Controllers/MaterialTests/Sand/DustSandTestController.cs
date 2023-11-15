using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Sand;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;

namespace ProjectServer.Controllers.MaterialTests.Sand
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению содержания пылевидных и глинистых частиц в песке.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DustSandTestController : ControllerBase
    {
        private readonly IDustSandTestManager _dustSandTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        /// <param name="dustSandTestManager">Менеджер по работе с базой данных тестов по определению содержания пылевидных и глинистых частиц в песке.</param>
        public DustSandTestController(IDustSandTestManager dustSandTestManager)
        {
            _dustSandTestManager = dustSandTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению содержания пылевидных и глинистых частиц в песке по Id.
        /// </summary>
        /// <param name="id">Id теста по определению содержания пылевидных и глинистых частиц в песке.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению содержания пылевидных и глинистых частиц в песке.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _dustSandTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        /// <param name="dustSandTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DustSandTest dustSandTest)
        {
            var model = await _dustSandTestManager.AddAsync(dustSandTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению содержания пылевидных и глинистых частиц в песке в базе данных.
        /// </summary>
        /// <param name="dustSandTest">Тест по определению содержания пылевидных и глинистых частиц в песке для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DustSandTest dustSandTest)
        {
            var resultDustSandTestUpdate = await _dustSandTestManager.UpdateAsync(dustSandTest);

            if (resultDustSandTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению содержания пылевидных и глинистых частиц в песке в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultDustSandTestRemove = await _dustSandTestManager.RemoveAsync(id);

            if (resultDustSandTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
