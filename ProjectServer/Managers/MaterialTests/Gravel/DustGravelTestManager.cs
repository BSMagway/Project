﻿using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Gravel;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;

namespace ProjectServer.Managers.MaterialTests.Gravel
{
    /// <inheritdoc cref="IDustGravelTestManager"/>
    public class DustGravelTestManager : IDustGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public DustGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
        }

        public async Task<DustGravelTest> GetAsync(int dustGravelTestId)
        {
            var model = await _appDb.DustGravelTests.FirstOrDefaultAsync(dustGravelTest => dustGravelTest.Id == dustGravelTestId);

            model.Customer = await _customerManager.GetAsync(model.CustomerId);
            model.GravelMass = await _dimensionManager.GetAsync(model.GravelMassId);
            model.GravelWithoutDustMass = await _dimensionManager.GetAsync(model.GravelWithoutDustMassId);
            model.GravelDust = await _dimensionManager.GetAsync(model.GravelDustId);

            return model;
        }

        public async Task<DustGravelTest> AddAsync(DustGravelTest dustGravelTest)
        {
            dustGravelTest.GravelMass = await _dimensionManager.AddAsync(dustGravelTest.GravelMass);
            dustGravelTest.GravelWithoutDustMass = await _dimensionManager.AddAsync(dustGravelTest.GravelWithoutDustMass);
            dustGravelTest.GravelDust = await _dimensionManager.AddAsync(dustGravelTest.GravelDust);

            _appDb.Entry(dustGravelTest).State = EntityState.Added;
            await _appDb.SaveChangesAsync();

            return dustGravelTest;
        }

        public async Task<bool> RemoveAsync(int dustGravelTestId)
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

        public async Task<bool> UpdateAsync(DustGravelTest dustGravelTestUpdate)
        {
            var dbDustGravelTest = await _appDb.DustGravelTests
                .FirstOrDefaultAsync(flakyGrainsGravelTest => flakyGrainsGravelTest.Id == dustGravelTestUpdate.Id);

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
    }
}
