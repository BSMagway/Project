namespace ProjectServer.Entities
{
    /// <summary>
    /// Класс для отображения короткого списка всех протоколов испытаний
    /// </summary>
    public class FullShortListTests
    {
        /// <summary>
        /// Id протокола испытания в базе данных
        /// </summary>
        public Guid TestId { get; set; }
        /// <summary>
        /// Дата испытания
        /// </summary>
        public string TestDate { get; set; }
        /// <summary>
        /// Номер протокола
        /// </summary>
        public int TestNumber { get; set; }
    }
}
