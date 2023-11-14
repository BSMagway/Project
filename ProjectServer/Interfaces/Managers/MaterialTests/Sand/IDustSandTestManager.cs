using ProjectCommon.Models.Material.Sand;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Sand
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению содержания пылевидных и глинистых частиц в песке.
    /// </summary>
    public interface IDustSandTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определениюсодержания пылевидных и глинистых частиц в песке из БД.
        /// </summary>
        /// <param name="dustSandTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<DustSandTest> GetAsync(int dustSandTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению содержания пылевидных и глинистых частиц в песке в БД.
        /// </summary>
        /// <param name="dustSandTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<DustSandTest> AddAsync(DustSandTest dustSandTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению содержания пылевидных и глинистых частиц в песке в БД.
        /// </summary>
        /// <param name="dustSandTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(DustSandTest dustSandTest);

        /// <summary>
        /// Удаление протокола испытаний по определению содержания пылевидных и глинистых частиц в песке из БД.
        /// </summary>
        /// <param name="dustSandTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int dustSandTestId);
    }
}
