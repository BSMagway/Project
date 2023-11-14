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
        public int? SandWetMassId { get; set; }

        /// <summary>
        /// Результат измерения массы влажного песка.
        /// </summary>
        public Dimension SandWetMass { get; set; }

        /// <summary>
        /// Id результата измерения массы сухого песка.
        /// </summary>
        public int? SandDryMassId { get; set; }

        /// <summary>
        /// Результат измерения массы сухого песка.
        /// </summary>
        public Dimension SandDryMass { get; set; }

        /// <summary>
        /// Id результата влажности пробы песка.
        /// </summary>
        public int? SandMoistureId { get; set; }

        /// <summary>
        /// Рассчитанная влажность пробы песка.
        /// </summary>
        public Dimension SandMoisture { get; set; }

        public override void Calculate()
        {
            if (SandWetMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы песка во влажном состоянии меньше или равно 0.");
            }

            if (SandDryMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы песка в сухом состоянии меньше или равно 0.");
            }

            if (SandDryMass.DimensionValue > SandWetMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы песка в сухом состоянии больше массы пробы песка во влажном состоянии.");
            }

            SandMoisture.DimensionValue = ((SandWetMass.DimensionValue - SandDryMass.DimensionValue)
                / SandDryMass.DimensionValue) * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению влажности песка.
        /// </summary>
        public MoistureSandTest()
        {
            SandWetMass = new Dimension("Масса пробы песка во влажном состоянии, г");
            SandDryMass = new Dimension("Масса пробы песка в сухом состоянии, г");
            SandMoisture = new Dimension("Влажность песка, %");

            MaterialEnum = MaterialType.Sand;
            TestEnum = ExperimentType.Moister;
        }
    }
}
