using ProjectCommon.Models;

namespace ProjectServer.Interfaces.Managers
{
    public interface IGenericManager<T>
    {
        /// <summary>
        /// Получить все объекты типа T из базы данных.
        /// </summary>
        /// <returns>Возвращает массив объектов типа T.</returns>
        public Task<T[]> GetAllAsync();

        /// <summary>
        /// Получить объект типа T по Id.
        /// </summary>
        /// <param name="id">Id объекта типа T.</param>
        /// <returns>Возвращает объект типа T.</returns>
        public Task<T> GetAsync(int id);

        /// <summary>
        /// Добавить объект типа T в базу данных.
        /// </summary>
        /// <param name="item">Объект типа T.</param>
        /// <returns>Возвращает добавленный объект типа T.</returns>
        public Task<T> AddAsync(T item);

        /// <summary>
        /// Обновить информацию о объекте типа T в базе данных.
        /// </summary>
        /// <param name="item">Объект типа T для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false если обновить не удалось.</returns>
        public Task<bool> UpdateAsync(T item);

        /// <summary>
        /// Удаление объекта типа T из базы данных по Id.
        /// </summary>
        /// <param name="id">Id объекта типа T.</param>
        /// <returns>Возвращает true в случае успешного удаления и false если удалить не удалось.</returns>
        public Task<bool> RemoveAsync(int id);
    }
}
