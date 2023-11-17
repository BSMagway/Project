using Microsoft.EntityFrameworkCore;
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
        private readonly ILogger<TestsManager> _logger;

        public TestsManager(AppDbContext appDb, ILogger<TestsManager> logger)
        {
            _appDb = appDb;
            _logger = logger;
        }

        public async Task<Test[]> GetAsync()
        {
            try
            {
                var model = await _appDb.Tests.Include(item => item.Customer).ToArrayAsync();
                return model;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }


        }
    }
}
