using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Sand;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;

namespace ProjectServer.Managers.MaterialTests.Sand
{
    /// <inheritdoc cref="IDustSandTestManager"/>
    public class DustSandTestManager : IDustSandTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public DustSandTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
        }

        public async Task<DustSandTest> GetAsync(int dustSandTestId)
        {
            var model = await _appDb.DustSandTests.FirstOrDefaultAsync(dustSandTest => dustSandTest.Id == dustSandTestId);

            model.Customer = await _customerManager.GetAsync(model.CustomerId);
            model.SandMass = await _dimensionManager.GetAsync(model.SandMassId);
            model.SandWithoutDustMass = await _dimensionManager.GetAsync(model.SandWithoutDustMassId);
            model.SandDust = await _dimensionManager.GetAsync(model.SandDustId);

            return model;
        }

        public async Task<DustSandTest> AddAsync(DustSandTest dustSandTest)
        {
            dustSandTest.SandMass = await _dimensionManager.AddAsync(dustSandTest.SandMass);
            dustSandTest.SandWithoutDustMass = await _dimensionManager.AddAsync(dustSandTest.SandWithoutDustMass);
            dustSandTest.SandDust = await _dimensionManager.AddAsync(dustSandTest.SandDust);

            _appDb.Entry(dustSandTest).State = EntityState.Added;
            await _appDb.SaveChangesAsync();

            return dustSandTest;
        }

        public async Task<bool> RemoveAsync(int dustSandTestId)
        {

            var dustSandTest = await _appDb.DustSandTests.FirstOrDefaultAsync(dustSandTest => dustSandTest.Id == dustSandTestId);

            if (dustSandTest == null)
            {
                return false;
            }

            _appDb.DustSandTests.Remove(dustSandTest);
            _appDb.SaveChanges();

            var resultRemoveSandMass = await _dimensionManager.RemoveAsync(dustSandTest.SandMassId);
            var resultRemoveSandWithoutDustMass = await _dimensionManager.RemoveAsync(dustSandTest.SandWithoutDustMassId);
            var resultRemoveSandDust = await _dimensionManager.RemoveAsync(dustSandTest.SandDustId);

            return true;
        }

        public async Task<bool> UpdateAsync(DustSandTest dustSandTestUpdate)
        {
            var dbDustSandTest = await _appDb.DustSandTests
                .FirstOrDefaultAsync(dustSandTest => dustSandTest.Id == dustSandTestUpdate.Id);

            if (dbDustSandTest == null)
            {
                return false;
            }

            if (dbDustSandTest.TestNumber != dustSandTestUpdate.TestNumber)
            {
                dbDustSandTest.TestNumber = dustSandTestUpdate.TestNumber;
            }

            if (dbDustSandTest.MaterialName != dustSandTestUpdate.MaterialName)
            {
                dbDustSandTest.MaterialName = dustSandTestUpdate.MaterialName;
            }

            if (dbDustSandTest.CustomerId != dustSandTestUpdate.CustomerId)
            {
                dbDustSandTest.CustomerId = dustSandTestUpdate.CustomerId;
            }

            if (dbDustSandTest.DateTest != dustSandTestUpdate.DateTest)
            {
                dbDustSandTest.DateTest = dustSandTestUpdate.DateTest;
            }

            if (dbDustSandTest.DocumentTest != dustSandTestUpdate.DocumentTest)
            {
                dbDustSandTest.DocumentTest = dustSandTestUpdate.DocumentTest;
            }

            if (dbDustSandTest.SandMass.DimensionValue != dustSandTestUpdate.SandMass.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(dustSandTestUpdate.SandMass);
            }

            if (dbDustSandTest.SandWithoutDustMass.DimensionValue != dustSandTestUpdate.SandWithoutDustMass.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(dustSandTestUpdate.SandWithoutDustMass);
            }

            if (dbDustSandTest.SandDust.DimensionValue != dustSandTestUpdate.SandDust.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(dustSandTestUpdate.SandDust);
            }

            _appDb.SaveChanges();

            return true;
        }
    }
}
