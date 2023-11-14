using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Gravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению дробимости щебня.
    /// </summary>
    public class CrushabilityGravelTest : Test
    {

        /// <summary>
        /// Id результата измерения массы остатка на контрольном сите.
        /// </summary>
        public int? GravelCrushabilityMassId { get; set; }

        /// <summary>
        /// Результат измерения массы остатка на контрольном сите.
        /// </summary>
        public Dimension GravelCrushabilityMass { get; set; }

        /// <summary>
        /// Id результата измерения массы аналитической пробы щебня (гравия).
        /// </summary>
        public int? GravelMassId { get; set; }

        /// <summary>
        /// Результат измерения массы аналитической пробы щебня (гравия).
        /// </summary>
        public Dimension GravelMass { get; set; }

        /// <summary>
        /// Id результата дробимости.
        /// </summary>
        public int? GravelCrushabilityId { get; set; }

        /// <summary>
        /// Рассчитанное Значение дробимости.
        /// </summary>
        public Dimension GravelCrushability { get; set; }

        public override void Calculate()
        {
            if (GravelCrushabilityMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы  остатка на контрольном сите равно или меньше 0.");
            }

            if (GravelMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы аналитической пробы щебня равно или меньше 0.");
            }

            if (GravelMass.DimensionValue < GravelCrushabilityMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы  остатка на контрольном сите больше массы аналитической пробы щебня.");
            }

            GravelCrushability.DimensionValue = (GravelMass.DimensionValue - GravelCrushabilityMass.DimensionValue) / GravelMass.DimensionValue * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению дробимсоти щебня.
        /// </summary>
        public CrushabilityGravelTest()
        {
            GravelCrushabilityMass = new Dimension("Масса остатка на контрольном сите, г");
            GravelMass = new Dimension("Масса аналитической пробы, г");
            GravelCrushability = new Dimension("Дробимость щебня, %");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Crushability;
        }
    }
}
