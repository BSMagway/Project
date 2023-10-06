using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models;
using ProjectServer.Interfaces.Managers;

namespace ProjectServer.Controllers
{
    /// <summary>
    /// Контроллер для обработки запросов по работе с базой данных Заказчиков.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Конструктор контроллера для обработки запросов по работе с базой данных Заказчиков.
        /// </summary>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        /// <summary>
        /// Получение из базы данных и возврат пользователю всех заказчиков.
        /// </summary>
        /// <returns>Статус запроса. В случае успешного ответа со списком Заказчиков.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerManager.GetAllAsync();

            if (customers is null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        /// <summary>
        /// Получение из базы данных заказчика по Id.
        /// </summary>
        /// <param name="id">Id заказчика.</param>
        /// <returns>Статус запроса. В случае успешного ответа с запрашиваемым Заказчиком.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerManager.GetAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Добавление в базу данных Заказчика.
        /// </summary>
        /// <param name="customer">Заказчик для добавления в базу данных.</param>
        /// <returns>Статус запроса. При успешном добавлении возвращает добавленного Заказчика.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Customer customer)
        {
            var customerAdded = await _customerManager.AddAsync(customer);

            if (customerAdded is null)
            {
                NotFound();
            }

            return Ok(customerAdded);
        }

        /// <summary>
        /// Обновление данных Заказчика в базе данных.
        /// </summary>
        /// <param name="customer">Заказчик для которого необходимо внести изменения.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Customer customer)
        {
            var resultUpdate = await _customerManager.UpdateAsync(customer);

            if (resultUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Удаление заказчика из базы данных.
        /// </summary>
        /// <param name="customerId">Id удаляемого заказчика.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultRemove = await _customerManager.RemoveAsync(id);

            if (resultRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
