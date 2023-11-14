using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Sand
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению содержания пылевидных и глинистых частиц в песке.
    /// </summary>
    public class DustSandTest : Test
    {

        /// <summary>
        /// Id результата измерения массы пробы после промывки.
        /// </summary>
        public int? SandWithoutDustMassId { get; set; }

        /// <summary>
        /// Результат измерения массы пробы после промывки.
        /// </summary>
        public Dimension SandWithoutDustMass { get; set; }

        /// <summary>
        /// Id результата измерения массы пробы до промывки.
        /// </summary>
        public int? SandMassId { get; set; }

        /// <summary>
        /// Результат измерения массы пробы до промывки.
        /// </summary>
        public Dimension SandMass { get; set; }

        /// <summary>
        /// Id результата содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        public int? SandDustId { get; set; }

        /// <summary>
        /// Рассчитанное содержание пылевидных и глинистых частиц в песке.
        /// </summary>
        public Dimension SandDust { get; set; }

        public override void Calculate()
        {
            if (SandWithoutDustMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы после промывки равно или меньше 0.");
            }

            if (SandMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы до промывки равно или меньше 0.");
            }

            if (SandMass.DimensionValue < SandWithoutDustMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы после промывки больше массы пробы до промывки.");
            }

            SandDust.DimensionValue = (SandMass.DimensionValue - SandWithoutDustMass.DimensionValue) / SandMass.DimensionValue * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        public DustSandTest()
        {
            SandWithoutDustMass = new Dimension("Масса пробы после промывки, г");
            SandMass = new Dimension("Масса пробы до промывки, г");
            SandDust = new Dimension("Содержание пылевидных и глинистых частиц в песке, %");

            MaterialEnum = MaterialType.Sand;
            TestEnum = ExperimentType.Dust;
        }
    }
}
