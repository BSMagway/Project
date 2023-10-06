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
    }
}
