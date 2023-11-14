using ProjectCommon.Models.Material.Gravel;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Gravel
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению содержания пылевидных и глинистых частиц в щебне.
    /// </summary>
    public interface IDustGravelTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определениюсодержания пылевидных и глинистых частиц в щебне из БД.
        /// </summary>
        /// <param name="dustGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<DustGravelTest> GetAsync(int dustGravelTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению содержания пылевидных и глинистых частиц в щебне в БД.
        /// </summary>
        /// <param name="dustGravelTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<DustGravelTest> AddAsync(DustGravelTest dustGravelTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению содержания пылевидных и глинистых частиц в щебне в БД.
        /// </summary>
        /// <param name="dustGravelTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(DustGravelTest dustGravelTest);

        /// <summary>
        /// Удаление протокола испытаний по определению содержания пылевидных и глинистых частиц в щебне из БД.
        /// </summary>
        /// <param name="dustGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int dustGravelTestId);
    }
}
