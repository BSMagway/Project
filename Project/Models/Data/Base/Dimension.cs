using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Data.Base
{
    internal class Dimension
    {
        private string dimensionName;
        private double dimensionValue;





        public string DimensionName
        {
            get => dimensionName;
            set => dimensionName = value;
        }
        public double DimensionValue
        {
            get => dimensionValue;
            set => dimensionValue = value;       
        }
    }
}
