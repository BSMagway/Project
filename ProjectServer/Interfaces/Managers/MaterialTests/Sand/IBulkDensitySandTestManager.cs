using ProjectCommon.Models.Material.Sand;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Sand
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению насыпной плотности песка.
    /// </summary>
    public interface IBulkDensitySandTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению насыпной плотности песка из БД.
        /// </summary>
        /// <param name="bulkDensitySandTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<BulkDensitySandTest> GetAsync(int bulkDensitySandTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению насыпной плотности песка в БД.
        /// </summary>
        /// <param name="bulkDensitySandTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<BulkDensitySandTest> AddAsync(BulkDensitySandTest bulkDensitySandTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению насыпной плотности песка в БД.
        /// </summary>
        /// <param name="bulkDensitySandTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(BulkDensitySandTest bulkDensitySandTest);

        /// <summary>
        /// Удаление протокола испытаний по определению насыпной плотности песка из БД.
        /// </summary>
        /// <param name="bulkDensitySandTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int bulkDensitySandTestId);
    }
}
