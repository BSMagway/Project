using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.SandAndGravel;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.SandAndGravel;

namespace ProjectServer.Managers.MaterialTests.SandAndGravel
{
    /// <inheritdoc cref="IBulkDensitySandAndGravelTestManager"/>
    public class BulkDensitySandAndGravelTestManager : IBulkDensitySandAndGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<BulkDensitySandAndGravelTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению насыпной плотности песка.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public BulkDensitySandAndGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<BulkDensitySandAndGravelTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<BulkDensitySandAndGravelTest> GetAsync(int bulkDensitySandAndGravelTestId)
        {
            try
            {
                var model = await _appDb.BulkDensitySandAndGravelTests.FirstOrDefaultAsync(bulkDensitySandAndGravelTest => bulkDensitySandAndGravelTest.Id == bulkDensitySandAndGravelTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.BulkDensityCylinderWithSandAndGravelMass = await _dimensionManager.GetAsync(model.BulkDensityCylinderWithSandAndGravelMassId);
                model.BulkDensityCylinderMass = await _dimensionManager.GetAsync(model.BulkDensityCylinderMassId);
                model.CylinderVolume = await _dimensionManager.GetAsync(model.CylinderVolumeId);
                model.SandAndGravelBulkDensity = await _dimensionManager.GetAsync(model.SandAndGravelBulkDensityId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<BulkDensitySandAndGravelTest> AddAsync(BulkDensitySandAndGravelTest bulkDensitySandAndGravelTest)
        {
            try
            {
                bulkDensitySandAndGravelTest.BulkDensityCylinderWithSandAndGravelMass = await _dimensionManager.AddAsync(bulkDensitySandAndGravelTest.BulkDensityCylinderWithSandAndGravelMass);
                bulkDensitySandAndGravelTest.BulkDensityCylinderMass = await _dimensionManager.AddAsync(bulkDensitySandAndGravelTest.BulkDensityCylinderMass);
                bulkDensitySandAndGravelTest.CylinderVolume = await _dimensionManager.AddAsync(bulkDensitySandAndGravelTest.CylinderVolume);
                bulkDensitySandAndGravelTest.SandAndGravelBulkDensity = await _dimensionManager.AddAsync(bulkDensitySandAndGravelTest.SandAndGravelBulkDensity);

                _appDb.Entry(bulkDensitySandAndGravelTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return bulkDensitySandAndGravelTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int bulkDensitySandAndGravelTestId)
        {
            try
            {
                var bulkDensitySandAndGravelTest = await _appDb.BulkDensitySandAndGravelTests.FirstOrDefaultAsync(bulkDensitySandAndGravelTest => bulkDensitySandAndGravelTest.Id == bulkDensitySandAndGravelTestId);

                if (bulkDensitySandAndGravelTest == null)
                {
                    return false;
                }

                _appDb.BulkDensitySandAndGravelTests.Remove(bulkDensitySandAndGravelTest);
                _appDb.SaveChanges();

                var resultRemoveBulkDensityCylinderWithSandAndGravelMass = await _dimensionManager.RemoveAsync(bulkDensitySandAndGravelTest.BulkDensityCylinderWithSandAndGravelMassId);
                var resultRemoveBulkDensityCylinderMass = await _dimensionManager.RemoveAsync(bulkDensitySandAndGravelTest.BulkDensityCylinderMassId);
                var resultRemoveCylinderVolume = await _dimensionManager.RemoveAsync(bulkDensitySandAndGravelTest.CylinderVolumeId);
                var resultRemoveSandAndGravelBulkDensity = await _dimensionManager.RemoveAsync(bulkDensitySandAndGravelTest.SandAndGravelBulkDensityId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(BulkDensitySandAndGravelTest bulkDensitySandAndGravelTestUpdate)
        {
            try
            {
                var dbbulkDensitySandAndGravelTest = await _appDb.BulkDensitySandAndGravelTests
                                .FirstOrDefaultAsync(bulkDensitySandAndGravelTest => bulkDensitySandAndGravelTest.Id == bulkDensitySandAndGravelTestUpdate.Id);

                if (dbbulkDensitySandAndGravelTest == null)
                {
                    return false;
                }

                if (dbbulkDensitySandAndGravelTest.TestNumber != bulkDensitySandAndGravelTestUpdate.TestNumber)
                {
                    dbbulkDensitySandAndGravelTest.TestNumber = bulkDensitySandAndGravelTestUpdate.TestNumber;
                }

                if (dbbulkDensitySandAndGravelTest.MaterialName != bulkDensitySandAndGravelTestUpdate.MaterialName)
                {
                    dbbulkDensitySandAndGravelTest.MaterialName = bulkDensitySandAndGravelTestUpdate.MaterialName;
                }

                if (dbbulkDensitySandAndGravelTest.CustomerId != bulkDensitySandAndGravelTestUpdate.CustomerId)
                {
                    dbbulkDensitySandAndGravelTest.CustomerId = bulkDensitySandAndGravelTestUpdate.CustomerId;
                }

                if (dbbulkDensitySandAndGravelTest.DateTest != bulkDensitySandAndGravelTestUpdate.DateTest)
                {
                    dbbulkDensitySandAndGravelTest.DateTest = bulkDensitySandAndGravelTestUpdate.DateTest;
                }

                if (dbbulkDensitySandAndGravelTest.DocumentTest != bulkDensitySandAndGravelTestUpdate.DocumentTest)
                {
                    dbbulkDensitySandAndGravelTest.DocumentTest = bulkDensitySandAndGravelTestUpdate.DocumentTest;
                }

                if (dbbulkDensitySandAndGravelTest.BulkDensityCylinderWithSandAndGravelMass.DimensionValue != bulkDensitySandAndGravelTestUpdate.BulkDensityCylinderWithSandAndGravelMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(bulkDensitySandAndGravelTestUpdate.BulkDensityCylinderWithSandAndGravelMass);
                }

                if (dbbulkDensitySandAndGravelTest.BulkDensityCylinderMass.DimensionValue != bulkDensitySandAndGravelTestUpdate.BulkDensityCylinderMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(bulkDensitySandAndGravelTestUpdate.BulkDensityCylinderMass);
                }

                if (dbbulkDensitySandAndGravelTest.CylinderVolume.DimensionValue != bulkDensitySandAndGravelTestUpdate.CylinderVolume.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(bulkDensitySandAndGravelTestUpdate.CylinderVolume);
                }

                if (dbbulkDensitySandAndGravelTest.SandAndGravelBulkDensity.DimensionValue != bulkDensitySandAndGravelTestUpdate.SandAndGravelBulkDensity.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(bulkDensitySandAndGravelTestUpdate.SandAndGravelBulkDensity);
                }

                _appDb.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
