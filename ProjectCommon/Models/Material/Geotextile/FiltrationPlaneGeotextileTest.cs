using ProjectCommon.Enums;
using ProjectCommon.Models.Base;

namespace ProjectCommon.Models.Material.Geotextile
{
    /// <summary>
    /// Класс для хранения протоколов испытаний по определению фильтрации в плоскости геотекстильного полотна.
    /// </summary>
    public class FiltrationPlaneGeotextileTest : Test
    {

        /// <summary>
        /// Id результата измерения объема профильтровавшейся воды.
        /// </summary>
        public int? WaterVolumeId { get; set; }

        /// <summary>
        /// Результат измерения  объема профильтровавшейся воды.
        /// </summary>
        public Dimension WaterVolume { get; set; }

        /// <summary>
        /// Id результата измерения времени за которое профильтровалась вода.
        /// </summary>
        public int? TimeWaterFiltrationId { get; set; }

        /// <summary>
        /// Результат измерения времени за которое профильтровалась вода.
        /// </summary>
        public Dimension TimeWaterFiltration { get; set; }

        /// <summary>
        /// Id результата измерения толщины пакета образцов.
        /// </summary>
        public int? ThicknessPackageId { get; set; }

        /// <summary>
        /// Результат измерения толщины пакета образцов.
        /// </summary>
        public Dimension ThicknessPackage { get; set; }

        /// <summary>
        /// Id результата измерения фактической температуры воды.
        /// </summary>
        public int? ActualTemperatureId { get; set; }

        /// <summary>
        /// Результат измерения фактической температуры воды.
        /// </summary>
        public Dimension ActualTemperature { get; set; }

        /// <summary>
        /// Id результата определения  фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        public int? GeotextileFiltrationId { get; set; }

        /// <summary>
        /// Рассчитанное значение  фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        public Dimension GeotextileFiltration { get; set; }

        public override void Calculate()
        {
            if (WaterVolume.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение объема профильтровавшейся воды равно или меньше 0.");
            }

            if (TimeWaterFiltration.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение времени за которое профильтровалась вода равно или меньше 0.");
            }

            if (ThicknessPackage.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение толщины пакета образцов геотекстиля равно или меньше 0.");
            }

            if (ActualTemperature.DimensionValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение фактической температуры воды равно или меньше 0.");
            }

            GeotextileFiltration.DimensionValue = (864 * WaterVolume.DimensionValue * 16.5) /
                                                   (TimeWaterFiltration.DimensionValue * 10 * ThicknessPackage.DimensionValue * 10 *
                                                   (0.7 + 0.03 * ActualTemperature.DimensionValue));
        }

        /// <summary>
        /// Конструктор для создания теста по определению  фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        public FiltrationPlaneGeotextileTest()
        {
            WaterVolume = new Dimension("Объем профильтровавшейся воды, м\u00B3");
            TimeWaterFiltration = new Dimension("Время за которое профильтровалась вода, с");
            ThicknessPackage = new Dimension("Толщина пакета образцов геотекстиля, см");
            ActualTemperature = new Dimension("Фактическая температура воды, \u2103");
            GeotextileFiltration = new Dimension("Фильтрация в плоскости геотекстильного полотна, м/сут");

            MaterialEnum = MaterialType.Geotextile;
            TestEnum = ExperimentType.Filtration;
        }
    }
}
