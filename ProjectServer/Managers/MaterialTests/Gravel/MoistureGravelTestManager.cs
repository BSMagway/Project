using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Gravel
{
    /// <inheritdoc cref="IMoistureGravelTestManager"/>
    public class MoistureGravelTestManager : IMoistureGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<MoistureGravelTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению влажности щебня.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public MoistureGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<MoistureGravelTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<MoistureGravelTest> GetAsync(int moistureGravelTestId)
        {
            try
            {
                var model = await _appDb.MoistureGravelTests.FirstOrDefaultAsync(moistureGravelTest => moistureGravelTest.Id == moistureGravelTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.GravelWetMass = await _dimensionManager.GetAsync(model.GravelWetMassId);
                model.GravelDryMass = await _dimensionManager.GetAsync(model.GravelDryMassId);
                model.Moisture = await _dimensionManager.GetAsync(model.MoistureId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<MoistureGravelTest> AddAsync(MoistureGravelTest moistureGravelTest)
        {
            try
            {
                moistureGravelTest.GravelWetMass = await _dimensionManager.AddAsync(moistureGravelTest.GravelWetMass);
                moistureGravelTest.GravelDryMass = await _dimensionManager.AddAsync(moistureGravelTest.GravelDryMass);
                moistureGravelTest.Moisture = await _dimensionManager.AddAsync(moistureGravelTest.Moisture);

                _appDb.Entry(moistureGravelTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return moistureGravelTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int moistureGravelTestId)
        {
            try
            {
                var moistureGravelTest = await _appDb.MoistureGravelTests.FirstOrDefaultAsync(moistureGravelTest => moistureGravelTest.Id == moistureGravelTestId);

                if (moistureGravelTest == null)
                {
                    return false;
                }

                _appDb.MoistureGravelTests.Remove(moistureGravelTest);
                _appDb.SaveChanges();

                var resultRemoveGravelWetMass = await _dimensionManager.RemoveAsync(moistureGravelTest.GravelWetMassId);
                var resultRemoveGravelDryMass = await _dimensionManager.RemoveAsync(moistureGravelTest.GravelDryMassId);
                var resultRemoveMoisture = await _dimensionManager.RemoveAsync(moistureGravelTest.MoistureId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(MoistureGravelTest moistureGravelTestUpdate)
        {
            try
            {
                var dbMoistureGravelTest = await _appDb.MoistureGravelTests
                    .FirstOrDefaultAsync(moistureGravelTest => moistureGravelTest.Id == moistureGravelTestUpdate.Id);

                if (dbMoistureGravelTest == null)
                {
                    return false;
                }

                if (dbMoistureGravelTest.TestNumber != moistureGravelTestUpdate.TestNumber)
                {
                    dbMoistureGravelTest.TestNumber = moistureGravelTestUpdate.TestNumber;
                }

                if (dbMoistureGravelTest.MaterialName != moistureGravelTestUpdate.MaterialName)
                {
                    dbMoistureGravelTest.MaterialName = moistureGravelTestUpdate.MaterialName;
                }

                if (dbMoistureGravelTest.CustomerId != moistureGravelTestUpdate.CustomerId)
                {
                    dbMoistureGravelTest.CustomerId = moistureGravelTestUpdate.CustomerId;
                }

                if (dbMoistureGravelTest.DateTest != moistureGravelTestUpdate.DateTest)
                {
                    dbMoistureGravelTest.DateTest = moistureGravelTestUpdate.DateTest;
                }

                if (dbMoistureGravelTest.DocumentTest != moistureGravelTestUpdate.DocumentTest)
                {
                    dbMoistureGravelTest.DocumentTest = moistureGravelTestUpdate.DocumentTest;
                }

                if (dbMoistureGravelTest.GravelWetMass.DimensionValue != moistureGravelTestUpdate.GravelWetMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureGravelTestUpdate.GravelWetMass);
                }

                if (dbMoistureGravelTest.GravelDryMass.DimensionValue != moistureGravelTestUpdate.GravelDryMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureGravelTestUpdate.GravelDryMass);
                }

                if (dbMoistureGravelTest.Moisture.DimensionValue != moistureGravelTestUpdate.Moisture.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureGravelTestUpdate.Moisture);
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
