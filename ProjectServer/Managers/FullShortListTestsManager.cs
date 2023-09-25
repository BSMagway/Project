using Microsoft.EntityFrameworkCore;
using ProjectServer.Data;
using ProjectCommon.Enums;
using ProjectServer.Interfaces.Managers;
using ProjectCommon.Models;

namespace ProjectServer.Managers
{
    /// <inheritdoc cref="IFullShortListTestsManager"/>
    public class FullShortListTestsManager : IFullShortListTestsManager
    {
        private readonly AppDbContext _appDb;

        public FullShortListTestsManager(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public async Task<List<FullShortListTests>> GetAsync()
        {
            var tests = await _appDb.MoistureSoilTests.ToListAsync();

            var list = new List<FullShortListTests>();
            foreach (var test in tests)
            {
                var model = new FullShortListTests()
                {
                    TestId = test.Id,
                    TestDate = test.DateTest,
                    TestNumber = test.MoistureSoilTestId,
                    MaterialType = MaterialType.Soil,
                    ExperimentType = ExperimentType.Moister
                };

                list.Add(model);
            }

            return list;
        }
    }
}
