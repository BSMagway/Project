using ProjectCommon.Models.Material.Gravel;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Gravel
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
    /// </summary>
    public interface IFlakyGrainsGravelTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определениюсодержания зерен пластинчатой (лещадной) и игловатой формы из БД.
        /// </summary>
        /// <param name="flakyGrainsGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<FlakyGrainsGravelTest> GetAsync(int flakyGrainsGravelTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению содержания зерен пластинчатой (лещадной) и игловатой формы в БД.
        /// </summary>
        /// <param name="flakyGrainsGravelTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<FlakyGrainsGravelTest> AddAsync(FlakyGrainsGravelTest flakyGrainsGravelTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению содержания зерен пластинчатой (лещадной) и игловатой формы в БД.
        /// </summary>
        /// <param name="flakyGrainsGravelTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(FlakyGrainsGravelTest flakyGrainsGravelTest);

        /// <summary>
        /// Удаление протокола испытаний по определению содержания зерен пластинчатой (лещадной) и игловатой формы из БД.
        /// </summary>
        /// <param name="flakyGrainsGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int flakyGrainsGravelTestId);
    }
}
