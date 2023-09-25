using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCommon.Models.Base
{
    public class Test
    {
        /// <summary>
        /// Id в базе данных.
        /// </summary>
        public int Id { get; set; }

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
        public int CustomerTestId { get; set; }

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
    }
}
