using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Material.Geotextile;
using ProjectCommon.Models.Material.Sand;
using ProjectCommon.Models.Material.SandAndGravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Geotextile;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;
using ProjectServer.Interfaces.Managers.MaterialTests.SandAndGravel;

namespace ProjectServer.Controllers.MaterialTests.Geotextile
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных тестов по определению фильтрации в плоскости геотекстильного полотна.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FiltrationPlaneGeotextileTestController : ControllerBase
    {
        private readonly IFiltrationPlaneGeotextileTestManager _filtrationPlaneGeotextileTestManager;

        /// <summary>
        /// Конструктор контролера по работе с базой данных тестов по определению фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        /// <param name="filtrationPlaneGeotextileTestManager">Менеджер по работе с базой данных тестов по определению фильтрации в плоскости геотекстильного полотна.</param>
        public FiltrationPlaneGeotextileTestController(IFiltrationPlaneGeotextileTestManager filtrationPlaneGeotextileTestManager)
        {
            _filtrationPlaneGeotextileTestManager = filtrationPlaneGeotextileTestManager;
        }

        /// <summary>
        /// Получение из базы данных теста по определению фильтрации в плоскости геотекстильного полотна по Id.
        /// </summary>
        /// <param name="id">Id теста по определению фильтрации в плоскости геотекстильного полотна.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым тестом по определению фильтрации в плоскости геотекстильного полотна.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _filtrationPlaneGeotextileTestManager.GetAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Добавление в базу данных теста по определению фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        /// <param name="filtrationPlaneGeotextileTest">Тест для добавления.</param>
        /// <returns>Статус запроса. В случае успешного добавления возвращается добавленный тест.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FiltrationPlaneGeotextileTest filtrationPlaneGeotextileTest)
        {
            var model = await _filtrationPlaneGeotextileTestManager.AddAsync(filtrationPlaneGeotextileTest);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Обновление данных теста по определению фильтрации в плоскости геотекстильного полотна в базе данных.
        /// </summary>
        /// <param name="filtrationPlaneGeotextileTest">Тест по определению фильтрации в плоскости геотекстильного полотна для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FiltrationPlaneGeotextileTest filtrationPlaneGeotextileTest)
        {
            var resultFiltrationPlaneGeotextileTestUpdate = await _filtrationPlaneGeotextileTestManager.UpdateAsync(filtrationPlaneGeotextileTest);

            if (resultFiltrationPlaneGeotextileTestUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление теста по определению фильтрации в плоскости геотекстильного полотна в базе данных.
        /// </summary>
        /// <param name="id">Id теста для удаления.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultFiltrationPlaneGeotextileTestRemove = await _filtrationPlaneGeotextileTestManager.RemoveAsync(id);

            if (resultFiltrationPlaneGeotextileTestRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
