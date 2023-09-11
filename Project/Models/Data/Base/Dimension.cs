using Project.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project.Models.Data.Base
{
    /// <summary>
    /// Значения испытаных величин
    /// </summary>
    internal class Dimension : ViewModel
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Название испытанной величины
        /// </summary>
        private string dimensionName;
        /// <summary>
        /// Значение испытанной величины
        /// </summary>
        private double dimensionValue;
        /// <summary>
        /// Название испытанной величины
        /// </summary>
        public string DimensionName
        {
            get => dimensionName;
            set => dimensionName = value;
        }
        /// <summary>
        /// Значение испытанной величины
        /// </summary>
        public double DimensionValue
        {
            get => dimensionValue;
            set => Set(ref dimensionValue, value);
        }

        #region Constructors
        public Dimension()
        {
            dimensionName = String.Empty; 
        }

        public Dimension(string dimensionName)
        {
            this.dimensionName = dimensionName;

        }

        public Dimension(string dimensionName, double dimensionValue)
        {
            this.dimensionName = dimensionName;
            this.dimensionValue = dimensionValue;
        }
        #endregion
    }
}
