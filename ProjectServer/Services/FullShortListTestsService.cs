using Microsoft.AspNetCore.Mvc;
using ProjectServer.Data;
using ProjectServer.Entities;
using ProjectServer.Services.Interface;

namespace ProjectServer.Services
{
    public class FullShortListTestsService : IFullShortListTestsService
    {
        #region Enum
        enum SelectMaterialTypeTestEnum
        {
            Soil,
            Sand,
            Gravel,
            SandAndGravel,
            Geotextile
        }

        enum SelectTypeTestEnum
        {
            Moister
        }

        #endregion

        #region Fields
        private readonly AppDbContext _appDb;
        #endregion

        #region Constructor
        public FullShortListTestsService(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        #endregion

        #region Methods
        public List<FullShortListTests> Get()
        {
            List<FullShortListTests> fullTestsLists = new List<FullShortListTests>();


            foreach (MoistureSoilTest test in _appDb.MoistureSoilTests.ToList())
            {
                fullTestsLists.Add(
                    new FullShortListTests()
                    {
                        TestId = test.Id,
                        TestDate = test.DateTest,
                        TestNumber = test.MoistureSoilTestId,
                        MaterialTypeEnumNumber = (int)SelectMaterialTypeTestEnum.Soil,
                        TestTypeEnumNumber = (int)SelectTypeTestEnum.Moister

                    });              
            }

            return fullTestsLists;
        }
        #endregion
    }
}
