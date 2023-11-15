using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;

namespace ProjectServer.Controllers.MaterialTests.Gravel
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению содержания зерен слабых пород.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeakGrainsGravelTestController : ControllerBase
    {
        private readonly IWeakGrainsGravelTestManager _weakGrainsGravelTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению содержания зерен слабых пород.
        /// </summary>
        /// <param name="weakGrainsGravelTestManager">Менеджер по работе с базой данных тестов по определениюсодержания зерен слабых пород.</param>
        public WeakGrainsGravelTestController(IWeakGrainsGravelTestManager weakGrainsGravelTestManager)
        {
            _weakGrainsGravelTestManager = weakGrainsGravelTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению содержания зерен слабых пород по Id.
        /// </summary>
        /// <param name="id">Id теста по определению содержания зерен слабых пород.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению содержания зерен слабых пород.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _weakGrainsGravelTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению содержания зерен слабых пород.
        /// </summary>
        /// <param name="weakGrainsGravelTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] WeakGrainsGravelTest weakGrainsGravelTest)
        {
            var model = await _weakGrainsGravelTestManager.AddAsync(weakGrainsGravelTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению содержания зерен слабых пород в базе данных.
        /// </summary>
        /// <param name="weakGrainsGravelTest">Тест по определению содержания зерен слабых пород для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WeakGrainsGravelTest weakGrainsGravelTest)
        {
            var resultWeakGrainsGravelTestUpdate = await _weakGrainsGravelTestManager.UpdateAsync(weakGrainsGravelTest);

            if (resultWeakGrainsGravelTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению содержания зерен слабых пород в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultWeakGrainsGravelTestRemove = await _weakGrainsGravelTestManager.RemoveAsync(id);

            if (resultWeakGrainsGravelTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
