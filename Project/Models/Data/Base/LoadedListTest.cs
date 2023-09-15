using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Data.Base
{
    /// <summary>
    /// Класс для представления краткого списка всех тестов в базе данных
    /// </summary>
    internal class LoadedListTest
    {
        /// <summary>
        /// Id теста в базе данных 
        /// </summary>
        public Guid TestId { get; set; }
        /// <summary>
        /// Дата проведения теста
        /// </summary>
        public string TestDate { get; set; }
        /// <summary>
        /// Номер теста
        /// </summary>
        public int TestNumber { get; set; }
        /// <summary>
        /// Код материала для загрузки
        /// </summary>
        public int MaterialTypeEnumNumber { get; set; }
        /// <summary>
        /// Код вида испытания для загрузки
        /// </summary>
        public int TestTypeEnumNumber { get; set;}

    }
}
