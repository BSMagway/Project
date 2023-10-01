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
        /// Результат измерения массы влажного грунта с бюксой.
        /// </summary>
        public int? SoilMassWithRingAndPlateId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension SoilMassWithRingAndPlate { get; set; }

        /// <summary>
        /// Результаты измерения массы сухого грунта с бюксой.
        /// </summary>
        public int? RingMassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension RingMass { get; set; }

        /// <summary>
        /// Результаты измерения массы бюксы.
        /// </summary>
        public int? PlateMassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension PlateMass { get; set; }

        public int? InternalVolumeRingId { get; set; }
        public Dimension InternalVolumeRing { get; set; }

        /// <summary>
        /// Влажность пробы грунта.
        /// </summary>
        public int? DensityId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension Density { get; set; }

        #region Methods
        /// <summary>
        /// Расчет значения влажности пробы грунта
        /// </summary>
        public override void Calculate()
        {
            if (SoilMassWithRingAndPlate.DimensionValue != 0 && RingMass.DimensionValue != 0
                && PlateMass.DimensionValue != 0 && InternalVolumeRing.DimensionValue != 0)
            {
                Density.DimensionValue = (SoilMassWithRingAndPlate.DimensionValue - RingMass.DimensionValue - PlateMass.DimensionValue)
                    / InternalVolumeRing.DimensionValue;
            }
        }
        #endregion

        #region Constructors
        public DensitySoilTest()
        {
            SoilMassWithRingAndPlate = new Dimension("Масса влажного грунта с бюксой");
            RingMass = new Dimension("Масса сухого грунта с бюксой");
            PlateMass = new Dimension("Масса бюксы");
            InternalVolumeRing = new Dimension("Масса бюксы");
            Density = new Dimension("Влажность грунта");

            MaterialEnum = MaterialType.Soil;
            TestEnum = ExperimentType.Density;
        }

        //public DensitySoilTest(Dimension soilMassWithRingAndPlate, Dimension ringMass, Dimension plateMass, Dimension internalVolumeRing, Dimension density)
        //{
        //    SoilMassWithRingAndPlate = soilMassWithRingAndPlate;
        //    RingMass = ringMass;
        //    PlateMass = plateMass;
        //    InternalVolumeRing = internalVolumeRing;
        //    Density = density;
        //}

        #endregion
    }
}
