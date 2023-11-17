using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Gravel
{
    /// <inheritdoc cref="ICrushabilityGravelTestManager"/>
    public class CrushabilityGravelTestManager : ICrushabilityGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<CrushabilityGravelTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению дробимости щебня.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public CrushabilityGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<CrushabilityGravelTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<CrushabilityGravelTest> GetAsync(int crushabilityGravelTestId)
        {
            try
            {
                var model = await _appDb.CrushabilityGravelTests.FirstOrDefaultAsync(crushabilityGravelTest => crushabilityGravelTest.Id == crushabilityGravelTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.GravelMass = await _dimensionManager.GetAsync(model.GravelMassId);
                model.GravelCrushabilityMass = await _dimensionManager.GetAsync(model.GravelCrushabilityMassId);
                model.GravelCrushability = await _dimensionManager.GetAsync(model.GravelCrushabilityId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<CrushabilityGravelTest> AddAsync(CrushabilityGravelTest crushabilityGravelTest)
        {
            try
            {
                crushabilityGravelTest.GravelMass = await _dimensionManager.AddAsync(crushabilityGravelTest.GravelMass);
                crushabilityGravelTest.GravelCrushabilityMass = await _dimensionManager.AddAsync(crushabilityGravelTest.GravelCrushabilityMass);
                crushabilityGravelTest.GravelCrushability = await _dimensionManager.AddAsync(crushabilityGravelTest.GravelCrushability);

                _appDb.Entry(crushabilityGravelTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return crushabilityGravelTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int crushabilityGravelTestId)
        {
            try
            {
                var crushabilityGravelTest = await _appDb.CrushabilityGravelTests.FirstOrDefaultAsync(crushabilityGravelTest => crushabilityGravelTest.Id == crushabilityGravelTestId);

                if (crushabilityGravelTest == null)
                {
                    return false;
                }

                _appDb.CrushabilityGravelTests.Remove(crushabilityGravelTest);
                _appDb.SaveChanges();

                var resultRemoveGravelMass = await _dimensionManager.RemoveAsync(crushabilityGravelTest.GravelMassId);
                var resultRemoveGravelGravelCrushabilityMass = await _dimensionManager.RemoveAsync(crushabilityGravelTest.GravelCrushabilityMassId);
                var resultRemoveGravelCrushability = await _dimensionManager.RemoveAsync(crushabilityGravelTest.GravelCrushabilityId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CrushabilityGravelTest crushabilityGravelTestUpdate)
        {
            try
            {
                var dbCrushabilityGravelTest = await _appDb.CrushabilityGravelTests
                    .FirstOrDefaultAsync(crushabilityGravelTest => crushabilityGravelTest.Id == crushabilityGravelTestUpdate.Id);

                if (dbCrushabilityGravelTest == null)
                {
                    return false;
                }

                if (dbCrushabilityGravelTest.TestNumber != crushabilityGravelTestUpdate.TestNumber)
                {
                    dbCrushabilityGravelTest.TestNumber = crushabilityGravelTestUpdate.TestNumber;
                }

                if (dbCrushabilityGravelTest.MaterialName != crushabilityGravelTestUpdate.MaterialName)
                {
                    dbCrushabilityGravelTest.MaterialName = crushabilityGravelTestUpdate.MaterialName;
                }

                if (dbCrushabilityGravelTest.CustomerId != crushabilityGravelTestUpdate.CustomerId)
                {
                    dbCrushabilityGravelTest.CustomerId = crushabilityGravelTestUpdate.CustomerId;
                }

                if (dbCrushabilityGravelTest.DateTest != crushabilityGravelTestUpdate.DateTest)
                {
                    dbCrushabilityGravelTest.DateTest = crushabilityGravelTestUpdate.DateTest;
                }

                if (dbCrushabilityGravelTest.DocumentTest != crushabilityGravelTestUpdate.DocumentTest)
                {
                    dbCrushabilityGravelTest.DocumentTest = crushabilityGravelTestUpdate.DocumentTest;
                }

                if (dbCrushabilityGravelTest.GravelMass.DimensionValue != crushabilityGravelTestUpdate.GravelMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(crushabilityGravelTestUpdate.GravelMass);
                }

                if (dbCrushabilityGravelTest.GravelCrushabilityMass.DimensionValue != crushabilityGravelTestUpdate.GravelCrushabilityMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(crushabilityGravelTestUpdate.GravelCrushabilityMass);
                }

                if (dbCrushabilityGravelTest.GravelCrushability.DimensionValue != crushabilityGravelTestUpdate.GravelCrushability.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(crushabilityGravelTestUpdate.GravelCrushability);
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
