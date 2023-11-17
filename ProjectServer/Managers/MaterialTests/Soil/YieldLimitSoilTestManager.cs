using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Soil
{
    /// <inheritdoc cref="IYieldLimitSoilTestManager"/>
    public class YieldLimitSoilTestManager : IYieldLimitSoilTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<YieldLimitSoilTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению границы текучести грунта.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public YieldLimitSoilTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<YieldLimitSoilTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<YieldLimitSoilTest> GetAsync(int yieldLimitSoilTestId)
        {
            try
            {
                var model = await _appDb.YieldLimitSoilTests.FirstOrDefaultAsync(yieldLimitSoilTest => yieldLimitSoilTest.Id == yieldLimitSoilTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.SoilWetMassWithBox = await _dimensionManager.GetAsync(model.SoilWetMassWithBoxId);
                model.SoilDryMassWithBox = await _dimensionManager.GetAsync(model.SoilDryMassWithBoxId);
                model.BoxMass = await _dimensionManager.GetAsync(model.BoxMassId);
                model.YieldLimit = await _dimensionManager.GetAsync(model.YieldLimitId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<YieldLimitSoilTest> AddAsync(YieldLimitSoilTest yieldLimitSoilTest)
        {
            try
            {
                yieldLimitSoilTest.BoxMass = await _dimensionManager.AddAsync(yieldLimitSoilTest.BoxMass);
                yieldLimitSoilTest.SoilWetMassWithBox = await _dimensionManager.AddAsync(yieldLimitSoilTest.SoilWetMassWithBox);
                yieldLimitSoilTest.SoilDryMassWithBox = await _dimensionManager.AddAsync(yieldLimitSoilTest.SoilDryMassWithBox);
                yieldLimitSoilTest.YieldLimit = await _dimensionManager.AddAsync(yieldLimitSoilTest.YieldLimit);

                _appDb.Entry(yieldLimitSoilTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return yieldLimitSoilTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int yieldLimitSoilTestId)
        {
            try
            {
                var yieldLimitSoilTest = await _appDb.YieldLimitSoilTests.FirstOrDefaultAsync(x => x.Id == yieldLimitSoilTestId);

                if (yieldLimitSoilTest == null)
                {
                    return false;
                }

                _appDb.YieldLimitSoilTests.Remove(yieldLimitSoilTest);
                _appDb.SaveChanges();

                var resultRemoveSoilWetMassWithBox = await _dimensionManager.RemoveAsync(yieldLimitSoilTest.SoilWetMassWithBoxId);
                var resultRemoveSoilDryMassWithBox = await _dimensionManager.RemoveAsync(yieldLimitSoilTest.SoilDryMassWithBoxId);
                var resultRemoveBoxMass = await _dimensionManager.RemoveAsync(yieldLimitSoilTest.BoxMassId);
                var resultRemoveMoistureSoil = await _dimensionManager.RemoveAsync(yieldLimitSoilTest.YieldLimitId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(YieldLimitSoilTest yieldLimitSoilTestUpdate)
        {
            try
            {
                var dbYieldLimitSoilTest = await _appDb.YieldLimitSoilTests
                    .FirstOrDefaultAsync(yieldLimitSoilTest => yieldLimitSoilTest.Id == yieldLimitSoilTestUpdate.Id);

                if (dbYieldLimitSoilTest == null)
                {
                    return false;
                }

                if (dbYieldLimitSoilTest.TestNumber != yieldLimitSoilTestUpdate.TestNumber)
                {
                    dbYieldLimitSoilTest.TestNumber = yieldLimitSoilTestUpdate.TestNumber;
                }

                if (dbYieldLimitSoilTest.MaterialName != yieldLimitSoilTestUpdate.MaterialName)
                {
                    dbYieldLimitSoilTest.MaterialName = yieldLimitSoilTestUpdate.MaterialName;
                }

                if (dbYieldLimitSoilTest.CustomerId != yieldLimitSoilTestUpdate.CustomerId)
                {
                    dbYieldLimitSoilTest.CustomerId = yieldLimitSoilTestUpdate.CustomerId;
                }

                if (dbYieldLimitSoilTest.DateTest != yieldLimitSoilTestUpdate.DateTest)
                {
                    dbYieldLimitSoilTest.DateTest = yieldLimitSoilTestUpdate.DateTest;
                }

                if (dbYieldLimitSoilTest.DocumentTest != yieldLimitSoilTestUpdate.DocumentTest)
                {
                    dbYieldLimitSoilTest.DocumentTest = yieldLimitSoilTestUpdate.DocumentTest;
                }

                if (dbYieldLimitSoilTest.SoilDryMassWithBox.DimensionValue != yieldLimitSoilTestUpdate.SoilDryMassWithBox.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(yieldLimitSoilTestUpdate.SoilDryMassWithBox);
                }

                if (dbYieldLimitSoilTest.SoilWetMassWithBox.DimensionValue != yieldLimitSoilTestUpdate.SoilWetMassWithBox.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(yieldLimitSoilTestUpdate.SoilWetMassWithBox);
                }

                if (dbYieldLimitSoilTest.BoxMass.DimensionValue != yieldLimitSoilTestUpdate.BoxMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(yieldLimitSoilTestUpdate.BoxMass);
                }

                if (dbYieldLimitSoilTest.YieldLimit.DimensionValue != yieldLimitSoilTestUpdate.YieldLimit.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(yieldLimitSoilTestUpdate.YieldLimit);
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
