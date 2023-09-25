using ProjectCommon.Models;

namespace ProjectServer.Interfaces.Managers

{
    /// <summary>
    /// Интерфейс для работы с базой данных заказчиков.
    /// </summary>
    public interface ICustomerManager
    {
        /// <summary>
        /// Получить всех заказчиков.
        /// </summary>
        /// <returns>Возвращает массив заказчиков.</returns>
        public Task<Customer[]> GetAllAsync();

        /// <summary>
        /// Получить заказчика по Id.
        /// </summary>
        /// <param name="customerId">Id заказчика.</param>
        /// <returns>Возвращает заказчика.</returns>
        public Task<Customer> GetAsync(int customerId);

        /// <summary>
        /// Добавить заказчика в базу данных.
        /// </summary>
        /// <param name="customer">Заказчик.</param>
        /// <returns>Возвращает добавленного заказчика.</returns>
        public Task<Customer> AddAsync(Customer customer);

        /// <summary>
        /// Обновить информацию о заказчике в базе данных.
        /// </summary>
        /// <param name="customer">Новые данные заказчика для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false если обновить не удалось.</returns>
        public Task<bool> UpdateAsync(Customer customer);

        /// <summary>
        /// Удаление заказчика из базы данных по Id.
        /// </summary>
        /// <param name="customerId">Id заказчика.</param>
        /// <returns>Возвращает true в случае успешного удаления и false если удалить не удалось.</returns>
        public Task<bool> RemoveAsync(int customerId);
    }
}
