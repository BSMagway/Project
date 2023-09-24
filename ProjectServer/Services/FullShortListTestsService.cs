using Microsoft.EntityFrameworkCore;
using ProjectServer.Data;
using ProjectCommon.Enums;
using ProjectServer.Interfaces.Services;
using ProjectCommon.Models;

namespace ProjectServer.Services
{
    /// <inheritdoc cref="ICustomerService"/>
    public class FullShortListTestsService : IFullShortListTestsService
    {
        private readonly AppDbContext _appDb;

        public FullShortListTestsService(AppDbContext appDb)
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
