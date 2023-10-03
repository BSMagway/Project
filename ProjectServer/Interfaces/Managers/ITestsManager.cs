using ProjectCommon.Models;
using ProjectCommon.Models.Base;

namespace ProjectServer.Interfaces.Managers
{
    /// <summary>
    /// Интерфейс получения списка всех протоколов без значений измерений.
    /// </summary>
    public interface ITestsManager
    {
        /// <summary>
        /// Метод для получения списка всех протоколов без значений измерений.
        /// </summary>
        /// <returns></returns>
        public Task<Test[]> GetAsync();
    }
}
