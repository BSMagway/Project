using Microsoft.AspNetCore.Mvc;
using ProjectServer.Data;
using ProjectServer.Entities;
using ProjectServer.Services.Interface;

namespace ProjectServer.Services
{
    public class FullTestsListService : IFullTestsListService
    {
        private readonly AppDbContext _appDb;

        public FullTestsListService(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public List<FullTestsList> Get()
        {
            List<FullTestsList> fullTestsLists = new List<FullTestsList>();


            foreach (MoistureSoilTest test in _appDb.MoistureSoilTests.ToList())
            {
                fullTestsLists.Add(
                    new FullTestsList()
                    {
                        TestId = test.Id,
                        TestDate = test.DateTest,
                        TestNumber = test.MoistureSoilTestId
                    });              
            }

            return fullTestsLists;
        }

    }
}
