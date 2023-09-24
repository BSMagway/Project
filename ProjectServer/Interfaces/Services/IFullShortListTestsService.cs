using ProjectCommon.Models;

namespace ProjectServer.Interfaces.Services
{
    /// <summary>
    /// Интерфейс получения короткого сиписка всех протоколов.
    /// </summary>
    public interface IFullShortListTestsService
    {
        /// <summary>
        /// Метод для получения короткого списка всех протоколов.
        /// </summary>
        /// <returns></returns>
        public Task<List<FullShortListTests>> GetAsync();
    }
}
