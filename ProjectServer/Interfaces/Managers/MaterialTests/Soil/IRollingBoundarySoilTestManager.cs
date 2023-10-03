using ProjectCommon.Models.Material.Soil;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Soil
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению границы раскатывания грунта.
    /// </summary>
    public interface IRollingBoundarySoilTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению границы раскатывания грунта из БД.
        /// </summary>
        /// <param name="rollingBoundarySoilTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<RollingBoundarySoilTest> GetAsync(int rollingBoundarySoilTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению границы раскатывания грунта в БД.
        /// </summary>
        /// <param name="rollingBoundarySoilTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<RollingBoundarySoilTest> AddAsync(RollingBoundarySoilTest rollingBoundarySoilTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению границы раскатывания грунта в БД.
        /// </summary>
        /// <param name="rollingBoundarySoilTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(RollingBoundarySoilTest rollingBoundarySoilTest);

        /// <summary>
        /// Удаление протокола испытаний по определению границы раскатывания грунта из БД.
        /// </summary>
        /// <param name="rollingBoundarySoilTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int rollingBoundarySoilTestId);
    }
}
