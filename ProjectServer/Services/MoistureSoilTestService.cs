using ProjectServer.Data;
using ProjectServer.Entities;
using ProjectServer.Services.Interface;

namespace ProjectServer.Services
{
    public class MoistureSoilTestService : IMoistureSoilTestService
    {
        private readonly AppDbContext _appDb;

        public MoistureSoilTestService(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public MoistureSoilTest Get(Guid notepadId)
        {
            throw new NotImplementedException();
        }

        public MoistureSoilTest Add(MoistureSoilTest moistureSoilTest)
        {
            moistureSoilTest.Id = Guid.NewGuid();

            var entity = _appDb.MoistureSoilTests.Add(moistureSoilTest);
            _appDb.SaveChanges();

            return entity.Entity;
        }

        public bool Remove(Guid moistureSoilTestId)
        {

            var moistureSoilTest = _appDb.MoistureSoilTests
                .Where(x => x.Id == moistureSoilTestId)
                .FirstOrDefault();

            if (moistureSoilTest == null)
            {
                return false;
            }

            _appDb.MoistureSoilTests.Remove(moistureSoilTest);
            _appDb.SaveChanges();

            return true;
        }

        public bool Update(MoistureSoilTest moistureSoilTest)
        {
            var dbMoistureSoilTest = _appDb.MoistureSoilTests
                .Where(x => x.MoistureSoilTestId == moistureSoilTest.MoistureSoilTestId)
                .FirstOrDefault();

            if (dbMoistureSoilTest == null)
            {
                return false;
            }

            dbMoistureSoilTest.Id = moistureSoilTest.Id;
            dbMoistureSoilTest.MaterialName = moistureSoilTest.MaterialName;
            dbMoistureSoilTest.CostumerId = moistureSoilTest.CostumerId;
            dbMoistureSoilTest.DateTest = moistureSoilTest.DateTest;
            dbMoistureSoilTest.DocumentTest = moistureSoilTest.DocumentTest;
            dbMoistureSoilTest.Dimensions = moistureSoilTest.Dimensions;
            _appDb.SaveChanges();

            return true;
        }
    }
}
