using ProjectCommon.Models.Base;
using System.ComponentModel.DataAnnotations;

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
        public int Id { get; set; }

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
