using ProjectServer.Entities;

namespace ProjectServer.Services.Interface
{
    /// <summary>
    /// Интерфейс получения короткого сиписка всех протоколов
    /// </summary>
    public interface IFullShortListTestsService
    {
        /// <summary>
        /// Метод для получения короткого списка всех протоколов
        /// </summary>
        /// <returns></returns>
        public List<FullShortListTests> Get();

    }
}
