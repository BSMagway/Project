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
        /// Порядковый номер теста (протокола)
        /// </summary>
        private int id;
        /// <summary>
        /// Название испытываемого материала 
        /// </summary>
        private string materialName = string.Empty;
        /// <summary>
        /// Заказчик испытания
        /// </summary>
        private Costumer customerTest;
        /// <summary>
        /// Дата проведения испытания
        /// </summary>
        private string dateTest = string.Empty;
        /// <summary>
        /// Нормативная документация на испытание
        /// </summary>
        private string documentTest = string.Empty;




        public int Id { get { return id; } set { id = value; } }
        public string MaterialName { get { return materialName; } set { materialName = value; } }
        public string DateTest { get { return dateTest; } set { dateTest = value; } }
        public string DocumentTest { get { return documentTest; } set { documentTest = value; } }
        public Costumer CustomerTest
        {
            get
            {
                if (customerTest is null)
                {
                    customerTest = new Costumer();
                }

                return customerTest;
            }

            set { customerTest = value; }
        }



    }
}
