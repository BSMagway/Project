using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Soil
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению влажности грунта.
    /// </summary>
    public class MoistureSoilTest : Test
    {

        /// <summary>
        /// Результат измерения массы влажного грунта с бюксой.
        /// </summary>
        public int? SoilWetMassWithBoxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension SoilWetMassWithBox { get; set; }

        /// <summary>
        /// Результаты измерения массы сухого грунта с бюксой.
        /// </summary>
        public int? SoilDryMassWithBoxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension SoilDryMassWithBox { get; set; }

        /// <summary>
        /// Результаты измерения массы бюксы.
        /// </summary>
        public int? BoxMassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension BoxMass { get; set; }

        /// <summary>
        /// Влажность пробы грунта.
        /// </summary>
        public int? MoistureId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension Moisture { get; set; }

        #region Methods
        /// <summary>
        /// Расчет значения влажности пробы грунта
        /// </summary>
        public void Calculate()
        {
            if (SoilWetMassWithBox.DimensionValue != 0 && SoilDryMassWithBox.DimensionValue != 0 && BoxMass.DimensionValue != 0)
            {
                Moisture.DimensionValue = (SoilWetMassWithBox.DimensionValue - SoilDryMassWithBox.DimensionValue)
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
            Moisture = new Dimension("Влажность грунта");

            MaterialEnum = MaterialType.Soil;
            TestEnum = ExperimentType.Moister;
        }

        //public MoistureSoilTest(Dimension soilWetMassWithBox, Dimension soilDryMassWithBox, Dimension boxMass, Dimension moistureSoil)
        //{
        //    SoilWetMassWithBox = soilWetMassWithBox;
        //    SoilDryMassWithBox = soilDryMassWithBox;
        //    BoxMass = boxMass;
        //    Moisture = moistureSoil;
        //}

        #endregion
    }
}
