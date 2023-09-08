
using Project.Models.Data.Base;


namespace Project.Models.Data.Tests.Soil
{
    /// <summary>
    /// Class для испытаний по определению влажности грунта
    /// </summary>
    internal class MoistureSoilTest : Test
    {
        #region Fields
        /// <summary>
        /// Масса влажного грунта с бюксом
        /// </summary>
        private Dimension soilWetMassWithBox;
        /// <summary>
        /// Масса сухого грунта с бюксой
        /// </summary>
        private Dimension soilDryMassWithBox;
        /// <summary>
        /// Масса бюкса
        /// </summary>
        private Dimension boxMass;
        /// <summary>
        /// Влажность пробы грунта
        /// </summary>
        private Dimension moistureSoil;
        #endregion

        #region Properties
        /// <summary>
        /// Масса влажного грунта с бюксом
        /// </summary>
        public Dimension SoilWetMassWithBox
        {
            get => soilWetMassWithBox;
            set => Set(ref soilWetMassWithBox, value);
        }
        /// <summary>
        /// Масса сухого грунта с бюксой
        /// </summary>
        public Dimension SoilDryMassWithBox
        {
            get => soilDryMassWithBox;
            set => Set(ref soilDryMassWithBox, value);
        }
        /// <summary>
        /// Масса бюкса
        /// </summary>
        public Dimension BoxMass
        {
            get => boxMass;
            set => Set(ref boxMass, value);
        }
        /// <summary>
        /// Влажность пробы грунта
        /// </summary>
        public Dimension MoistureSoil
        {
            get => moistureSoil;
            set => Set(ref moistureSoil, value);
        }
        #endregion

        #region Constructors
        public MoistureSoilTest()
        {
            soilWetMassWithBox = new Dimension("Масса влажного грунта с бюксой");
            soilDryMassWithBox = new Dimension("Масса сухого грунта с бюксой");
            boxMass = new Dimension("Масса бюксы");
            moistureSoil = new Dimension("Влажность грунта");
        }

        public MoistureSoilTest(Dimension soilWetMassWithBox, Dimension soilDryMassWithBox, Dimension boxMass, Dimension moistureSoil)
        {
            this.soilWetMassWithBox = soilWetMassWithBox;
            this.soilDryMassWithBox = soilDryMassWithBox;
            this.boxMass = boxMass;
            this.moistureSoil = moistureSoil;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Расчет значения влажности пробы грунта
        /// </summary>
        public void CalculateMoistureSoil()
        {
            if (soilWetMassWithBox.DimensionValue != 0 && soilDryMassWithBox.DimensionValue != 0 && boxMass.DimensionValue != 0)
            {
                moistureSoil.DimensionValue = (soilWetMassWithBox.DimensionValue - soilDryMassWithBox.DimensionValue) / (soilDryMassWithBox.DimensionValue - boxMass.DimensionValue);
            }
        }
        #endregion

    }
}
