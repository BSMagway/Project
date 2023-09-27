﻿using ProjectCommon.ViewModelBase;

namespace ProjectCommon.Models
{
    /// <summary>
    /// Класс для учета заказчиков.
    /// </summary>
    public class Customer : ViewModel
    {
        private string title;
        private int contractNumber;

        /// <summary>
        /// Id в базе данных.
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// Название организации заказчика.
        /// </summary>
        public string Title 
        {
            get => title;
            set => Set(ref title, value);
        }

        /// <summary>
        /// Номер договора с заказчиком.
        /// </summary>
        public int ContractNumber
        {
            get => contractNumber;
            set => Set(ref contractNumber, value);
        }
    }
}
