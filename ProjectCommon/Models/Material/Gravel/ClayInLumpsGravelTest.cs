using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Gravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению содержания глины в комках в щебне.
    /// </summary>
    public class ClayInLumpsGravelTest : Test
    {

        /// <summary>
        /// Id результата измерения массы глины в комках в щебне.
        /// </summary>
        public int? GravelClayInLumpsMassId { get; set; }

        /// <summary>
        /// Результат измерения массы глины в комках в щебне.
        /// </summary>
        public Dimension GravelClayInLumpsMass { get; set; }

        /// <summary>
        /// Id результата измерения массы аналитической пробы щебня (гравия).
        /// </summary>
        public int? GravelMassId { get; set; }

        /// <summary>
        /// Результат измерения массы аналитической пробы щебня (гравия).
        /// </summary>
        public Dimension GravelMass { get; set; }

        /// <summary>
        /// Id результата содержания глины в комках в щебне.
        /// </summary>
        public int? GravelClayInLumpsId { get; set; }

        /// <summary>
        /// Рассчитанное содержание глины в комках в щебне.
        /// </summary>
        public Dimension GravelClayInLumps { get; set; }

        public override void Calculate()
        {
            if (GravelClayInLumpsMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы глины в комках в щебне равно или меньше 0.");
            }

            if (GravelMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы аналитической пробы щебня равно или меньше 0.");
            }

            if (GravelMass.DimensionValue < GravelClayInLumpsMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы глины в комках больше массы аналитической пробы щебня.");
            }

            GravelClayInLumps.DimensionValue = GravelClayInLumpsMass.DimensionValue / GravelMass.DimensionValue * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению содержания глины в комках в щебне.
        /// </summary>
        public ClayInLumpsGravelTest()
        {
            GravelClayInLumpsMass = new Dimension("Масса глины в комках, г");
            GravelMass = new Dimension("Масса аналитической пробы, г");
            GravelClayInLumps = new Dimension("Содержание зерен слабых пород, %");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Clay_In_Lumps;
        }
    }
}
