using ProjectCommon.Models.Material.Gravel;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Gravel
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению дробимости щебня.
    /// </summary>
    public interface ICrushabilityGravelTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению дробимости щебня из БД.
        /// </summary>
        /// <param name="crushabilityGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<CrushabilityGravelTest> GetAsync(int crushabilityGravelTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению дробимости щебня в БД.
        /// </summary>
        /// <param name="crushabilityGravelTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<CrushabilityGravelTest> AddAsync(CrushabilityGravelTest crushabilityGravelTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению дробимости щебня в БД.
        /// </summary>
        /// <param name="crushabilityGravelTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(CrushabilityGravelTest crushabilityGravelTest);

        /// <summary>
        /// Удаление протокола испытаний по определению дробимости щебня из БД.
        /// </summary>
        /// <param name="crushabilityGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int crushabilityGravelTestId);
    }
}
