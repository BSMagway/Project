using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Gravel
{
    /// <inheritdoc cref="IDustGravelTestManager"/>
    public class DustGravelTestManager : IDustGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<DustGravelTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public DustGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<DustGravelTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<DustGravelTest> GetAsync(int dustGravelTestId)
        {
            try
            {
                var model = await _appDb.DustGravelTests.FirstOrDefaultAsync(dustGravelTest => dustGravelTest.Id == dustGravelTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.GravelMass = await _dimensionManager.GetAsync(model.GravelMassId);
                model.GravelWithoutDustMass = await _dimensionManager.GetAsync(model.GravelWithoutDustMassId);
                model.GravelDust = await _dimensionManager.GetAsync(model.GravelDustId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<DustGravelTest> AddAsync(DustGravelTest dustGravelTest)
        {
            try
            {
                dustGravelTest.GravelMass = await _dimensionManager.AddAsync(dustGravelTest.GravelMass);
                dustGravelTest.GravelWithoutDustMass = await _dimensionManager.AddAsync(dustGravelTest.GravelWithoutDustMass);
                dustGravelTest.GravelDust = await _dimensionManager.AddAsync(dustGravelTest.GravelDust);

                _appDb.Entry(dustGravelTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return dustGravelTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int dustGravelTestId)
        {
            try
            {
                var dustGravelTest = await _appDb.DustGravelTests.FirstOrDefaultAsync(dustGravelTest => dustGravelTest.Id == dustGravelTestId);

                if (dustGravelTest == null)
                {
                    return false;
                }

                _appDb.DustGravelTests.Remove(dustGravelTest);
                _appDb.SaveChanges();

                var resultRemoveGravelMass = await _dimensionManager.RemoveAsync(dustGravelTest.GravelMassId);
                var resultRemoveGravelWithoutDustMass = await _dimensionManager.RemoveAsync(dustGravelTest.GravelWithoutDustMassId);
                var resultRemoveGravelDust = await _dimensionManager.RemoveAsync(dustGravelTest.GravelDustId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(DustGravelTest dustGravelTestUpdate)
        {
            try
            {
                var dbDustGravelTest = await _appDb.DustGravelTests
                    .FirstOrDefaultAsync(dustGravelTest => dustGravelTest.Id == dustGravelTestUpdate.Id);

                if (dbDustGravelTest == null)
                {
                    return false;
                }

                if (dbDustGravelTest.TestNumber != dustGravelTestUpdate.TestNumber)
                {
                    dbDustGravelTest.TestNumber = dustGravelTestUpdate.TestNumber;
                }

                if (dbDustGravelTest.MaterialName != dustGravelTestUpdate.MaterialName)
                {
                    dbDustGravelTest.MaterialName = dustGravelTestUpdate.MaterialName;
                }

                if (dbDustGravelTest.CustomerId != dustGravelTestUpdate.CustomerId)
                {
                    dbDustGravelTest.CustomerId = dustGravelTestUpdate.CustomerId;
                }

                if (dbDustGravelTest.DateTest != dustGravelTestUpdate.DateTest)
                {
                    dbDustGravelTest.DateTest = dustGravelTestUpdate.DateTest;
                }

                if (dbDustGravelTest.DocumentTest != dustGravelTestUpdate.DocumentTest)
                {
                    dbDustGravelTest.DocumentTest = dustGravelTestUpdate.DocumentTest;
                }

                if (dbDustGravelTest.GravelMass.DimensionValue != dustGravelTestUpdate.GravelMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(dustGravelTestUpdate.GravelMass);
                }

                if (dbDustGravelTest.GravelWithoutDustMass.DimensionValue != dustGravelTestUpdate.GravelWithoutDustMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(dustGravelTestUpdate.GravelWithoutDustMass);
                }

                if (dbDustGravelTest.GravelDust.DimensionValue != dustGravelTestUpdate.GravelDust.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(dustGravelTestUpdate.GravelDust);
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
