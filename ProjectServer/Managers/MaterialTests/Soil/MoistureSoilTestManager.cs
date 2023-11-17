using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;
using ProjectServer.Interfaces.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Soil
{
    /// <inheritdoc cref="IMoistureSoilTestManager"/>
    public class MoistureSoilTestManager : IMoistureSoilTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<MoistureSoilTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению влажности грунта.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public MoistureSoilTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<MoistureSoilTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<MoistureSoilTest> GetAsync(int moistureSoilTestId)
        {
            try
            {
                var model = await _appDb.MoistureSoilTests.FirstOrDefaultAsync(moistureSoilTest => moistureSoilTest.Id == moistureSoilTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.SoilWetMassWithBox = await _dimensionManager.GetAsync(model.SoilWetMassWithBoxId);
                model.SoilDryMassWithBox = await _dimensionManager.GetAsync(model.SoilDryMassWithBoxId);
                model.BoxMass = await _dimensionManager.GetAsync(model.BoxMassId);
                model.Moisture = await _dimensionManager.GetAsync(model.MoistureId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<MoistureSoilTest> AddAsync(MoistureSoilTest moistureSoilTest)
        {
            try
            {
                moistureSoilTest.BoxMass = await _dimensionManager.AddAsync(moistureSoilTest.BoxMass);
                moistureSoilTest.SoilWetMassWithBox = await _dimensionManager.AddAsync(moistureSoilTest.SoilWetMassWithBox);
                moistureSoilTest.SoilDryMassWithBox = await _dimensionManager.AddAsync(moistureSoilTest.SoilDryMassWithBox);
                moistureSoilTest.Moisture = await _dimensionManager.AddAsync(moistureSoilTest.Moisture);

                _appDb.Entry(moistureSoilTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return moistureSoilTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int moistureSoilTestId)
        {
            try
            {
                var moistureSoilTest = await _appDb.MoistureSoilTests.FirstOrDefaultAsync(x => x.Id == moistureSoilTestId);

                if (moistureSoilTest == null)
                {
                    return false;
                }

                _appDb.MoistureSoilTests.Remove(moistureSoilTest);
                _appDb.SaveChanges();

                var resultRemoveSoilWetMassWithBox = await _dimensionManager.RemoveAsync(moistureSoilTest.SoilWetMassWithBox.Id);
                var resultRemoveSoilDryMassWithBox = await _dimensionManager.RemoveAsync(moistureSoilTest.SoilDryMassWithBox.Id);
                var resultRemoveBoxMass = await _dimensionManager.RemoveAsync(moistureSoilTest.BoxMass.Id);
                var resultRemoveMoistureSoil = await _dimensionManager.RemoveAsync(moistureSoilTest.Moisture.Id);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(MoistureSoilTest moistureSoilTestUpdate)
        {
            try
            {
                var dbMoistureSoilTest = await _appDb.MoistureSoilTests
                    .FirstOrDefaultAsync(moistureSoilTest => moistureSoilTest.Id == moistureSoilTestUpdate.Id);

                if (dbMoistureSoilTest == null)
                {
                    return false;
                }

                if (dbMoistureSoilTest.TestNumber != moistureSoilTestUpdate.TestNumber)
                {
                    dbMoistureSoilTest.TestNumber = moistureSoilTestUpdate.TestNumber;
                }

                if (dbMoistureSoilTest.MaterialName != moistureSoilTestUpdate.MaterialName)
                {
                    dbMoistureSoilTest.MaterialName = moistureSoilTestUpdate.MaterialName;
                }

                if (dbMoistureSoilTest.CustomerId != moistureSoilTestUpdate.CustomerId)
                {
                    dbMoistureSoilTest.CustomerId = moistureSoilTestUpdate.CustomerId;
                }

                if (dbMoistureSoilTest.DateTest != moistureSoilTestUpdate.DateTest)
                {
                    dbMoistureSoilTest.DateTest = moistureSoilTestUpdate.DateTest;
                }

                if (dbMoistureSoilTest.DocumentTest != moistureSoilTestUpdate.DocumentTest)
                {
                    dbMoistureSoilTest.DocumentTest = moistureSoilTestUpdate.DocumentTest;
                }

                if (dbMoistureSoilTest.SoilDryMassWithBox.DimensionValue != moistureSoilTestUpdate.SoilDryMassWithBox.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureSoilTestUpdate.SoilDryMassWithBox);
                }

                if (dbMoistureSoilTest.SoilWetMassWithBox.DimensionValue != moistureSoilTestUpdate.SoilWetMassWithBox.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureSoilTestUpdate.SoilWetMassWithBox);
                }

                if (dbMoistureSoilTest.BoxMass.DimensionValue != moistureSoilTestUpdate.BoxMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureSoilTestUpdate.BoxMass);
                }

                if (dbMoistureSoilTest.Moisture.DimensionValue != moistureSoilTestUpdate.Moisture.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(moistureSoilTestUpdate.Moisture);
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
