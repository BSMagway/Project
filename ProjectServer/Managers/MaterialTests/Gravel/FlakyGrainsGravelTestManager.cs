using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Gravel
{
    /// <inheritdoc cref="IFlakyGrainsGravelTestManager"/>
    public class FlakyGrainsGravelTestManager : IFlakyGrainsGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<FlakyGrainsGravelTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public FlakyGrainsGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<FlakyGrainsGravelTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<FlakyGrainsGravelTest> GetAsync(int flakyGrainsGravelTestId)
        {
            try
            {
                var model = await _appDb.FlakyGrainsGravelTests.FirstOrDefaultAsync(flakyGrainsGravelTest => flakyGrainsGravelTest.Id == flakyGrainsGravelTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.GravelMass = await _dimensionManager.GetAsync(model.GravelMassId);
                model.GravelFlakyGrainsMass = await _dimensionManager.GetAsync(model.GravelFlakyGrainsMassId);
                model.GravelFlakyGrains = await _dimensionManager.GetAsync(model.GravelFlakyGrainsId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<FlakyGrainsGravelTest> AddAsync(FlakyGrainsGravelTest flakyGrainsGravelTest)
        {
            try
            {
                flakyGrainsGravelTest.GravelMass = await _dimensionManager.AddAsync(flakyGrainsGravelTest.GravelMass);
                flakyGrainsGravelTest.GravelFlakyGrainsMass = await _dimensionManager.AddAsync(flakyGrainsGravelTest.GravelFlakyGrainsMass);
                flakyGrainsGravelTest.GravelFlakyGrains = await _dimensionManager.AddAsync(flakyGrainsGravelTest.GravelFlakyGrains);

                _appDb.Entry(flakyGrainsGravelTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return flakyGrainsGravelTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int flakyGrainsGravelTestId)
        {
            try
            {
                var flakyGrainsGravelTest = await _appDb.FlakyGrainsGravelTests.FirstOrDefaultAsync(flakyGrainsGravelTest => flakyGrainsGravelTest.Id == flakyGrainsGravelTestId);

                if (flakyGrainsGravelTest == null)
                {
                    return false;
                }

                _appDb.FlakyGrainsGravelTests.Remove(flakyGrainsGravelTest);
                _appDb.SaveChanges();

                var resultRemoveGravelMass = await _dimensionManager.RemoveAsync(flakyGrainsGravelTest.GravelMassId);
                var resultRemoveGravelFlakyGrainsMass = await _dimensionManager.RemoveAsync(flakyGrainsGravelTest.GravelFlakyGrainsMassId);
                var resultRemoveGravelFlakyGrains = await _dimensionManager.RemoveAsync(flakyGrainsGravelTest.GravelFlakyGrainsId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(FlakyGrainsGravelTest flakyGrainsGravelTestUpdate)
        {
            try
            {
                var dbFlakyGrainsGravelTest = await _appDb.FlakyGrainsGravelTests
                    .FirstOrDefaultAsync(flakyGrainsGravelTest => flakyGrainsGravelTest.Id == flakyGrainsGravelTestUpdate.Id);

                if (dbFlakyGrainsGravelTest == null)
                {
                    return false;
                }

                if (dbFlakyGrainsGravelTest.TestNumber != flakyGrainsGravelTestUpdate.TestNumber)
                {
                    dbFlakyGrainsGravelTest.TestNumber = flakyGrainsGravelTestUpdate.TestNumber;
                }

                if (dbFlakyGrainsGravelTest.MaterialName != flakyGrainsGravelTestUpdate.MaterialName)
                {
                    dbFlakyGrainsGravelTest.MaterialName = flakyGrainsGravelTestUpdate.MaterialName;
                }

                if (dbFlakyGrainsGravelTest.CustomerId != flakyGrainsGravelTestUpdate.CustomerId)
                {
                    dbFlakyGrainsGravelTest.CustomerId = flakyGrainsGravelTestUpdate.CustomerId;
                }

                if (dbFlakyGrainsGravelTest.DateTest != flakyGrainsGravelTestUpdate.DateTest)
                {
                    dbFlakyGrainsGravelTest.DateTest = flakyGrainsGravelTestUpdate.DateTest;
                }

                if (dbFlakyGrainsGravelTest.DocumentTest != flakyGrainsGravelTestUpdate.DocumentTest)
                {
                    dbFlakyGrainsGravelTest.DocumentTest = flakyGrainsGravelTestUpdate.DocumentTest;
                }

                if (dbFlakyGrainsGravelTest.GravelMass.DimensionValue != flakyGrainsGravelTestUpdate.GravelMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(flakyGrainsGravelTestUpdate.GravelMass);
                }

                if (dbFlakyGrainsGravelTest.GravelFlakyGrainsMass.DimensionValue != flakyGrainsGravelTestUpdate.GravelFlakyGrainsMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(flakyGrainsGravelTestUpdate.GravelFlakyGrainsMass);
                }

                if (dbFlakyGrainsGravelTest.GravelFlakyGrains.DimensionValue != flakyGrainsGravelTestUpdate.GravelFlakyGrains.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(flakyGrainsGravelTestUpdate.GravelFlakyGrains);
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
