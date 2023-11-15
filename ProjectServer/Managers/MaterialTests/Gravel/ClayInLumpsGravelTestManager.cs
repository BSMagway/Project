﻿using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;

namespace ProjectServer.Managers.MaterialTests.Gravel
{
    /// <inheritdoc cref="IClayInLumpsGravelTestManager"/>
    public class ClayInLumpsGravelTestManager : IClayInLumpsGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению содержания глины в комках в щебне.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public ClayInLumpsGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
        }

        public async Task<ClayInLumpsGravelTest> GetAsync(int clayInLumpsGravelTestId)
        {
            var model = await _appDb.ClayInLumpsGravelTests.FirstOrDefaultAsync(clayInLumpsGravelTest => clayInLumpsGravelTest.Id == clayInLumpsGravelTestId);

            model.Customer = await _customerManager.GetAsync(model.CustomerId);
            model.GravelMass = await _dimensionManager.GetAsync(model.GravelMassId);
            model.GravelClayInLumpsMass = await _dimensionManager.GetAsync(model.GravelClayInLumpsMassId);
            model.GravelClayInLumps = await _dimensionManager.GetAsync(model.GravelClayInLumpsId);

            return model;
        }

        public async Task<ClayInLumpsGravelTest> AddAsync(ClayInLumpsGravelTest clayInLumpsGravelTest)
        {
            clayInLumpsGravelTest.GravelMass = await _dimensionManager.AddAsync(clayInLumpsGravelTest.GravelMass);
            clayInLumpsGravelTest.GravelClayInLumpsMass = await _dimensionManager.AddAsync(clayInLumpsGravelTest.GravelClayInLumpsMass);
            clayInLumpsGravelTest.GravelClayInLumps = await _dimensionManager.AddAsync(clayInLumpsGravelTest.GravelClayInLumps);

            _appDb.Entry(clayInLumpsGravelTest).State = EntityState.Added;
            await _appDb.SaveChangesAsync();

            return clayInLumpsGravelTest;
        }

        public async Task<bool> RemoveAsync(int clayInLumpsGravelTestId)
        {

            var clayInLumpsGravelTest = await _appDb.ClayInLumpsGravelTests.FirstOrDefaultAsync(clayInLumpsGravelTest => clayInLumpsGravelTest.Id == clayInLumpsGravelTestId);

            if (clayInLumpsGravelTest == null)
            {
                return false;
            }

            _appDb.ClayInLumpsGravelTests.Remove(clayInLumpsGravelTest);
            _appDb.SaveChanges();

            var resultRemoveGravelMass = await _dimensionManager.RemoveAsync(clayInLumpsGravelTest.GravelMassId);
            var resultRemoveGravelClayInLumpsMass = await _dimensionManager.RemoveAsync(clayInLumpsGravelTest.GravelClayInLumpsMassId);
            var resultRemoveGravelClayInLumps = await _dimensionManager.RemoveAsync(clayInLumpsGravelTest.GravelClayInLumpsId);

            return true;
        }

        public async Task<bool> UpdateAsync(ClayInLumpsGravelTest clayInLumpsGravelTestUpdate)
        {
            var dbClayInLumpsGravelTest = await _appDb.ClayInLumpsGravelTests
                .FirstOrDefaultAsync(clayInLumpsGravelTest => clayInLumpsGravelTest.Id == clayInLumpsGravelTestUpdate.Id);

            if (dbClayInLumpsGravelTest == null)
            {
                return false;
            }

            if (dbClayInLumpsGravelTest.TestNumber != clayInLumpsGravelTestUpdate.TestNumber)
            {
                dbClayInLumpsGravelTest.TestNumber = clayInLumpsGravelTestUpdate.TestNumber;
            }

            if (dbClayInLumpsGravelTest.MaterialName != clayInLumpsGravelTestUpdate.MaterialName)
            {
                dbClayInLumpsGravelTest.MaterialName = clayInLumpsGravelTestUpdate.MaterialName;
            }

            if (dbClayInLumpsGravelTest.CustomerId != clayInLumpsGravelTestUpdate.CustomerId)
            {
                dbClayInLumpsGravelTest.CustomerId = clayInLumpsGravelTestUpdate.CustomerId;
            }

            if (dbClayInLumpsGravelTest.DateTest != clayInLumpsGravelTestUpdate.DateTest)
            {
                dbClayInLumpsGravelTest.DateTest = clayInLumpsGravelTestUpdate.DateTest;
            }

            if (dbClayInLumpsGravelTest.DocumentTest != clayInLumpsGravelTestUpdate.DocumentTest)
            {
                dbClayInLumpsGravelTest.DocumentTest = clayInLumpsGravelTestUpdate.DocumentTest;
            }

            if (dbClayInLumpsGravelTest.GravelMass.DimensionValue != clayInLumpsGravelTestUpdate.GravelMass.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(clayInLumpsGravelTestUpdate.GravelMass);
            }

            if (dbClayInLumpsGravelTest.GravelClayInLumpsMass.DimensionValue != clayInLumpsGravelTestUpdate.GravelClayInLumpsMass.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(clayInLumpsGravelTestUpdate.GravelClayInLumpsMass);
            }

            if (dbClayInLumpsGravelTest.GravelClayInLumps.DimensionValue != clayInLumpsGravelTestUpdate.GravelClayInLumps.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(clayInLumpsGravelTestUpdate.GravelClayInLumps);
            }

            _appDb.SaveChanges();

            return true;
        }
    }
}
