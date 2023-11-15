using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;

namespace ProjectServer.Managers.MaterialTests.Gravel
{
    /// <inheritdoc cref="IBulkDensityGravelTestManager"/>
    public class BulkDensityGravelTestManager : IBulkDensityGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению насыпной плотности щебня.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public BulkDensityGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
        }

        public async Task<BulkDensityGravelTest> GetAsync(int bulkDensityGravelTestId)
        {
            var model = await _appDb.BulkDensityGravelTests.FirstOrDefaultAsync(bulkDensityGravelTest => bulkDensityGravelTest.Id == bulkDensityGravelTestId);

            model.Customer = await _customerManager.GetAsync(model.CustomerId);
            model.BulkDensityCylinderWithGravelMass = await _dimensionManager.GetAsync(model.BulkDensityCylinderWithGravelMassId);
            model.BulkDensityCylinderMass = await _dimensionManager.GetAsync(model.BulkDensityCylinderMassId);
            model.CylinderVolume = await _dimensionManager.GetAsync(model.CylinderVolumeId);
            model.GravelBulkDensity = await _dimensionManager.GetAsync(model.GravelBulkDensityId);

            return model;
        }

        public async Task<BulkDensityGravelTest> AddAsync(BulkDensityGravelTest bulkDensityGravelTest)
        {
            bulkDensityGravelTest.BulkDensityCylinderWithGravelMass = await _dimensionManager.AddAsync(bulkDensityGravelTest.BulkDensityCylinderWithGravelMass);
            bulkDensityGravelTest.BulkDensityCylinderMass = await _dimensionManager.AddAsync(bulkDensityGravelTest.BulkDensityCylinderMass);
            bulkDensityGravelTest.CylinderVolume = await _dimensionManager.AddAsync(bulkDensityGravelTest.CylinderVolume);
            bulkDensityGravelTest.GravelBulkDensity = await _dimensionManager.AddAsync(bulkDensityGravelTest.GravelBulkDensity);

            _appDb.Entry(bulkDensityGravelTest).State = EntityState.Added;
            await _appDb.SaveChangesAsync();

            return bulkDensityGravelTest;
        }

        public async Task<bool> RemoveAsync(int bulkDensityGravelTestId)
        {

            var bulkDensityGravelTest = await _appDb.BulkDensityGravelTests.FirstOrDefaultAsync(bulkDensityGravelTest => bulkDensityGravelTest.Id == bulkDensityGravelTestId);

            if (bulkDensityGravelTest == null)
            {
                return false;
            }

            _appDb.BulkDensityGravelTests.Remove(bulkDensityGravelTest);
            _appDb.SaveChanges();

            var resultRemoveBulkDensityCylinderWithGravelMass = await _dimensionManager.RemoveAsync(bulkDensityGravelTest.BulkDensityCylinderWithGravelMassId);
            var resultRemoveBulkDensityCylinderMass = await _dimensionManager.RemoveAsync(bulkDensityGravelTest.BulkDensityCylinderMassId);
            var resultRemoveCylinderVolume = await _dimensionManager.RemoveAsync(bulkDensityGravelTest.CylinderVolumeId);
            var resultRemoveGravelBulkDensity = await _dimensionManager.RemoveAsync(bulkDensityGravelTest.GravelBulkDensityId);

            return true;
        }

        public async Task<bool> UpdateAsync(BulkDensityGravelTest bulkDensityGravelTestUpdate)
        {
            var dbBulkDensityGravelTest = await _appDb.BulkDensityGravelTests
                .FirstOrDefaultAsync(bulkDensityGravelTest => bulkDensityGravelTest.Id == bulkDensityGravelTestUpdate.Id);

            if (dbBulkDensityGravelTest == null)
            {
                return false;
            }

            if (dbBulkDensityGravelTest.TestNumber != bulkDensityGravelTestUpdate.TestNumber)
            {
                dbBulkDensityGravelTest.TestNumber = bulkDensityGravelTestUpdate.TestNumber;
            }

            if (dbBulkDensityGravelTest.MaterialName != bulkDensityGravelTestUpdate.MaterialName)
            {
                dbBulkDensityGravelTest.MaterialName = bulkDensityGravelTestUpdate.MaterialName;
            }

            if (dbBulkDensityGravelTest.CustomerId != bulkDensityGravelTestUpdate.CustomerId)
            {
                dbBulkDensityGravelTest.CustomerId = bulkDensityGravelTestUpdate.CustomerId;
            }

            if (dbBulkDensityGravelTest.DateTest != bulkDensityGravelTestUpdate.DateTest)
            {
                dbBulkDensityGravelTest.DateTest = bulkDensityGravelTestUpdate.DateTest;
            }

            if (dbBulkDensityGravelTest.DocumentTest != bulkDensityGravelTestUpdate.DocumentTest)
            {
                dbBulkDensityGravelTest.DocumentTest = bulkDensityGravelTestUpdate.DocumentTest;
            }

            if (dbBulkDensityGravelTest.BulkDensityCylinderWithGravelMass.DimensionValue != bulkDensityGravelTestUpdate.BulkDensityCylinderWithGravelMass.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(bulkDensityGravelTestUpdate.BulkDensityCylinderWithGravelMass);
            }

            if (dbBulkDensityGravelTest.BulkDensityCylinderMass.DimensionValue != bulkDensityGravelTestUpdate.BulkDensityCylinderMass.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(bulkDensityGravelTestUpdate.BulkDensityCylinderMass);
            }

            if (dbBulkDensityGravelTest.CylinderVolume.DimensionValue != bulkDensityGravelTestUpdate.CylinderVolume.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(bulkDensityGravelTestUpdate.CylinderVolume);
            }

            if (dbBulkDensityGravelTest.GravelBulkDensity.DimensionValue != bulkDensityGravelTestUpdate.GravelBulkDensity.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(bulkDensityGravelTestUpdate.GravelBulkDensity);
            }

            _appDb.SaveChanges();

            return true;
        }
    }
}
