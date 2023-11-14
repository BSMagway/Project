using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Gravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению влажности щебня.
    /// </summary>
    public class MoistureGravelTest : Test
    {

        /// <summary>
        /// Id результата измерения массы влажного щебня.
        /// </summary>
        public int? GravelWetMassId { get; set; }

        /// <summary>
        /// Результат измерения массы влажного щебня.
        /// </summary>
        public Dimension GravelWetMass { get; set; }

        /// <summary>
        /// Id результата измерения массы сухого щебня.
        /// </summary>
        public int? GravelDryMassId { get; set; }

        /// <summary>
        /// Результат измерения массы сухого щебня.
        /// </summary>
        public Dimension GravelDryMass { get; set; }

        /// <summary>
        /// Id результата влажности пробы щебня.
        /// </summary>
        public int? MoistureId { get; set; }

        /// <summary>
        /// Рассчитанная влажность пробы щебня.
        /// </summary>
        public Dimension Moisture { get; set; }

        public override void Calculate()
        {
            if (GravelWetMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы щебня во влажном состоянии меньше или равно 0.");
            }

            if (GravelDryMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы щебня в сухом состоянии меньше или равно 0.");
            }

            if (GravelDryMass.DimensionValue > GravelWetMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы щебня в сухом состоянии больше массы пробы щебня во влажном состоянии.");
            }

            Moisture.DimensionValue = ((GravelWetMass.DimensionValue - GravelDryMass.DimensionValue)
                / GravelDryMass.DimensionValue) * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению влажности щебня.
        /// </summary>
        public MoistureGravelTest()
        {
            GravelWetMass = new Dimension("Масса пробы щебня во влажном состоянии, г");
            GravelDryMass = new Dimension("Масса пробы щебня в сухом состоянии, г");
            Moisture = new Dimension("Влажность щебня, %");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Moister;
        }
    }
}
