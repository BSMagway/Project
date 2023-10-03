using ProjectCommon.Models.Material.Soil;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Soil
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению границы текучести грунта.
    /// </summary>
    public interface IYieldLimitSoilTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению границы текучести грунта из БД.
        /// </summary>
        /// <param name="yieldLimitSoilTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<YieldLimitSoilTest> GetAsync(int yieldLimitSoilTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению границы текучести грунта в БД.
        /// </summary>
        /// <param name="yieldLimitSoilTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<YieldLimitSoilTest> AddAsync(YieldLimitSoilTest yieldLimitSoilTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению границы текучести грунта в БД.
        /// </summary>
        /// <param name="yieldLimitSoilTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(YieldLimitSoilTest yieldLimitSoilTest);

        /// <summary>
        /// Удаление протокола испытаний по определению границы текучести грунта из БД.
        /// </summary>
        /// <param name="yieldLimitSoilTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int yieldLimitSoilTestId);
    }
}
