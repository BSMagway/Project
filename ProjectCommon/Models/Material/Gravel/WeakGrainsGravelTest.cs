using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Gravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению содержания зерен слабых пород.
    /// </summary>
    public class WeakGrainsGravelTest : Test
    {

        /// <summary>
        /// Id результата измерения массы зерен слабых пород.
        /// </summary>
        public int? GravelWeakGrainsMassId { get; set; }

        /// <summary>
        /// Результат измерения массы зерен слабых пород.
        /// </summary>
        public Dimension GravelWeakGrainsMass { get; set; }

        /// <summary>
        /// Id результата измерения массы аналитической пробы щебня (гравия).
        /// </summary>
        public int? GravelMassId { get; set; }

        /// <summary>
        /// Результат измерения массы аналитической пробы щебня (гравия).
        /// </summary>
        public Dimension GravelMass { get; set; }

        /// <summary>
        /// Id результата содержания зерен слабых пород.
        /// </summary>
        public int? GravelWeakGrainsId { get; set; }

        /// <summary>
        /// Рассчитанное содержание зерен слабых пород.
        /// </summary>
        public Dimension GravelWeakGrains { get; set; }

        public override void Calculate()
        {
            if (GravelWeakGrainsMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы дробленых зерен равно или меньше 0.");
            }

            if (GravelMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы аналитической пробы щебня равно или меньше 0.");
            }

            if (GravelMass.DimensionValue < GravelWeakGrainsMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы аналитической пробы щебня.");
            }

            GravelWeakGrains.DimensionValue = GravelWeakGrainsMass.DimensionValue / GravelMass.DimensionValue * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению содержания зерен слабых пород.
        /// </summary>
        public WeakGrainsGravelTest()
        {
            GravelWeakGrainsMass = new Dimension("Масса зерен слабых пород, г");
            GravelMass = new Dimension("Масса аналитической пробы, г");
            GravelWeakGrains = new Dimension("Содержание зерен слабых пород, %");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Weak_Grains;
        }
    }
}
