using Microsoft.EntityFrameworkCore;
using ProjectCommon.Enums;
using ProjectCommon.Models;
using ProjectCommon.Models.Base;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;

namespace ProjectServer.Managers
{
    /// <summary>
    /// Класс для получения списка всех протоколов без значения  измерений.
    /// </summary>
    public class TestsManager : ITestsManager
    {
        private readonly AppDbContext _appDb;

        public TestsManager(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public async Task<Test[]> GetAsync()
        {
            var model = await _appDb.Tests.Include(item => item.Customer).ToArrayAsync();
            return model;
        }
    }
}
