using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Gravel
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению содержания дробленых зерен в щебне из гравия.
    /// </summary>
    public class CrushedGrainsGravelTest : Test
    {

        /// <summary>
        /// Id результата измерения массы дробленых зерен.
        /// </summary>
        public int? GravelCrushedGrainsMassId { get; set; }

        /// <summary>
        /// Результат измерения массы дробленых зерен.
        /// </summary>
        public Dimension GravelCrushedGrainsMass { get; set; }

        /// <summary>
        /// Id результата измерения массы остатка щебня на сите.
        /// </summary>
        public int? GravelMassId { get; set; }

        /// <summary>
        /// Результат измерения массы остатка щебня на сите.
        /// </summary>
        public Dimension GravelMass { get; set; }

        /// <summary>
        /// Id результата содержания дробленых зерен в щебне из гравия.
        /// </summary>
        public int? GravelCrushedGrainsId { get; set; }

        /// <summary>
        /// Рассчитанное содержание дробленых зерен в щебне из гравия.
        /// </summary>
        public Dimension GravelCrushedGrains { get; set; }

        public override void Calculate()
        {
            if (GravelCrushedGrainsMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы дробленых зерен равно или меньше 0.");
            }

            if (GravelMass.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение массы пробы остатка щебня на сите равно или меньше 0.");
            }

            if (GravelMass.DimensionValue < GravelCrushedGrains.DimensionValue)
            {
                throw new ArgumentOutOfRangeException("Значение массы дробленых зерен больше массы остатка щебня на сите.");
            }

            GravelCrushedGrains.DimensionValue = GravelCrushedGrainsMass.DimensionValue / GravelMass.DimensionValue * 100;

        }

        /// <summary>
        /// Конструктор для создания теста по определению содержания дробленых зерен в щебне из гравия.
        /// </summary>
        public CrushedGrainsGravelTest()
        {
            GravelCrushedGrainsMass = new Dimension("Масса дробленых зерен, г");
            GravelMass = new Dimension("Масса остатка на сите, г");
            GravelCrushedGrains = new Dimension("Содержание дробленых зерен в щебне из гравия, %");

            MaterialEnum = MaterialType.Gravel;
            TestEnum = ExperimentType.Crushed_Grains;
        }
    }
}
