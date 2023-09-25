using ProjectCommon.Models.Base;

namespace ProjectCommon.Models
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению влажности грунта.
    /// </summary>
    public class MoistureSoilTest : Test
    {
        /// <summary>
        /// Результат измерения массы влажного грунта с бюксой.
        /// </summary>
        public int SoilWetMassWithBoxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension SoilWetMassWithBox { get; set; }

        /// <summary>
        /// Результаты измерения массы сухого грунта с бюксой.
        /// </summary>
        public int SoilDryMassWithBoxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension SoilDryMassWithBox { get; set; }

        /// <summary>
        /// Результаты измерения массы бюксы.
        /// </summary>
        public int BoxMassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension BoxMass { get; set; }

        /// <summary>
        /// Влажность пробы грунта.
        /// </summary>
        public int MoistureSoilId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dimension MoistureSoil { get; set; }
    }
}
