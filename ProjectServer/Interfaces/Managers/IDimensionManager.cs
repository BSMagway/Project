using ProjectCommon.Models;

namespace ProjectServer.Interfaces.Managers
{
    /// <summary>
    /// Интерфейс для работы с базой данных измерений.
    /// </summary>
    public interface IDimensionManager
    {
        /// <summary>
        /// Получить все измерения.
        /// </summary>
        /// <returns>Возвращает массив измерений.</returns>
        public Task<Dimension[]> GetAllAsync();

        /// <summary>
        /// Получить измерение по Id.
        /// </summary>
        /// <param name="dimensionId">Id измерения.</param>
        /// <returns>Возвращает измерение.</returns>
        public Task<Dimension> GetAsync(int? dimensionId);

        /// <summary>
        /// Добавить измерение в базу данных.
        /// </summary>
        /// <param name="dimension">Измерение.</param>
        /// <returns>Возвращает добавленное измерение.</returns>
        public Task<Dimension> AddAsync(Dimension dimension);

        /// <summary>
        /// Обновить информацию о измерении в базе данных.
        /// </summary>
        /// <param name="dimension">Новые данные измерения для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false если обновить не удалось.</returns>
        public Task<bool> UpdateAsync(Dimension dimension);

        /// <summary>
        /// Удаление измерения из базы данных по Id.
        /// </summary>
        /// <param name="dimensionId">Id измерения.</param>
        /// <returns>Возвращает true в случае успешного удаления и false если удалить не удалось.</returns>
        public Task<bool> RemoveAsync(int? dimensionId);
    }
}
