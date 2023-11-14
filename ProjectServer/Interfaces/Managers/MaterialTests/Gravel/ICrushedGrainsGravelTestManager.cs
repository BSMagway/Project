using ProjectCommon.Models.Material.Gravel;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Gravel
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению содержания дробленых зерен в щебне из гравия.
    /// </summary>
    public interface ICrushedGrainsGravelTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению содержания дробленых зерен в щебне из гравия из БД.
        /// </summary>
        /// <param name="crushedGrainsGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<CrushedGrainsGravelTest> GetAsync(int crushedGrainsGravelTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению содержания дробленых зерен в щебне из гравия в БД.
        /// </summary>
        /// <param name="crushedGrainsGravelTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<CrushedGrainsGravelTest> AddAsync(CrushedGrainsGravelTest crushedGrainsGravelTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению содержания дробленых зерен в щебне из гравия в БД.
        /// </summary>
        /// <param name="crushedGrainsGravelTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(CrushedGrainsGravelTest crushedGrainsGravelTest);

        /// <summary>
        /// Удаление протокола испытаний по определению содержания дробленых зерен в щебне из гравия из БД.
        /// </summary>
        /// <param name="crushedGrainsGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int crushedGrainsGravelTestId);
    }
}
