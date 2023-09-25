using ProjectCommon.Models;

namespace ProjectServer.Interfaces.Managers
{
    /// <summary>
    /// Интерфейс получения короткого списка всех протоколов.
    /// </summary>
    public interface IFullShortListTestsManager
    {
        /// <summary>
        /// Метод для получения короткого списка всех протоколов.
        /// </summary>
        /// <returns></returns>
        public Task<List<FullShortListTests>> GetAsync();
    }
}
