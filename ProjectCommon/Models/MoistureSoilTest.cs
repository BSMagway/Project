using ProjectCommon.Models.Base;

namespace ProjectCommon.Models
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению влажности грунта.
    /// </summary>
    public class MoistureSoilTest : Test
    {
        private Dimension soilWetMassWithBox;
        private Dimension soilDryMassWithBox;
        private Dimension boxMass;
        private Dimension moistureSoil;
        /// <summary>
        /// Результат измерения массы влажного грунта с бюксой.
        /// </summary>
        public int SoilWetMassWithBoxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension SoilWetMassWithBox
        {
            get => soilWetMassWithBox;
            set => Set(ref soilWetMassWithBox, value);
        }

        /// <summary>
        /// Результаты измерения массы сухого грунта с бюксой.
        /// </summary>
        public int SoilDryMassWithBoxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension SoilDryMassWithBox
        {
            get => soilDryMassWithBox;
            set => Set(ref soilDryMassWithBox, value);
        }

        /// <summary>
        /// Результаты измерения массы бюксы.
        /// </summary>
        public int BoxMassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension BoxMass
        {
            get => boxMass; 
            set => Set(ref boxMass, value);
        }

        /// <summary>
        /// Влажность пробы грунта.
        /// </summary>
        public int MoistureSoilId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension MoistureSoil
        {
            get => moistureSoil; 
            set => Set(ref moistureSoil, value); 
        }

        #region Methods
        /// <summary>
        /// Расчет значения влажности пробы грунта
        /// </summary>
        public override void Calculate()
        {
            if (SoilWetMassWithBox.DimensionValue != 0 && SoilDryMassWithBox.DimensionValue != 0 && BoxMass.DimensionValue != 0)
            {
                MoistureSoil.DimensionValue =
                    (SoilWetMassWithBox.DimensionValue - SoilDryMassWithBox.DimensionValue)
                    / (SoilDryMassWithBox.DimensionValue - BoxMass.DimensionValue);
            }
        }
        #endregion

        #region Constructors
        public MoistureSoilTest()
        {
            SoilWetMassWithBox = new Dimension("Масса влажного грунта с бюксой");
            SoilDryMassWithBox = new Dimension("Масса сухого грунта с бюксой");
            BoxMass = new Dimension("Масса бюксы");
            MoistureSoil = new Dimension("Влажность грунта");
        }

        public MoistureSoilTest(Dimension soilWetMassWithBox, Dimension soilDryMassWithBox, Dimension boxMass, Dimension moistureSoil)
        {
            this.SoilWetMassWithBox = soilWetMassWithBox;
            this.SoilDryMassWithBox = soilDryMassWithBox;
            this.BoxMass = boxMass;
            this.MoistureSoil = moistureSoil;
        }

        #endregion
    }
}
