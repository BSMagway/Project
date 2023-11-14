using ProjectCommon.Models.Material.Gravel;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Gravel
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению насыпной плотности щебня.
    /// </summary>
    public interface IBulkDensityGravelTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению насыпной плотности щебня из БД.
        /// </summary>
        /// <param name="bulkDensityGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<BulkDensityGravelTest> GetAsync(int bulkDensityGravelTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению насыпной плотности щебня в БД.
        /// </summary>
        /// <param name="bulkDensityGravelTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<BulkDensityGravelTest> AddAsync(BulkDensityGravelTest bulkDensityGravelTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению насыпной плотности щебня в БД.
        /// </summary>
        /// <param name="bulkDensityGravelTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(BulkDensityGravelTest bulkDensityGravelTest);

        /// <summary>
        /// Удаление протокола испытаний по определению насыпной плотности щебня из БД.
        /// </summary>
        /// <param name="bulkDensityGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int bulkDensityGravelTestId);
    }
}
