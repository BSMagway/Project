namespace ProjectCommon.Enums
{
    /// <summary>
    /// Список определяемых показателей.
    /// </summary>
    public enum ExperimentType
    {
        /// <summary>
        /// Неизвестный показатель.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Влажность.
        /// </summary>
        Moister = 1,

        /// <summary>
        /// Плотность.
        /// </summary>
        Density = 2,

        /// <summary>
        /// Граница текучести.
        /// </summary>
        Yield_Limit = 3,

        /// <summary>
        /// Граница раскатывания.
        /// </summary>
        Rolling_Boundary = 4,

        /// <summary>
        /// Содержание дробленых зерен в щебне из гравия.
        /// </summary>
        Crushed_Grains = 5,

        /// <summary>
        /// Содержание зерен слабых пород.
        /// </summary>
        Weak_Grains = 6,

        /// <summary>
        /// Содержание глины в комках.
        /// </summary>
        Clay_In_Lumps = 7,

        /// <summary>
        /// Содержание зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        Flaky_Grains = 8,

        /// <summary>
        /// Содержание пылевидных и глинистых частиц.
        /// </summary>
        Dust = 9,

        /// <summary>
        /// Дробимость.
        /// </summary>
        Crushability = 10,

        /// <summary>
        /// Насыпная плотность.
        /// </summary>
        Bulk_Density = 11,

    }
}
