using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Soil
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению границы расскатывания грунта.
    /// </summary>
    public class RollingBoundarySoilTest : Test
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
        /// Id результата определения границы раскатывания пробы грунта.
        /// </summary>
        public int? RollingBoundaryId { get; set; }

        /// <summary>
        /// Рассчитанная влажность границы раскатывания пробы грунта.
        /// </summary>
        public Dimension RollingBoundary { get; set; }

        public override void Calculate()
        {
            if (SoilWetMassWithBox.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException(null, "Значение массы влажного грунта с бюксой равно или меньше 0.");
            }

            if (SoilDryMassWithBox.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException(null, "Значение массы сухого грунта с бюксой равно или меньше 0.");
            }

            if (BoxMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException(null, "Значение массы бюксы равно или меньше 0.");
            }

            if (SoilWetMassWithBox.DimensionValue < SoilDryMassWithBox.DimensionValue)
            {
                throw new ArgumentOutOfRangeException(null, "Значение массы влажного грунта меньше массы сухого грунта.");
            }

            if (SoilDryMassWithBox.DimensionValue <= BoxMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException(null, "Значение массы сухого грунта меньше или равна массы бюксы.");
            }

            RollingBoundary.DimensionValue = ((SoilWetMassWithBox.DimensionValue - SoilDryMassWithBox.DimensionValue)
                / (SoilDryMassWithBox.DimensionValue - BoxMass.DimensionValue)) * 100;
        }

        /// <summary>
        /// Конструктор для создания теста по определению границы раскатывания пробы грунта.
        /// </summary>
        public RollingBoundarySoilTest()
        {
            SoilWetMassWithBox = new Dimension("Масса влажного грунта с бюксой, г");
            SoilDryMassWithBox = new Dimension("Масса сухого грунта с бюксой, г");
            BoxMass = new Dimension("Масса бюксы, г");
            RollingBoundary = new Dimension("Граница раскатывания, %");

            DocumentTest = "ГОСТ 5180-2015";

            MaterialEnum = MaterialType.Soil;
            TestEnum = ExperimentType.Rolling_Boundary;
        }
    }
}
