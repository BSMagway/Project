using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Gravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению насыпной плотности щебня.
    /// </summary>
    public class BulkDensityGravelTest : Test
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
        /// Id результата измерения массы мерного цилиндра со щебнем.
        /// </summary>
        public int? BulkDensityCylinderWithGravelMassId { get; set; }

        /// <summary>
        /// Результат измерения массы мерного цилиндра со щебнем.
        /// </summary>
        public Dimension BulkDensityCylinderWithGravelMass { get; set; }

        /// <summary>
        /// Id результата измерения объема цилиндра.
        /// </summary>
        public int? CylinderVolumeId { get; set; }

        /// <summary>
        /// Результат измерения объема цилиндра.
        /// </summary>
        public Dimension CylinderVolume { get; set; }

        /// <summary>
        /// Id результата определения насыпной плотности щебня.
        /// </summary>
        public int? GravelBulkDensityId { get; set; }

        /// <summary>
        /// Рассчитанное значение насыпной плотности щебня.
        /// </summary>
        public Dimension GravelBulkDensity { get; set; }

        public override void Calculate()
        {
            if (BulkDensityCylinderMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы мерного цилиндра равно или меньше 0.");
            }

            if (BulkDensityCylinderWithGravelMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы мерного цилиндра со щебнем равно или меньше 0.");
            }

            if (CylinderVolume.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение объема мерного цилиндра равно или меньше 0.");
            }

            if (BulkDensityCylinderWithGravelMass.DimensionValue < BulkDensityCylinderMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы мерного цилиндра больше массы мерного цилиндра со щебнем.");
            }

            GravelBulkDensity.DimensionValue = (BulkDensityCylinderWithGravelMass.DimensionValue - BulkDensityCylinderMass.DimensionValue) / CylinderVolume.DimensionValue;

        }

        /// <summary>
        /// Конструктор для создания теста по определению насыпной плотности щебня.
        /// </summary>
        public BulkDensityGravelTest()
        {
            BulkDensityCylinderMass = new Dimension("Масса мерного цилиндра, г");
            BulkDensityCylinderWithGravelMass = new Dimension("Масса мерного цилиндра со щебнем, г");
            CylinderVolume = new Dimension("Объема мерного цилиндра, м\u00B3");
            GravelBulkDensity = new Dimension("Насыпная плотность, кг/м\u00B3");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Bulk_Density;
        }
    }
}
