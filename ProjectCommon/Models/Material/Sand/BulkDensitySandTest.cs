using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Sand
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению насыпной плотности песка.
    /// </summary>
    public class BulkDensitySandTest : Test
    {

        /// <summary>
        /// Id результата измерения массы мерного цилиндра.
        /// </summary>
        public int? BulkDensityCylinderMassId { get; set; }

        /// <summary>
        /// Результат измерения массы мерного цилиндра.
        /// </summary>
        public Dimension BulkDensityCylinderMass { get; set; }

        /// <summary>
        /// Id результата измерения массы мерного цилиндра с песком.
        /// </summary>
        public int? BulkDensityCylinderWithSandMassId { get; set; }

        /// <summary>
        /// Результат измерения массы мерного цилиндра с песком.
        /// </summary>
        public Dimension BulkDensityCylinderWithSandMass { get; set; }

        /// <summary>
        /// Id результата измерения объема цилиндра.
        /// </summary>
        public int? CylinderVolumeId { get; set; }

        /// <summary>
        /// Результат измерения объема цилиндра.
        /// </summary>
        public Dimension CylinderVolume { get; set; }

        /// <summary>
        /// Id результата определения насыпной плотности песка.
        /// </summary>
        public int? SandBulkDensityId { get; set; }

        /// <summary>
        /// Рассчитанное значение насыпной плотности песка.
        /// </summary>
        public Dimension SandBulkDensity { get; set; }

        public override void Calculate()
        {
            if (BulkDensityCylinderMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы мерного цилиндра равно или меньше 0.");
            }

            if (BulkDensityCylinderWithSandMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы мерного цилиндра с песком равно или меньше 0.");
            }

            if (CylinderVolume.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение объема мерного цилиндра равно или меньше 0.");
            }

            if (BulkDensityCylinderWithSandMass.DimensionValue < BulkDensityCylinderMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы мерного цилиндра больше массы мерного цилиндра с песком.");
            }

            SandBulkDensity.DimensionValue = (BulkDensityCylinderWithSandMass.DimensionValue - BulkDensityCylinderMass.DimensionValue) / CylinderVolume.DimensionValue;

        }

        /// <summary>
        /// Конструктор для создания теста по определению насыпной плотности щебня.
        /// </summary>
        public BulkDensitySandTest()
        {
            BulkDensityCylinderMass = new Dimension("Масса мерного цилиндра, г");
            BulkDensityCylinderWithSandMass = new Dimension("Масса мерного цилиндра с песком, г");
            CylinderVolume = new Dimension("Объема мерного цилиндра, м\u00B3");
            SandBulkDensity = new Dimension("Насыпная плотность песка, кг/м\u00B3");

            MaterialEnum = MaterialType.Sand;
            TestEnum = ExperimentType.Bulk_Density;
        }
    }
}
