using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;

namespace ProjectServer.Managers.MaterialTests.Gravel
{
    /// <inheritdoc cref="IWeakGrainsGravelTestManager"/>
    public class WeakGrainsGravelTestManager : IWeakGrainsGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<WeakGrainsGravelTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению содержания зерен слабых пород.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public WeakGrainsGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<WeakGrainsGravelTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<WeakGrainsGravelTest> GetAsync(int weakGrainsGravelTestId)
        {
            try
            {
                var model = await _appDb.WeakGrainsGravelTests.FirstOrDefaultAsync(weakGrainsGravelTest => weakGrainsGravelTest.Id == weakGrainsGravelTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.GravelMass = await _dimensionManager.GetAsync(model.GravelMassId);
                model.GravelWeakGrainsMass = await _dimensionManager.GetAsync(model.GravelWeakGrainsMassId);
                model.GravelWeakGrains = await _dimensionManager.GetAsync(model.GravelWeakGrainsId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<WeakGrainsGravelTest> AddAsync(WeakGrainsGravelTest weakGrainsGravelTest)
        {
            try
            {
                weakGrainsGravelTest.GravelMass = await _dimensionManager.AddAsync(weakGrainsGravelTest.GravelMass);
                weakGrainsGravelTest.GravelWeakGrainsMass = await _dimensionManager.AddAsync(weakGrainsGravelTest.GravelWeakGrainsMass);
                weakGrainsGravelTest.GravelWeakGrains = await _dimensionManager.AddAsync(weakGrainsGravelTest.GravelWeakGrains);

                _appDb.Entry(weakGrainsGravelTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return weakGrainsGravelTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int weakGrainsGravelTestId)
        {
            try
            {
                var weakGrainsGravelTest = await _appDb.WeakGrainsGravelTests.FirstOrDefaultAsync(weakGrainsGravelTest => weakGrainsGravelTest.Id == weakGrainsGravelTestId);

                if (weakGrainsGravelTest == null)
                {
                    return false;
                }

                _appDb.WeakGrainsGravelTests.Remove(weakGrainsGravelTest);
                _appDb.SaveChanges();

                var resultRemoveGravelMass = await _dimensionManager.RemoveAsync(weakGrainsGravelTest.GravelMassId);
                var resultRemoveGravelWeakGrainsMass = await _dimensionManager.RemoveAsync(weakGrainsGravelTest.GravelWeakGrainsMassId);
                var resultRemoveGravelWeakGrains = await _dimensionManager.RemoveAsync(weakGrainsGravelTest.GravelWeakGrainsId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(WeakGrainsGravelTest weakGrainsGravelTestUpdate)
        {
            try
            {
                var dbWeakGrainsGravelTest = await _appDb.WeakGrainsGravelTests
                    .FirstOrDefaultAsync(weakGrainsGravelTest => weakGrainsGravelTest.Id == weakGrainsGravelTestUpdate.Id);

                if (dbWeakGrainsGravelTest == null)
                {
                    return false;
                }

                if (dbWeakGrainsGravelTest.TestNumber != weakGrainsGravelTestUpdate.TestNumber)
                {
                    dbWeakGrainsGravelTest.TestNumber = weakGrainsGravelTestUpdate.TestNumber;
                }

                if (dbWeakGrainsGravelTest.MaterialName != weakGrainsGravelTestUpdate.MaterialName)
                {
                    dbWeakGrainsGravelTest.MaterialName = weakGrainsGravelTestUpdate.MaterialName;
                }

                if (dbWeakGrainsGravelTest.CustomerId != weakGrainsGravelTestUpdate.CustomerId)
                {
                    dbWeakGrainsGravelTest.CustomerId = weakGrainsGravelTestUpdate.CustomerId;
                }

                if (dbWeakGrainsGravelTest.DateTest != weakGrainsGravelTestUpdate.DateTest)
                {
                    dbWeakGrainsGravelTest.DateTest = weakGrainsGravelTestUpdate.DateTest;
                }

                if (dbWeakGrainsGravelTest.DocumentTest != weakGrainsGravelTestUpdate.DocumentTest)
                {
                    dbWeakGrainsGravelTest.DocumentTest = weakGrainsGravelTestUpdate.DocumentTest;
                }

                if (dbWeakGrainsGravelTest.GravelMass.DimensionValue != weakGrainsGravelTestUpdate.GravelMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(weakGrainsGravelTestUpdate.GravelMass);
                }

                if (dbWeakGrainsGravelTest.GravelWeakGrainsMass.DimensionValue != weakGrainsGravelTestUpdate.GravelWeakGrainsMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(weakGrainsGravelTestUpdate.GravelWeakGrainsMass);
                }

                if (dbWeakGrainsGravelTest.GravelWeakGrains.DimensionValue != weakGrainsGravelTestUpdate.GravelWeakGrains.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(weakGrainsGravelTestUpdate.GravelWeakGrains);
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
