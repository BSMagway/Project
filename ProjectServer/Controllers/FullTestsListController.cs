using Microsoft.AspNetCore.Mvc;
using ProjectServer.Interfaces.Managers;

namespace ProjectServer.Controllers
{
    /// <summary>
    /// Контролер для обработки запроса по получению короткого списка всех протоколов.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FullTestsListController : ControllerBase
    {
        private readonly IFullShortListTestsManager _fullTestService;

        /// <summary>
        /// Конструктор контролера по получению короткого списка всех протоколов.
        /// </summary>
        /// <param name="moistureSoilTestService">Интерфейс по работе с базой данный для получения короткого списка всех протоколов.</param>
        public FullTestsListController(IFullShortListTestsManager moistureSoilTestService)
        {
            _fullTestService = moistureSoilTestService;
        }

        /// <summary>
        /// Получение короткого списка запросов.
        /// </summary>
        /// <returns>Статус запроса. В случае успешного запроса возвращается короткий список всех протоколов.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var model = await _fullTestService.GetAsync();

            if (model is null)
            {
                return BadRequest();
            }
            
            return Ok(model);
        }

    }
}
