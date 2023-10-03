using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Soil
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению влажности грунта.
    /// </summary>
    public class DensitySoilTest : Test
    {

        /// <summary>
        /// Id результата измерения массы грунта с кольцом и пластинками.
        /// </summary>
        public int? SoilMassWithRingAndPlateId { get; set; }

        /// <summary>
        /// Результат измерения массы грунта с кольцом и пластинками.
        /// </summary>
        public Dimension SoilMassWithRingAndPlate { get; set; }

        /// <summary>
        /// Id результата измерения массы кольца.
        /// </summary>
        public int? RingMassId { get; set; }

        /// <summary>
        /// Результат измерения массы кольца.
        /// </summary>
        public Dimension RingMass { get; set; }

        /// <summary>
        /// Id результата измерения массы пластинок.
        /// </summary>
        public int? PlateMassId { get; set; }

        /// <summary>
        /// Результат измерения массы пластинок.
        /// </summary>
        public Dimension PlateMass { get; set; }

        /// <summary>
        /// Id результата измерения внутреннего объема кольца.
        /// </summary>
        public int? InternalVolumeRingId { get; set; }

        /// <summary>
        /// Результат измерения внутреннего объема кольца.
        /// </summary>
        public Dimension InternalVolumeRing { get; set; }

        /// <summary>
        /// Id полученной плотности пробы грунта.
        /// </summary>
        public int? DensityId { get; set; }

        /// <summary>
        /// Плотность пробы грунта.
        /// </summary>
        public Dimension Density { get; set; }

        public override void Calculate()
        {
            if (SoilMassWithRingAndPlate.DimensionValue != 0 && RingMass.DimensionValue != 0
                && PlateMass.DimensionValue != 0 && InternalVolumeRing.DimensionValue != 0)
            {
                Density.DimensionValue = (SoilMassWithRingAndPlate.DimensionValue - RingMass.DimensionValue - PlateMass.DimensionValue)
                    / InternalVolumeRing.DimensionValue;
            }
        }

        /// <summary>
        /// Конструктор для создания теста по определению плотности грунта.
        /// </summary>
        public DensitySoilTest()
        {
            SoilMassWithRingAndPlate = new Dimension("Масса грунта с кольцами и пластинками, г");
            RingMass = new Dimension("Масса кольца, г");
            PlateMass = new Dimension("Масса плачтинок, г");
            InternalVolumeRing = new Dimension("Внутренний объем кольца, см\u00B3");
            Density = new Dimension("Плотность грунта, г/см\u00B3");

            MaterialEnum = MaterialType.Soil;
            TestEnum = ExperimentType.Density;
        }
    }
}
