using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Gravel;

namespace ProjectServer.Controllers.MaterialTests.Gravel
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению содержания дробленых зерен в щебне из гравия.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CrushedGrainsGravelTestController : ControllerBase
    {
        private readonly ICrushedGrainsGravelTestManager _crushedGrainsGravelTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению содержания дробленых зерен в щебне из гравия.
        /// </summary>
        /// <param name="crushedGrainsGravelTestManager">Менеджер по работе с базой данных тестов по определению содержания дробленых зерен в щебне из гравия.</param>
        public CrushedGrainsGravelTestController(ICrushedGrainsGravelTestManager crushedGrainsGravelTestManager)
        {
            _crushedGrainsGravelTestManager = crushedGrainsGravelTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению содержания дробленых зерен в щебне из гравия по Id.
        /// </summary>
        /// <param name="id">Id теста по определению содержания дробленых зерен в щебне из гравия.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению содержания дробленых зерен в щебне из гравия.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _crushedGrainsGravelTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению содержания дробленых зерен в щебне из гравия.
        /// </summary>
        /// <param name="crushedGrainsGravelTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CrushedGrainsGravelTest crushedGrainsGravelTest)
        {
            var model = await _crushedGrainsGravelTestManager.AddAsync(crushedGrainsGravelTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению содержания дробленых зерен в щебне из гравия в базе данных.
        /// </summary>
        /// <param name="crushedGrainsGravelTest">Тест по определению содержания дробленых зерен в щебне из гравия для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CrushedGrainsGravelTest crushedGrainsGravelTest)
        {
            var resultCrushedGrainsGravelTestUpdate = await _crushedGrainsGravelTestManager.UpdateAsync(crushedGrainsGravelTest);

            if (resultCrushedGrainsGravelTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению содержания дробленых зерен в щебне из гравия в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultCrushedGrainsGravelTestRemove = await _crushedGrainsGravelTestManager.RemoveAsync(id);

            if (resultCrushedGrainsGravelTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
