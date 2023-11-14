using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Gravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
    /// </summary>
    public class FlakyGrainsGravelTest : Test
    {

        /// <summary>
        /// Id результата измерения массы зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        public int? GravelFlakyGrainsMassId { get; set; }

        /// <summary>
        /// Результат измерения массы зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        public Dimension GravelFlakyGrainsMass { get; set; }

        /// <summary>
        /// Id результата измерения массы аналитической пробы щебня (гравия).
        /// </summary>
        public int? GravelMassId { get; set; }

        /// <summary>
        /// Результат измерения массы аналитической пробы щебня (гравия).
        /// </summary>
        public Dimension GravelMass { get; set; }

        /// <summary>
        /// Id результата содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        public int? GravelFlakyGrainsId { get; set; }

        /// <summary>
        /// Рассчитанное содержание зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        public Dimension GravelFlakyGrains { get; set; }

        public override void Calculate()
        {
            if (GravelFlakyGrainsMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы зерен пластинчатой (лещадной) и игловатой формы равно или меньше 0.");
            }

            if (GravelMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы аналитической пробы щебня равно или меньше 0.");
            }

            if (GravelMass.DimensionValue < GravelFlakyGrainsMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы зерен пластинчатой (лещадной) и игловатой формы больше массы аналитической пробы щебня.");
            }

            GravelFlakyGrains.DimensionValue = GravelFlakyGrainsMass.DimensionValue / GravelMass.DimensionValue * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        public FlakyGrainsGravelTest()
        {
            GravelFlakyGrainsMass = new Dimension("Масса зерен пластинчатой (лещадной) и игловатой формы, г");
            GravelMass = new Dimension("Масса аналитической пробы, г");
            GravelFlakyGrains = new Dimension("Содержание зерен пластинчатой (лещадной) и игловатой формы, %");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Flaky_Grains;
        }
    }
}
