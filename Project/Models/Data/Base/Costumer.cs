using Project.ViewModels.Base;
using System;

namespace Project.Models.Data.Base
{
    /// <summary>
    /// Заказчик испытания.
    /// </summary>
    internal class Costumer : ViewModel
    {
        private string title = string.Empty;
        private int contractNumber;

        /// <summary>
        /// Id в базе данных
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название компании.
        /// </summary>
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }
        /// <summary>
        /// Номер договора
        /// </summary>
        public int ContractNumber
        {
            get => contractNumber;
            set => Set(ref contractNumber, value);
        }
    }
}
