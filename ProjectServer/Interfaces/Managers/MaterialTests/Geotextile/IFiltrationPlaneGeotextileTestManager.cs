using ProjectCommon.Models.Material.Geotextile;

namespace ProjectServer.Interfaces.Managers.MaterialTests.Geotextile
{
    /// <summary>
    /// Интерфейс для работы с протоколами по определению насыпной плотности щебня.
    /// </summary>
    public interface IFiltrationPlaneGeotextileTestManager
    {
        /// <summary>
        /// Получение протокола испытаний по определению фильтрации в плоскости геотекстильного полотна из БД.
        /// </summary>
        /// <param name="filtrationPlaneGeotextileTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Протокол испытаний</returns>
        public Task<FiltrationPlaneGeotextileTest> GetAsync(int filtrationPlaneGeotextileTestId);

        /// <summary>
        /// Добавление нового протокола испытаний по определению фильтрации в плоскости геотекстильного полотна в БД.
        /// </summary>
        /// <param name="filtrationPlaneGeotextileTest">Новый протокол испытаний для добавления.</param>
        /// <returns>Возвращает добавленный протокол.</returns>
        public Task<FiltrationPlaneGeotextileTest> AddAsync(FiltrationPlaneGeotextileTest filtrationPlaneGeotextileTest);

        /// <summary>
        /// Обновление данных протокола испытаний по определению фильтрации в плоскости геотекстильного полотна в БД.
        /// </summary>
        /// <param name="filtrationPlaneGeotextileTest">Новая версия протокола испытаний для обновления.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> UpdateAsync(FiltrationPlaneGeotextileTest filtrationPlaneGeotextileTest);

        /// <summary>
        /// Удаление протокола испытаний по определению фильтрации в плоскости геотекстильного полотна из БД.
        /// </summary>
        /// <param name="filtrationPlaneGeotextileTestId">Id протокола испытаний в базе данных.</param>
        /// <returns>Возвращает true в случае успешного обновления и false не удачи.</returns>
        public Task<bool> RemoveAsync(int filtrationPlaneGeotextileTestId);
    }
}
