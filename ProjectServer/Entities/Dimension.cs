namespace ProjectServer.Entities
{
    public class Dimension<T>
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Название испытанной величины
        /// </summary>
        public string DimensionName { get; set; }
        /// <summary>
        /// Значение испытанной величины
        /// </summary>
        public T DimensionValue { get; set; }
    }
}
