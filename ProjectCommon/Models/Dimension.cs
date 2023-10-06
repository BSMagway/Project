using ProjectCommon.ViewModelBase;

namespace ProjectCommon.Models
{
    /// <summary>
    /// Класс для результатов измерений.
    /// </summary>
    public class Dimension : ViewModel
    {
        private double dimensionValue;

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
        public double DimensionValue
        {
            get => dimensionValue;
            set => Set(ref dimensionValue, value);
        }

        /// <summary>
        /// Базовый конструктор.
        /// </summary>
        public Dimension()
        {
            DimensionName = String.Empty;
        }

        /// <summary>
        /// Конструктор для создания измерения с именем.
        /// </summary>
        /// <param name="dimensionName">Имя измерения.</param>
        public Dimension(string dimensionName)
        {
            this.DimensionName = dimensionName;

        }

        /// <summary>
        /// Конструктор для создания измерения с именем и значением.
        /// </summary>
        /// <param name="dimensionName">Имя измерения.</param>
        /// <param name="dimensionValue">Значение измерения.</param>
        public Dimension(string dimensionName, double dimensionValue)
        {
            this.DimensionName = dimensionName;
            this.DimensionValue = dimensionValue;
        }
    }
}
