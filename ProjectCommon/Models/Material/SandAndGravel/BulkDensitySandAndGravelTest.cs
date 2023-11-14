using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.SandAndGravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению насыпной плотности ПГС.
    /// </summary>
    public class BulkDensitySandAndGravelTest : Test
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
        /// Id результата измерения массы мерного цилиндра с ПГС.
        /// </summary>
        public int? BulkDensityCylinderWithSandAndGravelMassId { get; set; }

        /// <summary>
        /// Результат измерения массы мерного цилиндра с ПГС.
        /// </summary>
        public Dimension BulkDensityCylinderWithSandAndGravelMass { get; set; }

        /// <summary>
        /// Id результата измерения объема цилиндра.
        /// </summary>
        public int? CylinderVolumeId { get; set; }

        /// <summary>
        /// Результат измерения объема цилиндра.
        /// </summary>
        public Dimension CylinderVolume { get; set; }

        /// <summary>
        /// Id результата определения насыпной плотности ПГС.
        /// </summary>
        public int? SandAndGravelBulkDensityId { get; set; }

        /// <summary>
        /// Рассчитанное значение насыпной плотности ПГС.
        /// </summary>
        public Dimension SandAndGravelBulkDensity { get; set; }

        public override void Calculate()
        {
            if (BulkDensityCylinderMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы мерного цилиндра равно или меньше 0.");
            }

            if (BulkDensityCylinderWithSandAndGravelMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы мерного цилиндра с песком равно или меньше 0.");
            }

            if (CylinderVolume.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение объема мерного цилиндра равно или меньше 0.");
            }

            if (BulkDensityCylinderWithSandAndGravelMass.DimensionValue < BulkDensityCylinderMass.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы мерного цилиндра больше массы мерного цилиндра с ПГС.");
            }

            SandAndGravelBulkDensity.DimensionValue = (BulkDensityCylinderWithSandAndGravelMass.DimensionValue - BulkDensityCylinderMass.DimensionValue) / CylinderVolume.DimensionValue;

        }

        /// <summary>
        /// Конструктор для создания теста по определению насыпной плотности щебня.
        /// </summary>
        public BulkDensitySandAndGravelTest()
        {
            BulkDensityCylinderMass = new Dimension("Масса мерного цилиндра, г");
            BulkDensityCylinderWithSandAndGravelMass = new Dimension("Масса мерного цилиндра с ПГС, г");
            CylinderVolume = new Dimension("Объема мерного цилиндра, м\u00B3");
            SandAndGravelBulkDensity = new Dimension("Насыпная плотность ПГС, кг/м\u00B3");

            MaterialEnum = MaterialType.SandAndGravel;
            TestEnum = ExperimentType.Bulk_Density;
        }
    }
}
