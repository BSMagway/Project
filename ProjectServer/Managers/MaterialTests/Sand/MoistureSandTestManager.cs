using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Sand;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;
using ProjectServer.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Sand
{
    /// <inheritdoc cref="IMoistureSandTestManager"/>
    public class MoistureSandTestManager : IMoistureSandTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<MoistureSandTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению влажности песка.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public MoistureSandTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<MoistureSandTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<MoistureSandTest> GetAsync(int moistureSandTestId)
        {
            try
            {
                var model = await _appDb.MoistureSandTests.FirstOrDefaultAsync(moistureSandTest => moistureSandTest.Id == moistureSandTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.SandWetMass = await _dimensionManager.GetAsync(model.SandWetMassId);
                model.SandDryMass = await _dimensionManager.GetAsync(model.SandDryMassId);
                model.SandMoisture = await _dimensionManager.GetAsync(model.SandMoistureId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<MoistureSandTest> AddAsync(MoistureSandTest moistureSandTest)
        {
            try
            {
                moistureSandTest.SandWetMass = await _dimensionManager.AddAsync(moistureSandTest.SandWetMass);
                moistureSandTest.SandDryMass = await _dimensionManager.AddAsync(moistureSandTest.SandDryMass);
                moistureSandTest.SandMoisture = await _dimensionManager.AddAsync(moistureSandTest.SandMoisture);

                _appDb.Entry(moistureSandTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return moistureSandTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int moistureSandTestId)
        {
            try
            {
                var moistureSandTest = await _appDb.MoistureSandTests.FirstOrDefaultAsync(moistureSandTest => moistureSandTest.Id == moistureSandTestId);

                if (moistureSandTest == null)
                {
                    return false;
                }

                _appDb.MoistureSandTests.Remove(moistureSandTest);
                _appDb.SaveChanges();

                var resultRemoveSandWetMass = await _dimensionManager.RemoveAsync(moistureSandTest.SandWetMassId);
                var resultRemoveSandDryMass = await _dimensionManager.RemoveAsync(moistureSandTest.SandDryMassId);
                var resultRemoveSandMoisture = await _dimensionManager.RemoveAsync(moistureSandTest.SandMoistureId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(MoistureSandTest moistureSandTestUpdate)
        {
            try
            {
                var dbMoistureSandTest = await _appDb.MoistureSandTests
                    .FirstOrDefaultAsync(moistureSandTest => moistureSandTest.Id == moistureSandTestUpdate.Id);

                if (dbMoistureSandTest == null)
                {
                    return false;
                }

                if (dbMoistureSandTest.TestNumber != moistureSandTestUpdate.TestNumber)
                {
                    dbMoistureSandTest.TestNumber = moistureSandTestUpdate.TestNumber;
                }

                if (dbMoistureSandTest.MaterialName != moistureSandTestUpdate.MaterialName)
                {
                    dbMoistureSandTest.MaterialName = moistureSandTestUpdate.MaterialName;
                }

                if (dbMoistureSandTest.CustomerId != moistureSandTestUpdate.CustomerId)
                {
                    dbMoistureSandTest.CustomerId = moistureSandTestUpdate.CustomerId;
                }

                if (dbMoistureSandTest.DateTest != moistureSandTestUpdate.DateTest)
                {
                    dbMoistureSandTest.DateTest = moistureSandTestUpdate.DateTest;
                }

                if (dbMoistureSandTest.DocumentTest != moistureSandTestUpdate.DocumentTest)
                {
                    dbMoistureSandTest.DocumentTest = moistureSandTestUpdate.DocumentTest;
                }

                if (dbMoistureSandTest.SandWetMass.DimensionValue != moistureSandTestUpdate.SandWetMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureSandTestUpdate.SandWetMass);
                }

                if (dbMoistureSandTest.SandDryMass.DimensionValue != moistureSandTestUpdate.SandDryMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureSandTestUpdate.SandDryMass);
                }

                if (dbMoistureSandTest.SandMoisture.DimensionValue != moistureSandTestUpdate.SandMoisture.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureSandTestUpdate.SandMoisture);
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
