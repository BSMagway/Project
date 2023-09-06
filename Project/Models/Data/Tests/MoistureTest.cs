using Project.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project.Models.Data.Tests
{
    internal class MoistureTest : Test
    {
        private Dimension<double> soilWetMassWithBox;
        private Dimension<double> soilDryMassWithBox;
        private Dimension<double> boxMass;
        private Dimension<double> moistureSoil;

        public Dimension<double> SoilWetMassWithBox
        {
            get => soilWetMassWithBox;
            set => Set(ref soilWetMassWithBox, value);
        }
        public Dimension<double> SoilDryMassWithBox
        {
            get => soilDryMassWithBox;
            set => Set(ref soilDryMassWithBox, value);
        }
        public Dimension<double> BoxMass
        {
            get => boxMass;
            set => Set(ref boxMass, value);
        }
        public Dimension<double> MoistureSoil
        {
            get => moistureSoil;
            set => Set(ref moistureSoil, value);
        }

        #region Constructors

        public MoistureTest()
        {
            soilWetMassWithBox = new Dimension<double>("Масса влажного грунта с бюксой");
            soilDryMassWithBox = new Dimension<double>("Масса сухого грунта с бюксой");
            boxMass = new Dimension<double>("Масса бюксы");
            moistureSoil = new Dimension<double>("Влажность грунта");
        }

        public MoistureTest(Dimension<double> soilWetMassWithBox, Dimension<double> soilDryMassWithBox, Dimension<double> boxMass, Dimension<double> moistureSoil)
        {
            this.soilWetMassWithBox = soilWetMassWithBox;
            this.soilDryMassWithBox = soilDryMassWithBox;
            this.boxMass = boxMass;
            this.moistureSoil = moistureSoil;
        }

        #endregion

        public void CalculateMoistureSoil()
        {
            if (soilWetMassWithBox.DimensionValue != 0 && soilDryMassWithBox.DimensionValue != 0 && boxMass.DimensionValue != 0 )
            {
                moistureSoil.DimensionValue = (soilWetMassWithBox.DimensionValue - soilDryMassWithBox.DimensionValue) / (soilDryMassWithBox.DimensionValue - boxMass.DimensionValue);
            }
        }


    }
}
