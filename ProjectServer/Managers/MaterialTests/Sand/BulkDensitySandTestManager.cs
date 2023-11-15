using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Sand;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;

namespace ProjectServer.Managers.MaterialTests.Sand
{
    /// <inheritdoc cref="IBulkDensitySandTestManager"/>
    public class BulkDensitySandTestManager : IBulkDensitySandTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению насыпной плотности песка.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public BulkDensitySandTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
        }

        public async Task<BulkDensitySandTest> GetAsync(int bulkDensitySandTestId)
        {
            var model = await _appDb.BulkDensitySandTests.FirstOrDefaultAsync(bulkDensitySandTest => bulkDensitySandTest.Id == bulkDensitySandTestId);

            model.Customer = await _customerManager.GetAsync(model.CustomerId);
            model.BulkDensityCylinderWithSandMass = await _dimensionManager.GetAsync(model.BulkDensityCylinderWithSandMassId);
            model.BulkDensityCylinderMass = await _dimensionManager.GetAsync(model.BulkDensityCylinderMassId);
            model.CylinderVolume = await _dimensionManager.GetAsync(model.CylinderVolumeId);
            model.SandBulkDensity = await _dimensionManager.GetAsync(model.SandBulkDensityId);

            return model;
        }

        public async Task<BulkDensitySandTest> AddAsync(BulkDensitySandTest bulkDensitySandTest)
        {
            bulkDensitySandTest.BulkDensityCylinderWithSandMass = await _dimensionManager.AddAsync(bulkDensitySandTest.BulkDensityCylinderWithSandMass);
            bulkDensitySandTest.BulkDensityCylinderMass = await _dimensionManager.AddAsync(bulkDensitySandTest.BulkDensityCylinderMass);
            bulkDensitySandTest.CylinderVolume = await _dimensionManager.AddAsync(bulkDensitySandTest.CylinderVolume);
            bulkDensitySandTest.SandBulkDensity = await _dimensionManager.AddAsync(bulkDensitySandTest.SandBulkDensity);

            _appDb.Entry(bulkDensitySandTest).State = EntityState.Added;
            await _appDb.SaveChangesAsync();

            return bulkDensitySandTest;
        }

        public async Task<bool> RemoveAsync(int bulkDensitySandTestId)
        {

            var bulkDensitySandTest = await _appDb.BulkDensitySandTests.FirstOrDefaultAsync(bulkDensitySandTest => bulkDensitySandTest.Id == bulkDensitySandTestId);

            if (bulkDensitySandTest == null)
            {
                return false;
            }

            _appDb.BulkDensitySandTests.Remove(bulkDensitySandTest);
            _appDb.SaveChanges();

            var resultRemoveBulkDensityCylinderWithSandMass = await _dimensionManager.RemoveAsync(bulkDensitySandTest.BulkDensityCylinderWithSandMassId);
            var resultRemoveBulkDensityCylinderMass = await _dimensionManager.RemoveAsync(bulkDensitySandTest.BulkDensityCylinderMassId);
            var resultRemoveCylinderVolume = await _dimensionManager.RemoveAsync(bulkDensitySandTest.CylinderVolumeId);
            var resultRemoveSandBulkDensity = await _dimensionManager.RemoveAsync(bulkDensitySandTest.SandBulkDensityId);

            return true;
        }

        public async Task<bool> UpdateAsync(BulkDensitySandTest bulkDensitySandTestUpdate)
        {
            var dbBulkDensitySandTest = await _appDb.BulkDensitySandTests
                .FirstOrDefaultAsync(bulkDensitySandTest => bulkDensitySandTest.Id == bulkDensitySandTestUpdate.Id);

            if (dbBulkDensitySandTest == null)
            {
                return false;
            }

            if (dbBulkDensitySandTest.TestNumber != bulkDensitySandTestUpdate.TestNumber)
            {
                dbBulkDensitySandTest.TestNumber = bulkDensitySandTestUpdate.TestNumber;
            }

            if (dbBulkDensitySandTest.MaterialName != bulkDensitySandTestUpdate.MaterialName)
            {
                dbBulkDensitySandTest.MaterialName = bulkDensitySandTestUpdate.MaterialName;
            }

            if (dbBulkDensitySandTest.CustomerId != bulkDensitySandTestUpdate.CustomerId)
            {
                dbBulkDensitySandTest.CustomerId = bulkDensitySandTestUpdate.CustomerId;
            }

            if (dbBulkDensitySandTest.DateTest != bulkDensitySandTestUpdate.DateTest)
            {
                dbBulkDensitySandTest.DateTest = bulkDensitySandTestUpdate.DateTest;
            }

            if (dbBulkDensitySandTest.DocumentTest != bulkDensitySandTestUpdate.DocumentTest)
            {
                dbBulkDensitySandTest.DocumentTest = bulkDensitySandTestUpdate.DocumentTest;
            }

            if (dbBulkDensitySandTest.BulkDensityCylinderWithSandMass.DimensionValue != bulkDensitySandTestUpdate.BulkDensityCylinderWithSandMass.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(bulkDensitySandTestUpdate.BulkDensityCylinderWithSandMass);
            }

            if (dbBulkDensitySandTest.BulkDensityCylinderMass.DimensionValue != bulkDensitySandTestUpdate.BulkDensityCylinderMass.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(bulkDensitySandTestUpdate.BulkDensityCylinderMass);
            }

            if (dbBulkDensitySandTest.CylinderVolume.DimensionValue != bulkDensitySandTestUpdate.CylinderVolume.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(bulkDensitySandTestUpdate.CylinderVolume);
            }

            if (dbBulkDensitySandTest.SandBulkDensity.DimensionValue != bulkDensitySandTestUpdate.SandBulkDensity.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(bulkDensitySandTestUpdate.SandBulkDensity);
            }

            _appDb.SaveChanges();

            return true;
        }
    }
}
