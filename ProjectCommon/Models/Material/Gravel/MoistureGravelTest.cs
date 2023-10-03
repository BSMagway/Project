using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Gravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению влажности грунта.
    /// </summary>
    public class MoistureGravelTest : Test
    {

        /// <summary>
        /// Id результата измерения массы влажного грунта с бюксой.
        /// </summary>
        public int? GravelWetMassId { get; set; }

        /// <summary>
        /// Результат измерения массы влажного грунта с бюксой.
        /// </summary>
        public Dimension GravelWetMass { get; set; }

        /// <summary>
        /// Id результата измерения массы сухого грунта с бюксой.
        /// </summary>
        public int? GravelDryMassId { get; set; }

        /// <summary>
        /// Результат измерения массы сухого грунта с бюксой.
        /// </summary>
        public Dimension GravelDryMass { get; set; }

        /// <summary>
        /// Id результата влажности пробы грунта.
        /// </summary>
        public int? MoistureId { get; set; }

        /// <summary>
        /// Рассчитанная влажность пробы грунта.
        /// </summary>
        public Dimension Moisture { get; set; }

        public override void Calculate()
        {
            if (GravelWetMass.DimensionValue == 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы во влажном состоянии равно 0");
            }

            if (GravelDryMass.DimensionValue == 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы в сухом состоянии равно 0");
            }

            Moisture.DimensionValue = ((GravelWetMass.DimensionValue - GravelDryMass.DimensionValue)
                / GravelDryMass.DimensionValue) * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению влажности грунта.
        /// </summary>
        public MoistureGravelTest()
        {
            GravelWetMass = new Dimension("Масса пробы во влажном состоянии, г");
            GravelDryMass = new Dimension("Масса пробы в сухом состоянии, г");
            Moisture = new Dimension("Влажность щебня, %");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Moister;
        }
    }
}
