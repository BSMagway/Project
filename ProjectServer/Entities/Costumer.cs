﻿namespace ProjectServer.Entities
{
    /// <summary>
    /// Класс для учета заказчиков
    /// </summary>
    public class Costumer
    {
        /// <summary>
        /// Id в базе данных
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название организации заказчика
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Номер договора с заказчиком
        /// </summary>
        public int ContractNumber { get; set; }
    }
}
