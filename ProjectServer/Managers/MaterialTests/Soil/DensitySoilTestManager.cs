using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Soil
{
    /// <inheritdoc cref="ICustomerManager"/>
    public class DensitySoilTestManager : IDensitySoilTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<DensitySoilTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению влажности грунта.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public DensitySoilTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<DensitySoilTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<DensitySoilTest> GetAsync(int densitySoilTestId)
        {
            try
            {
                var model = await _appDb.DensitySoilTests.FirstOrDefaultAsync(densitySoilTest => densitySoilTest.Id == densitySoilTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.SoilMassWithRingAndPlate = await _dimensionManager.GetAsync(model.SoilMassWithRingAndPlateId);
                model.RingMass = await _dimensionManager.GetAsync(model.RingMassId);
                model.PlateMass = await _dimensionManager.GetAsync(model.PlateMassId);
                model.InternalVolumeRing = await _dimensionManager.GetAsync(model.InternalVolumeRingId);
                model.Density = await _dimensionManager.GetAsync(model.DensityId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<DensitySoilTest> AddAsync(DensitySoilTest densitySoilTest)
        {
            try
            {
                densitySoilTest.SoilMassWithRingAndPlate = await _dimensionManager.AddAsync(densitySoilTest.SoilMassWithRingAndPlate);
                densitySoilTest.RingMass = await _dimensionManager.AddAsync(densitySoilTest.RingMass);
                densitySoilTest.PlateMass = await _dimensionManager.AddAsync(densitySoilTest.PlateMass);
                densitySoilTest.InternalVolumeRing = await _dimensionManager.AddAsync(densitySoilTest.InternalVolumeRing);
                densitySoilTest.Density = await _dimensionManager.AddAsync(densitySoilTest.Density);

                _appDb.Entry(densitySoilTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return densitySoilTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int densitySoilTestId)
        {
            try
            {
                var densitySoilTest = await _appDb.DensitySoilTests.FirstOrDefaultAsync(x => x.Id == densitySoilTestId);

                if (densitySoilTest == null)
                {
                    return false;
                }

                _appDb.DensitySoilTests.Remove(densitySoilTest);
                _appDb.SaveChanges();

                var resultRemoveSoilMassWithRingAndPlate = await _dimensionManager.RemoveAsync(densitySoilTest.SoilMassWithRingAndPlate.Id);
                var resultRemoveRingMass = await _dimensionManager.RemoveAsync(densitySoilTest.RingMass.Id);
                var resultRemovePlateMass = await _dimensionManager.RemoveAsync(densitySoilTest.PlateMass.Id);
                var resultRemoveInternalVolumeRing = await _dimensionManager.RemoveAsync(densitySoilTest.InternalVolumeRing.Id);
                var resultRemoveDensity = await _dimensionManager.RemoveAsync(densitySoilTest.Density.Id);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(DensitySoilTest densitySoilTestUpdate)
        {
            try
            {
                var dbDensitySoilTest = await _appDb.DensitySoilTests
                    .FirstOrDefaultAsync(densitySoilTest => densitySoilTest.Id == densitySoilTestUpdate.Id);

                if (dbDensitySoilTest == null)
                {
                    return false;
                }

                if (dbDensitySoilTest.TestNumber != densitySoilTestUpdate.TestNumber)
                {
                    dbDensitySoilTest.TestNumber = densitySoilTestUpdate.TestNumber;
                }

                if (dbDensitySoilTest.MaterialName != densitySoilTestUpdate.MaterialName)
                {
                    dbDensitySoilTest.MaterialName = densitySoilTestUpdate.MaterialName;
                }

                if (dbDensitySoilTest.CustomerId != densitySoilTestUpdate.CustomerId)
                {
                    dbDensitySoilTest.CustomerId = densitySoilTestUpdate.CustomerId;
                }

                if (dbDensitySoilTest.DateTest != densitySoilTestUpdate.DateTest)
                {
                    dbDensitySoilTest.DateTest = densitySoilTestUpdate.DateTest;
                }

                if (dbDensitySoilTest.DocumentTest != densitySoilTestUpdate.DocumentTest)
                {
                    dbDensitySoilTest.DocumentTest = densitySoilTestUpdate.DocumentTest;
                }

                if (dbDensitySoilTest.SoilMassWithRingAndPlate.DimensionValue != densitySoilTestUpdate.SoilMassWithRingAndPlate.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(densitySoilTestUpdate.SoilMassWithRingAndPlate);
                }

                if (dbDensitySoilTest.RingMass.DimensionValue != densitySoilTestUpdate.RingMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(densitySoilTestUpdate.RingMass);
                }

                if (dbDensitySoilTest.PlateMass.DimensionValue != densitySoilTestUpdate.PlateMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(densitySoilTestUpdate.PlateMass);
                }

                if (dbDensitySoilTest.InternalVolumeRing.DimensionValue != densitySoilTestUpdate.InternalVolumeRing.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(densitySoilTestUpdate.InternalVolumeRing);
                }

                if (dbDensitySoilTest.Density.DimensionValue != densitySoilTestUpdate.Density.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(densitySoilTestUpdate.Density);
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
