using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Gravel;

namespace ProjectServer.Controllers.MaterialTests.Gravel
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FlakyGrainsGravelTestController : ControllerBase
    {
        private readonly IFlakyGrainsGravelTestManager _flakyGrainsGravelTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        /// <param name="flakyGrainsGravelTestManager">Менеджер по работе с базой данных тестов по определению содержания зерен пластинчатой (лещадной) и игловатой формы.</param>
        public FlakyGrainsGravelTestController(IFlakyGrainsGravelTestManager flakyGrainsGravelTestManager)
        {
            _flakyGrainsGravelTestManager = flakyGrainsGravelTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы по Id.
        /// </summary>
        /// <param name="id">Id теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению содержания зерен пластинчатой (лещадной) и игловатой формы.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _flakyGrainsGravelTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        /// <param name="flakyGrainsGravelTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FlakyGrainsGravelTest flakyGrainsGravelTest)
        {
            var model = await _flakyGrainsGravelTestManager.AddAsync(flakyGrainsGravelTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы в базе данных.
        /// </summary>
        /// <param name="flakyGrainsGravelTest">Тест по определению содержания зерен пластинчатой (лещадной) и игловатой формы для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FlakyGrainsGravelTest flakyGrainsGravelTest)
        {
            var resultFlakyGrainsGravelTestUpdate = await _flakyGrainsGravelTestManager.UpdateAsync(flakyGrainsGravelTest);

            if (resultFlakyGrainsGravelTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultFlakyGrainsGravelTestRemove = await _flakyGrainsGravelTestManager.RemoveAsync(id);

            if (resultFlakyGrainsGravelTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
