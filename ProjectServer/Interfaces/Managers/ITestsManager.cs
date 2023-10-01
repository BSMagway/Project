using ProjectCommon.Models;
using ProjectCommon.Models.Base;

namespace ProjectServer.Interfaces.Managers
{
    /// <summary>
    /// Интерфейс получения короткого списка всех протоколов.
    /// </summary>
    public interface ITestsManager
    {
        /// <summary>
        /// Метод для получения короткого списка всех протоколов.
        /// </summary>
        /// <returns></returns>
        public Task<Test[]> GetAsync();
    }
}
