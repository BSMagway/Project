namespace ProjectServer.Entities
{
    public class Dimension
    {
        public Guid Id { get; set; }
        public Guid MoistureSoilTestId { get; set; }
        /// <summary>
        /// Название испытанной величины
        /// </summary>
        public string DimensionName { get; set; }
        /// <summary>
        /// Значение испытанной величины
        /// </summary>
        public double DimensionValue { get; set; }
    }
}
