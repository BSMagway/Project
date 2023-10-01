using ProjectCommon.Models.Base;
using ProjectCommon.ViewModelBase;
using System.ComponentModel.DataAnnotations;

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
        public string? DimensionName {  get; set; }

        /// <summary>
        /// Значение испытанной величины.
        /// </summary>
        public double DimensionValue 
        {
            get => dimensionValue;
            set => Set(ref dimensionValue, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public Dimension()
        {
            DimensionName = String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimensionName"></param>
        public Dimension(string dimensionName)
        {
            this.DimensionName = dimensionName;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimensionName"></param>
        /// <param name="dimensionValue"></param>
        public Dimension(string dimensionName, double dimensionValue)
        {
            this.DimensionName = dimensionName;
            this.DimensionValue = dimensionValue;
        }
    }
}
