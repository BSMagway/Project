using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using System.Runtime.InteropServices;

namespace ProjectServer.Managers
{
    /// <inheritdoc cref="ICustomerManager"/>
    public class MoistureSoilTestManager : IMoistureSoilTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению влажности грунта.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public MoistureSoilTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
        }

        public async Task<MoistureSoilTest> GetAsync(int moistureSoilTestId)
        {
            var model = await _appDb.MoistureSoilTests.FirstOrDefaultAsync(moistureSoilTest => moistureSoilTest.Id == moistureSoilTestId);

            model.CustomerTest = await _customerManager.GetAsync(model.CustomerTestId);
            model.SoilWetMassWithBox = await _dimensionManager.GetAsync(model.SoilWetMassWithBoxId);
            model.SoilDryMassWithBox = await _dimensionManager.GetAsync(model.SoilDryMassWithBoxId);
            model.BoxMass = await _dimensionManager.GetAsync(model.BoxMassId);
            model.MoistureSoil = await _dimensionManager.GetAsync(model.MoistureSoilId);

            return model;
        }

        public async Task<MoistureSoilTest> AddAsync(MoistureSoilTest moistureSoilTest)
        {

            var entity = await _appDb.MoistureSoilTests.AddAsync(moistureSoilTest);
            _appDb.SaveChanges();

            return entity.Entity;
        }

        public async Task<bool> RemoveAsync(int moistureSoilTestId)
        {

            var moistureSoilTest = await _appDb.MoistureSoilTests.FirstOrDefaultAsync(x => x.Id == moistureSoilTestId);

            if (moistureSoilTest == null)
            {
                return false;
            }

            _appDb.MoistureSoilTests.Remove(moistureSoilTest);
            _appDb.SaveChanges();

            var resultRemoveSoilWetMassWithBox = await _dimensionManager.RemoveAsync(moistureSoilTest.SoilWetMassWithBoxId);
            var resultRemoveSoilDryMassWithBox = await _dimensionManager.RemoveAsync(moistureSoilTest.SoilDryMassWithBoxId);
            var resultRemoveBoxMass = await _dimensionManager.RemoveAsync(moistureSoilTest.BoxMassId);
            var resultRemoveMoistureSoil = await _dimensionManager.RemoveAsync(moistureSoilTest.MoistureSoilId);

            return true;
        }

        public async Task<bool> UpdateAsync(MoistureSoilTest moistureSoilTestUpdate)
        {
            var dbMoistureSoilTest = await _appDb.MoistureSoilTests
                .FirstOrDefaultAsync(moistureSoilTest => moistureSoilTest.MoistureSoilTestId == moistureSoilTestUpdate.MoistureSoilTestId);

            if (dbMoistureSoilTest == null)
            {
                return false;
            }

            if (dbMoistureSoilTest.MaterialName != moistureSoilTestUpdate.MaterialName)
            {
                dbMoistureSoilTest.MaterialName = moistureSoilTestUpdate.MaterialName;
            }

            if (dbMoistureSoilTest.CustomerTestId != moistureSoilTestUpdate.CustomerTestId)
            {
                dbMoistureSoilTest.CustomerTestId = moistureSoilTestUpdate.CustomerTestId;
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
                await _dimensionManager.UpdateAsync(moistureSoilTestUpdate.SoilWetMassWithBox);
            }

            if (dbMoistureSoilTest.MoistureSoil.DimensionValue != moistureSoilTestUpdate.MoistureSoil.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(moistureSoilTestUpdate.SoilWetMassWithBox);
            }

            _appDb.SaveChanges();

            return true;
        }
    }
}
