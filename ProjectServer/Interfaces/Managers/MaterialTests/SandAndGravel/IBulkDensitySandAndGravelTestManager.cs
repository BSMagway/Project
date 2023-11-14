using ProjectCommon.Models.Material.SandAndGravel;

namespace ProjectServer.Interfaces.Managers.MaterialTests.SandAndGravel
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению насыпной плотности ПГС.
    /// </summary>
    public interface IBulkDensitySandAndGravelTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению насыпной плотности ПГС из БД.
        /// </summary>
        /// <param name="bulkDensitySandAndGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<BulkDensitySandAndGravelTest> GetAsync(int bulkDensitySandAndGravelTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению насыпной плотности ПГС в БД.
        /// </summary>
        /// <param name="bulkDensitySandAndGravelTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<BulkDensitySandAndGravelTest> AddAsync(BulkDensitySandAndGravelTest bulkDensitySandAndGravelTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению насыпной плотности ПГС в БД.
        /// </summary>
        /// <param name="bulkDensitySandAndGravelTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(BulkDensitySandAndGravelTest bulkDensitySandAndGravelTest);

        /// <summary>
        /// Удаление протокола испытаний по определению насыпной плотности ПГС из БД.
        /// </summary>
        /// <param name="bulkDensitySandAndGravelTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int bulkDensitySandAndGravelTestId);
    }
}
