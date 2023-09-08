using ProjectServer.Entities;

namespace ProjectServer.Services.Interface
{
    /// <summary>
    /// Интерфейс для работы с поротоколами по определению влажности грунта
    /// </summary>
    public interface IMoistureSoilTestService
    {
        /// <summary>
        /// Получение протокола испытаний по определению влажности грунта из БД
        /// </summary>
        /// <param name="moistureSoilTestId">Id протокола испытаний в базе данных</param>
        /// <returns></returns>
        public MoistureSoilTest Get(Guid moistureSoilTestId);
        /// <summary>
        /// Добавление нового протокола испытаний по определению влажности грунта в БД
        /// </summary>
        /// <param name="moistureSoilTest">Новый протокол испытаний для добавления</param>
        /// <returns></returns>
        public MoistureSoilTest Add(MoistureSoilTest moistureSoilTest);
        /// <summary>
        /// Обнавление данных протокола испытаний по определению влажности грунта в БД
        /// </summary>
        /// <param name="moistureSoilTest">Новая версия протокола испытаний для обновления</param>
        /// <returns></returns>
        public bool Update(MoistureSoilTest moistureSoilTest);
        /// <summary>
        /// Удаление протокола испытаний по определению влажности грунта из БД
        /// </summary>
        /// <param name="moistureSoilTestId">Id протокола испытаний в базе данных</param>
        /// <returns></returns>
        public bool Remove(Guid moistureSoilTestId);
    }
}
