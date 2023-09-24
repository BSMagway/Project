namespace ProjectCommon.Models
{
    /// <summary>
    /// Класс для результатов измерений.
    /// </summary>
    public class Dimension
    {
        /// <summary>
        /// Id в базе данных.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название испытанной величины.
        /// </summary>
        public string? DimensionName { get; set; }

        /// <summary>
        /// Значение испытанной величины.
        /// </summary>
        public double DimensionValue { get; set; }
    }
}
