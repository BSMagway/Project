using ProjectCommon.Models.Material.Soil;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Soil
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению влажности грунта.
    /// </summary>
    public interface IMoistureSoilTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению влажности грунта из БД.
        /// </summary>
        /// <param name="moistureSoilTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<MoistureGravelTest> GetAsync(int moistureSoilTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению влажности грунта в БД.
        /// </summary>
        /// <param name="moistureSoilTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<MoistureGravelTest> AddAsync(MoistureGravelTest moistureSoilTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению влажности грунта в БД.
        /// </summary>
        /// <param name="moistureSoilTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(MoistureGravelTest moistureSoilTest);

        /// <summary>
        /// Удаление протокола испытаний по определению влажности грунта из БД.
        /// </summary>
        /// <param name="moistureSoilTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int moistureSoilTestId);
    }
}
