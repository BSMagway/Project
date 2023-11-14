using ProjectCommon.Models.Material.Gravel;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Gravel
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению влажности щебня.
    /// </summary>
    public interface IMoistureGravelTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению влажности щебня из БД.
        /// </summary>
        /// <param name="moistureGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<MoistureSandTest> GetAsync(int moistureGravelTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению влажности щебня в БД.
        /// </summary>
        /// <param name="moistureGravelTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<MoistureSandTest> AddAsync(MoistureSandTest moistureGravelTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению влажности щебня в БД.
        /// </summary>
        /// <param name="moistureGravelTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(MoistureSandTest moistureGravelTest);

        /// <summary>
        /// Удаление протокола испытаний по определению влажности щебня из БД.
        /// </summary>
        /// <param name="moistureGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int moistureGravelTestId);
    }
}
