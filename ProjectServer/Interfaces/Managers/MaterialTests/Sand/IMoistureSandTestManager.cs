using ProjectCommon.Models.Material.Sand;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Sand
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению влажности песка.
    /// </summary>
    public interface IMoistureSandTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению влажности песка из БД.
        /// </summary>
        /// <param name="moistureSandTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<MoistureSandTest> GetAsync(int moistureSandTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению влажности песка в БД.
        /// </summary>
        /// <param name="moistureSandTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<MoistureSandTest> AddAsync(MoistureSandTest moistureSandTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению влажности песка в БД.
        /// </summary>
        /// <param name="moistureSandTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(MoistureSandTest moistureSandTest);

        /// <summary>
        /// Удаление протокола испытаний по определению влажности песка из БД.
        /// </summary>
        /// <param name="moistureSandTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int moistureSandTestId);
    }
}
