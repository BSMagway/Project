using ProjectCommon.Models.Material.Gravel;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Gravel
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению содержания зерен слабых пород.
    /// </summary>
    public interface IWeakGrainsGravelTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению содержания зерен слабых пород из БД.
        /// </summary>
        /// <param name="weakGrainsGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<WeakGrainsGravelTest> GetAsync(int weakGrainsGravelTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению содержания зерен слабых пород в БД.
        /// </summary>
        /// <param name="weakGrainsGravelTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<WeakGrainsGravelTest> AddAsync(WeakGrainsGravelTest weakGrainsGravelTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению содержания зерен слабых пород в БД.
        /// </summary>
        /// <param name="weakGrainsGravelTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(WeakGrainsGravelTest weakGrainsGravelTest);

        /// <summary>
        /// Удаление протокола испытаний по определению содержания зерен слабых пород из БД.
        /// </summary>
        /// <param name="weakGrainsGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int weakGrainsGravelTestId);
    }
}
