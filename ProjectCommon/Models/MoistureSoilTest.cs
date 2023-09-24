namespace ProjectCommon.Models
{
    /// <summary>
    /// Класс для хранения протоколв испытаний по определению влажности грунта.
    /// </summary>
    public class MoistureSoilTest
    {
        /// <summary>
        /// Id в базе данных.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Порядковый номер теста (протокола).
        /// </summary>
        public int MoistureSoilTestId { get; set; }

        /// <summary>
        /// Название испытываемого материала.
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// Заказчик испытания.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Навигационное свойство для Customer.
        /// </summary>
        public Customer CustomerTest { get; set; }

        /// <summary>
        /// Дата проведения испытания.
        /// </summary>
        public string DateTest { get; set; }

        /// <summary>
        /// Нормативная документация на испытание.
        /// </summary>
        public string DocumentTest { get; set; }

        /// <summary>
        /// Результат измерения массы влажного грунта с бюксой.
        /// </summary>
        public Guid SoilWetMassWithBoxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension SoilWetMassWithBox { get; set; }

        /// <summary>
        /// Результаты измерения массы сухого грунта с бюксой.
        /// </summary>
        public Guid SoilDryMassWithBoxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension SoilDryMassWithBox { get; set; }

        /// <summary>
        /// Результаты измерения массы бюксы.
        /// </summary>
        public Guid BoxMassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension BoxMass { get; set; }

        /// <summary>
        /// Влажность пробы грунта.
        /// </summary>
        public Guid MoistureId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension MoistureSoil { get; set; }
    }
}
