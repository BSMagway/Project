using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Soil
{
    /// <inheritdoc cref="IRollingBoundarySoilTestManager"/>
    public class RollingBoundarySoilTestManager : IRollingBoundarySoilTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению границы текучести грунта.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public RollingBoundarySoilTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
        }

        public async Task<RollingBoundarySoilTest> GetAsync(int rollingBoundarySoilTestId)
        {
            var model = await _appDb.RollingBoundarySoilTests.FirstOrDefaultAsync(rollingBoundarySoilTest => rollingBoundarySoilTest.Id == rollingBoundarySoilTestId);

            model.Customer = await _customerManager.GetAsync(model.CustomerId);
            model.SoilWetMassWithBox = await _dimensionManager.GetAsync(model.SoilWetMassWithBoxId);
            model.SoilDryMassWithBox = await _dimensionManager.GetAsync(model.SoilDryMassWithBoxId);
            model.BoxMass = await _dimensionManager.GetAsync(model.BoxMassId);
            model.RollingBoundary = await _dimensionManager.GetAsync(model.RollingBoundaryId);

            return model;
        }

        public async Task<RollingBoundarySoilTest> AddAsync(RollingBoundarySoilTest rollingBoundarySoilTest)
        {
            rollingBoundarySoilTest.BoxMass = await _dimensionManager.AddAsync(rollingBoundarySoilTest.BoxMass);
            rollingBoundarySoilTest.SoilWetMassWithBox = await _dimensionManager.AddAsync(rollingBoundarySoilTest.SoilWetMassWithBox);
            rollingBoundarySoilTest.SoilDryMassWithBox = await _dimensionManager.AddAsync(rollingBoundarySoilTest.SoilDryMassWithBox);
            rollingBoundarySoilTest.RollingBoundary = await _dimensionManager.AddAsync(rollingBoundarySoilTest.RollingBoundary);

            _appDb.Entry(rollingBoundarySoilTest).State = EntityState.Added;
            await _appDb.SaveChangesAsync();

            return rollingBoundarySoilTest;
        }

        public async Task<bool> RemoveAsync(int rollingBoundarySoilTestId)
        {

            var rollingBoundarySoilTest = await _appDb.RollingBoundarySoilTests.FirstOrDefaultAsync(rollingBoundarySoilTest => rollingBoundarySoilTest.Id == rollingBoundarySoilTestId);

            if (rollingBoundarySoilTest == null)
            {
                return false;
            }

            _appDb.RollingBoundarySoilTests.Remove(rollingBoundarySoilTest);
            _appDb.SaveChanges();

            var resultRemoveSoilWetMassWithBox = await _dimensionManager.RemoveAsync(rollingBoundarySoilTest.SoilWetMassWithBoxId);
            var resultRemoveSoilDryMassWithBox = await _dimensionManager.RemoveAsync(rollingBoundarySoilTest.SoilDryMassWithBoxId);
            var resultRemoveBoxMass = await _dimensionManager.RemoveAsync(rollingBoundarySoilTest.BoxMassId);
            var resultRemoveRollingBoundarySoil = await _dimensionManager.RemoveAsync(rollingBoundarySoilTest.RollingBoundaryId);

            return true;
        }

        public async Task<bool> UpdateAsync(RollingBoundarySoilTest rollingBoundarySoilTestUpdate)
        {
            var dbRollingBoundarySoilTest = await _appDb.RollingBoundarySoilTests
                .FirstOrDefaultAsync(rollingBoundarySoilTest => rollingBoundarySoilTest.Id == rollingBoundarySoilTestUpdate.Id);

            if (dbRollingBoundarySoilTest == null)
            {
                return false;
            }

            if (dbRollingBoundarySoilTest.TestNumber != rollingBoundarySoilTestUpdate.TestNumber)
            {
                dbRollingBoundarySoilTest.TestNumber = rollingBoundarySoilTestUpdate.TestNumber;
            }

            if (dbRollingBoundarySoilTest.MaterialName != rollingBoundarySoilTestUpdate.MaterialName)
            {
                dbRollingBoundarySoilTest.MaterialName = rollingBoundarySoilTestUpdate.MaterialName;
            }

            if (dbRollingBoundarySoilTest.CustomerId != rollingBoundarySoilTestUpdate.CustomerId)
            {
                dbRollingBoundarySoilTest.CustomerId = rollingBoundarySoilTestUpdate.CustomerId;
            }

            if (dbRollingBoundarySoilTest.DateTest != rollingBoundarySoilTestUpdate.DateTest)
            {
                dbRollingBoundarySoilTest.DateTest = rollingBoundarySoilTestUpdate.DateTest;
            }

            if (dbRollingBoundarySoilTest.DocumentTest != rollingBoundarySoilTestUpdate.DocumentTest)
            {
                dbRollingBoundarySoilTest.DocumentTest = rollingBoundarySoilTestUpdate.DocumentTest;
            }

            if (dbRollingBoundarySoilTest.SoilDryMassWithBox.DimensionValue != rollingBoundarySoilTestUpdate.SoilDryMassWithBox.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(rollingBoundarySoilTestUpdate.SoilDryMassWithBox);
            }

            if (dbRollingBoundarySoilTest.SoilWetMassWithBox.DimensionValue != rollingBoundarySoilTestUpdate.SoilWetMassWithBox.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(rollingBoundarySoilTestUpdate.SoilWetMassWithBox);
            }

            if (dbRollingBoundarySoilTest.BoxMass.DimensionValue != rollingBoundarySoilTestUpdate.BoxMass.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(rollingBoundarySoilTestUpdate.BoxMass);
            }

            if (dbRollingBoundarySoilTest.RollingBoundary.DimensionValue != rollingBoundarySoilTestUpdate.RollingBoundary.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(rollingBoundarySoilTestUpdate.RollingBoundary);
            }

            _appDb.SaveChanges();

            return true;
        }
    }
}
