using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Gravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению содержания пылевидных и глинистых частиц в щебне.
    /// </summary>
    public class DustGravelTest : Test
    {

        /// <summary>
        /// Id результата измерения массы пробы после промывки.
        /// </summary>
        public int? GravelWithoutDustMassId { get; set; }

        /// <summary>
        /// Результат измерения массы пробы после промывки.
        /// </summary>
        public Dimension GravelWithoutDustMass { get; set; }

        /// <summary>
        /// Id результата измерения массы пробы до промывки.
        /// </summary>
        public int? GravelMassId { get; set; }

        /// <summary>
        /// Результат измерения массы пробы до промывки.
        /// </summary>
        public Dimension GravelMass { get; set; }

        /// <summary>
        /// Id результата содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        public int? GravelDustId { get; set; }

        /// <summary>
        /// Рассчитанное содержание пылевидных и глинистых частиц в щебне.
        /// </summary>
        public Dimension GravelDust { get; set; }

        public override void Calculate()
        {
            if (GravelWithoutDustMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы после промывки равно или меньше 0.");
            }

            if (GravelMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы до промывки равно или меньше 0.");
            }

            if (GravelMass.DimensionValue < GravelWithoutDustMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы после промывки больше массы пробы до промывки.");
            }

            GravelDust.DimensionValue = (GravelMass.DimensionValue - GravelWithoutDustMass.DimensionValue) / GravelMass.DimensionValue * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        public DustGravelTest()
        {
            GravelWithoutDustMass = new Dimension("Масса пробы после промывки, г");
            GravelMass = new Dimension("Масса пробы до промывки, г");
            GravelDust = new Dimension("Содержание пылевидных и глинистых частиц в щебне, %");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Dust;
        }
    }
}
