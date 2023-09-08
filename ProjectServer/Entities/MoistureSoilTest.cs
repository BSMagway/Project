using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectServer.Entities
{
    /// <summary>
    /// Класс для хранения протоколв испытаний по определению влажности грунта
    /// </summary>
    public class MoistureSoilTest
    {
        /// <summary>
        /// Id в базе данных
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Порядковый номер теста (протокола)
        /// </summary>
        public int MoistureSoilTestId { get; set; }
        /// <summary>
        /// Название испытываемого материала 
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// Заказчик испытания
        /// </summary>
        public Guid CostumerId { get; set; }
        public Costumer CostumerTest { get; set; }
        /// <summary>
        /// Дата проведения испытания
        /// </summary>
        public string DateTest { get; set; }
        /// <summary>
        /// Нормативная документация на испытание
        /// </summary>
        public string DocumentTest { get; set; }
        /// <summary>
        /// Результат измерения массы влажного грунта с бюксой
        /// </summary>
        public Dimension SoilWetMassWithBox { get; set; }
        /// <summary>
        /// Результаты измерения массы сухого грунта с бюксой
        /// </summary>
        public Dimension SoilDryMassWithBox { get; set; }
        /// <summary>
        /// Результаты измерения массы бюксы
        /// </summary>
        public Dimension BoxMass { get; set; }
        /// <summary>
        /// Влажность пробы грунта
        /// </summary>
        public Dimension MoistureSoil { get; set; }
    }
}
