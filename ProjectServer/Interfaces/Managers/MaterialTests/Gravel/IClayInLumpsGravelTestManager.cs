using ProjectCommon.Models.Material.Gravel;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Gravel
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению содержания глины в комках в щебне.
    /// </summary>
    public interface IClayInLumpsGravelTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению содержания глины в комках в щебне из БД.
        /// </summary>
        /// <param name="clayInLumpsGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<ClayInLumpsGravelTest> GetAsync(int clayInLumpsGravelTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению содержания глины в комках в щебне в БД.
        /// </summary>
        /// <param name="clayInLumpsGravelTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<ClayInLumpsGravelTest> AddAsync(ClayInLumpsGravelTest clayInLumpsGravelTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению содержания глины в комках в щебне в БД.
        /// </summary>
        /// <param name="clayInLumpsGravelTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(ClayInLumpsGravelTest clayInLumpsGravelTest);

        /// <summary>
        /// Удаление протокола испытаний по определению содержания глины в комках в щебне из БД.
        /// </summary>
        /// <param name="clayInLumpsGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int clayInLumpsGravelTestId);
    }
}
