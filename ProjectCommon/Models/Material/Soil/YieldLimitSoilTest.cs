using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Soil
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению границы текучести грунта.
    /// </summary>
    public class YieldLimitSoilTest : Test
    {

        /// <summary>
        /// Id результата измерения массы влажного грунта с бюксой.
        /// </summary>
        public int? SoilWetMassWithBoxId { get; set; }

        /// <summary>
        /// Результат измерения массы влажного грунта с бюксой.
        /// </summary>
        public Dimension SoilWetMassWithBox { get; set; }

        /// <summary>
        /// Id результата измерения массы сухого грунта с бюксой.
        /// </summary>
        public int? SoilDryMassWithBoxId { get; set; }

        /// <summary>
        /// Результат измерения массы сухого грунта с бюксой.
        /// </summary>
        public Dimension SoilDryMassWithBox { get; set; }

        /// <summary>
        /// Id результата измерения массы бюксы.
        /// </summary>
        public int? BoxMassId { get; set; }

        /// <summary>
        /// Результат измерения массы бюксы.
        /// </summary>
        public Dimension BoxMass { get; set; }

        /// <summary>
        /// Id результата определения границы текучести пробы грунта.
        /// </summary>
        public int? YieldLimitId { get; set; }

        /// <summary>
        /// Рассчитанная граница текучести пробы грунта.
        /// </summary>
        public Dimension YieldLimit { get; set; }

        public override void Calculate()
        {
            if (SoilWetMassWithBox.DimensionValue == 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы влажного грунта с бюксой равно 0");
            }

            if (SoilDryMassWithBox.DimensionValue == 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы сухого грунта с бюксой равно 0");
            }

            if (BoxMass.DimensionValue == 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы бюксы равно 0");
            }

            YieldLimit.DimensionValue = ((SoilWetMassWithBox.DimensionValue - SoilDryMassWithBox.DimensionValue)
                                        / (SoilDryMassWithBox.DimensionValue - BoxMass.DimensionValue)) * 100;
        }

        /// <summary>
        /// Конструктор для создания теста по определению границы текучести пробы грунта.
        /// </summary>
        public YieldLimitSoilTest()
        {
            SoilWetMassWithBox = new Dimension("Масса влажного грунта с бюксой, г");
            SoilDryMassWithBox = new Dimension("Масса сухого грунта с бюксой, г");
            BoxMass = new Dimension("Масса бюксы, г");
            YieldLimit = new Dimension("Граница текучести, %");

            MaterialEnum = MaterialType.Soil;
            TestEnum = ExperimentType.Yield_Limit;
        }
    }
}
