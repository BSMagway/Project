using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectServer.Entities
{
    public class MoistureSoilTest
    {
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
        public Costumer Costumer { get; set; }
        /// <summary>
        /// Дата проведения испытания
        /// </summary>
        public string DateTest { get; set; }
        /// <summary>
        /// Нормативная документация на испытание
        /// </summary>
        public string DocumentTest { get; set; }

        public List<Dimension> Dimensions { get; set; }
    }
}
