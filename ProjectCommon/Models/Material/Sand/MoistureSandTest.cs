using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Sand
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению влажности песка.
    /// </summary>
    public class MoistureSandTest : Test
    {

        /// <summary>
        /// Id результата измерения массы влажного песка.
        /// </summary>
        public int? GravelWetMassId { get; set; }

        /// <summary>
        /// Результат измерения массы влажного песка.
        /// </summary>
        public Dimension GravelWetMass { get; set; }

        /// <summary>
        /// Id результата измерения массы сухого песка.
        /// </summary>
        public int? GravelDryMassId { get; set; }

        /// <summary>
        /// Результат измерения массы сухого песка.
        /// </summary>
        public Dimension GravelDryMass { get; set; }

        /// <summary>
        /// Id результата влажности пробы песка.
        /// </summary>
        public int? MoistureId { get; set; }

        /// <summary>
        /// Рассчитанная влажность пробы песка.
        /// </summary>
        public Dimension Moisture { get; set; }

        public override void Calculate()
        {
            if (GravelWetMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы во влажном состоянии меньше или равно 0.");
            }

            if (GravelDryMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы в сухом состоянии меньше или равно 0.");
            }

            if (GravelDryMass.DimensionValue > GravelWetMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы в сухом состоянии больше массы пробы во влажном состоянии.");
            }

            Moisture.DimensionValue = ((GravelWetMass.DimensionValue - GravelDryMass.DimensionValue)
                / GravelDryMass.DimensionValue) * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению влажности грунта.
        /// </summary>
        public MoistureSandTest()
        {
            GravelWetMass = new Dimension("Масса пробы во влажном состоянии, г");
            GravelDryMass = new Dimension("Масса пробы в сухом состоянии, г");
            Moisture = new Dimension("Влажность щебня, %");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Moister;
        }
    }
}
