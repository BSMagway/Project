using Project.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Data.Base
{
    /// <summary>
    /// Базовый класс теста
    /// </summary>
    internal abstract class Test : ViewModel
    {
        /// <summary>
        /// Id в базе данных
        /// </summary>
        private Guid id { get; set; }
        /// <summary>
        /// Порядковый номер теста (протокола)
        /// </summary>
        private int moistureSoilTestId;
        /// <summary>
        /// Название испытываемого материала 
        /// </summary>
        private string materialName = string.Empty;
        /// <summary>
        /// Заказчик испытания
        /// </summary>
        private Costumer costumerTest;
        /// <summary>
        /// Дата проведения испытания
        /// </summary>
        private string dateTest = string.Empty;
        /// <summary>
        /// Нормативная документация на испытание
        /// </summary>
        private string documentTest = string.Empty;


        /// <summary>
        /// Id в базе данных
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Порядковый номер теста (протокола)
        /// </summary>
        public int MoistureSoilTestId
        {
            get => moistureSoilTestId;
            set => Set(ref moistureSoilTestId, value);
        }
        /// <summary>
        /// Название испытываемого материала 
        /// </summary>
        public string MaterialName
        {
            get => materialName;
            set => Set(ref materialName, value);
        }
        /// <summary>
        /// Дата проведения испытания
        /// </summary>
        public string DateTest
        {
            get => dateTest;
            set => Set(ref dateTest, value);
        }
        /// <summary>
        /// Нормативная документация на испытание
        /// </summary>
        public string DocumentTest
        {
            get => documentTest;
            set => Set(ref documentTest, value);
        }
        /// <summary>
        /// Заказчик испытания
        /// </summary>
        public Costumer CostumerTest
        {
            get
            {
                if (costumerTest is null)
                {
                    costumerTest = new Costumer();
                }

                return costumerTest;
            }

            set => Set(ref costumerTest, value);
        }



    }
}
