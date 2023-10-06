namespace ProjectCommon.Enums
{
    /// <summary>
    /// Виды испытываемых материалов.
    /// </summary>
    public enum MaterialType
    {
        /// <summary>
        /// Неизвестный материал.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Грунт.
        /// </summary>
        Soil = 1,

        /// <summary>
        /// Песок.
        /// </summary>
        Sand = 2,

        /// <summary>
        /// Щебень.
        /// </summary>
        Gravel = 3,

        /// <summary>
        /// Песчано-гравийная смесь.
        /// </summary>
        SandAndGravel = 4,

        /// <summary>
        /// Геотекстиль.
        /// </summary>
        Geotextile = 5,
    }
}
