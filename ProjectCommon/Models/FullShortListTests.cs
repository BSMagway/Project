using ProjectCommon.Enums;

namespace ProjectCommon.Models
{
    /// <summary>
    /// Класс для отображения короткого списка всех протоколов испытаний.
    /// </summary>
    public class FullShortListTests
    {
        /// <summary>
        /// Id протокола испытания в базе данных.
        /// </summary>
        public int TestId { get; set; }

        /// <summary>
        /// Дата испытания.
        /// </summary>
        public string TestDate { get; set; }

        /// <summary>
        /// Номер протокола.
        /// </summary>
        public int TestNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MaterialType MaterialType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExperimentType ExperimentType { get; set; }
    }
}
