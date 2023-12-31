﻿using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Soil;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Soil;

namespace ProjectServer.Managers.MaterialTests.Gravel
{
    /// <inheritdoc cref="ICrushedGrainsGravelTestManager"/>
    public class CrushedGrainsGravelTestManager : ICrushedGrainsGravelTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger<CrushedGrainsGravelTestManager> _logger;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению содержания дробленых зерен в щебне из гравия.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public CrushedGrainsGravelTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager, ILogger<CrushedGrainsGravelTestManager> logger)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<CrushedGrainsGravelTest> GetAsync(int crushedGrainsGravelTestId)
        {
            try
            {
                var model = await _appDb.CrushedGrainsGravelTests.FirstOrDefaultAsync(crushedGrainsGravelTest => crushedGrainsGravelTest.Id == crushedGrainsGravelTestId);

                model.Customer = await _customerManager.GetAsync(model.CustomerId);
                model.GravelMass = await _dimensionManager.GetAsync(model.GravelMassId);
                model.GravelCrushedGrainsMass = await _dimensionManager.GetAsync(model.GravelCrushedGrainsMassId);
                model.GravelCrushedGrains = await _dimensionManager.GetAsync(model.GravelCrushedGrainsId);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<CrushedGrainsGravelTest> AddAsync(CrushedGrainsGravelTest crushedGrainsGravelTest)
        {
            try
            {
                crushedGrainsGravelTest.GravelMass = await _dimensionManager.AddAsync(crushedGrainsGravelTest.GravelMass);
                crushedGrainsGravelTest.GravelCrushedGrainsMass = await _dimensionManager.AddAsync(crushedGrainsGravelTest.GravelCrushedGrainsMass);
                crushedGrainsGravelTest.GravelCrushedGrains = await _dimensionManager.AddAsync(crushedGrainsGravelTest.GravelCrushedGrains);

                _appDb.Entry(crushedGrainsGravelTest).State = EntityState.Added;
                await _appDb.SaveChangesAsync();

                return crushedGrainsGravelTest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int crushedGrainsGravelTestId)
        {
            try
            {
                var crushedGrainsGravelTest = await _appDb.CrushedGrainsGravelTests.FirstOrDefaultAsync(crushedGrainsGravelTest => crushedGrainsGravelTest.Id == crushedGrainsGravelTestId);

                if (crushedGrainsGravelTest == null)
                {
                    return false;
                }

                _appDb.CrushedGrainsGravelTests.Remove(crushedGrainsGravelTest);
                _appDb.SaveChanges();

                var resultRemoveGravelMass = await _dimensionManager.RemoveAsync(crushedGrainsGravelTest.GravelMassId);
                var resultRemoveGravelCrushedGrainsMass = await _dimensionManager.RemoveAsync(crushedGrainsGravelTest.GravelCrushedGrainsMassId);
                var resultRemoveGravelCrushedGrains = await _dimensionManager.RemoveAsync(crushedGrainsGravelTest.GravelCrushedGrainsId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CrushedGrainsGravelTest crushedGrainsGravelTestUpdate)
        {
            try
            {
                var dbCrushedGrainsGravelTest = await _appDb.CrushedGrainsGravelTests
                    .FirstOrDefaultAsync(crushedGrainsGravelTest => crushedGrainsGravelTest.Id == crushedGrainsGravelTestUpdate.Id);

                if (dbCrushedGrainsGravelTest == null)
                {
                    return false;
                }

                if (dbCrushedGrainsGravelTest.TestNumber != crushedGrainsGravelTestUpdate.TestNumber)
                {
                    dbCrushedGrainsGravelTest.TestNumber = crushedGrainsGravelTestUpdate.TestNumber;
                }

                if (dbCrushedGrainsGravelTest.MaterialName != crushedGrainsGravelTestUpdate.MaterialName)
                {
                    dbCrushedGrainsGravelTest.MaterialName = crushedGrainsGravelTestUpdate.MaterialName;
                }

                if (dbCrushedGrainsGravelTest.CustomerId != crushedGrainsGravelTestUpdate.CustomerId)
                {
                    dbCrushedGrainsGravelTest.CustomerId = crushedGrainsGravelTestUpdate.CustomerId;
                }

                if (dbCrushedGrainsGravelTest.DateTest != crushedGrainsGravelTestUpdate.DateTest)
                {
                    dbCrushedGrainsGravelTest.DateTest = crushedGrainsGravelTestUpdate.DateTest;
                }

                if (dbCrushedGrainsGravelTest.DocumentTest != crushedGrainsGravelTestUpdate.DocumentTest)
                {
                    dbCrushedGrainsGravelTest.DocumentTest = crushedGrainsGravelTestUpdate.DocumentTest;
                }

                if (dbCrushedGrainsGravelTest.GravelMass.DimensionValue != crushedGrainsGravelTestUpdate.GravelMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(crushedGrainsGravelTestUpdate.GravelMass);
                }

                if (dbCrushedGrainsGravelTest.GravelCrushedGrainsMass.DimensionValue != crushedGrainsGravelTestUpdate.GravelCrushedGrainsMass.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(crushedGrainsGravelTestUpdate.GravelCrushedGrainsMass);
                }

                if (dbCrushedGrainsGravelTest.GravelCrushedGrains.DimensionValue != crushedGrainsGravelTestUpdate.GravelCrushedGrains.DimensionValue)
                {
                    await _dimensionManager.UpdateAsync(crushedGrainsGravelTestUpdate.GravelCrushedGrains);
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
