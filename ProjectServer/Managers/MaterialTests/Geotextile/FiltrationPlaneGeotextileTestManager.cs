using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models.Material.Geotextile;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Geotextile;

namespace ProjectServer.Managers.MaterialTests.Geotextile
{
    /// <inheritdoc cref="IFiltrationPlaneGeotextileTestManager"/>
    public class FiltrationPlaneGeotextileTestManager : IFiltrationPlaneGeotextileTestManager
    {
        private readonly AppDbContext _appDb;
        private readonly IDimensionManager _dimensionManager;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Конструктор менеджера по работе с базой данных тестов по определению насыпной плотности песка.
        /// </summary>
        /// <param name="appDb">База данных.</param>
        /// <param name="dimensionManager">Менеджер по работе с базой данных измерений.</param>
        /// <param name="customerManager">Менеджер по работе с базой данных заказчиков.</param>
        public FiltrationPlaneGeotextileTestManager(AppDbContext appDb, IDimensionManager dimensionManager, ICustomerManager customerManager)
        {
            _appDb = appDb;
            _dimensionManager = dimensionManager;
            _customerManager = customerManager;
        }

        public async Task<FiltrationPlaneGeotextileTest> GetAsync(int filtrationPlaneGeotextileTestId)
        {
            var model = await _appDb.FiltrationPlaneGeotextileTests.FirstOrDefaultAsync(filtrationPlaneGeotextileTest => filtrationPlaneGeotextileTest.Id == filtrationPlaneGeotextileTestId);

            model.Customer = await _customerManager.GetAsync(model.CustomerId);
            model.WaterVolume = await _dimensionManager.GetAsync(model.WaterVolumeId);
            model.TimeWaterFiltration = await _dimensionManager.GetAsync(model.TimeWaterFiltrationId);
            model.ThicknessPackage = await _dimensionManager.GetAsync(model.ThicknessPackageId);
            model.ActualTemperature = await _dimensionManager.GetAsync(model.ActualTemperatureId);
            model.GeotextileFiltration = await _dimensionManager.GetAsync(model.GeotextileFiltrationId);

            return model;
        }

        public async Task<FiltrationPlaneGeotextileTest> AddAsync(FiltrationPlaneGeotextileTest filtrationPlaneGeotextileTest)
        {
            filtrationPlaneGeotextileTest.WaterVolume = await _dimensionManager.AddAsync(filtrationPlaneGeotextileTest.WaterVolume);
            filtrationPlaneGeotextileTest.TimeWaterFiltration = await _dimensionManager.AddAsync(filtrationPlaneGeotextileTest.TimeWaterFiltration);
            filtrationPlaneGeotextileTest.ThicknessPackage = await _dimensionManager.AddAsync(filtrationPlaneGeotextileTest.ThicknessPackage);
            filtrationPlaneGeotextileTest.ActualTemperature = await _dimensionManager.AddAsync(filtrationPlaneGeotextileTest.ActualTemperature);
            filtrationPlaneGeotextileTest.GeotextileFiltration = await _dimensionManager.AddAsync(filtrationPlaneGeotextileTest.GeotextileFiltration);


            _appDb.Entry(filtrationPlaneGeotextileTest).State = EntityState.Added;
            await _appDb.SaveChangesAsync();

            return filtrationPlaneGeotextileTest;
        }

        public async Task<bool> RemoveAsync(int filtrationPlaneGeotextileTestId)
        {

            var filtrationPlaneGeotextileTest = await _appDb.FiltrationPlaneGeotextileTests.FirstOrDefaultAsync(filtrationPlaneGeotextileTest => filtrationPlaneGeotextileTest.Id == filtrationPlaneGeotextileTestId);

            if (filtrationPlaneGeotextileTest == null)
            {
                return false;
            }

            _appDb.FiltrationPlaneGeotextileTests.Remove(filtrationPlaneGeotextileTest);
            _appDb.SaveChanges();

            var resultRemoveWaterVolume = await _dimensionManager.RemoveAsync(filtrationPlaneGeotextileTest.WaterVolumeId);
            var resultRemoveBulkDensityCylinderMass = await _dimensionManager.RemoveAsync(filtrationPlaneGeotextileTest.TimeWaterFiltrationId);
            var resultRemoveThicknessPackage = await _dimensionManager.RemoveAsync(filtrationPlaneGeotextileTest.ThicknessPackageId);
            var resultRemoveActualTemperature = await _dimensionManager.RemoveAsync(filtrationPlaneGeotextileTest.ActualTemperatureId);
            var resultRemoveGeotextileFiltration = await _dimensionManager.RemoveAsync(filtrationPlaneGeotextileTest.GeotextileFiltrationId);


            return true;
        }

        public async Task<bool> UpdateAsync(FiltrationPlaneGeotextileTest filtrationPlaneGeotextileTestUpdate)
        {
            var dbFiltrationPlaneGeotextileTest = await _appDb.FiltrationPlaneGeotextileTests
                .FirstOrDefaultAsync(filtrationPlaneGeotextileTest => filtrationPlaneGeotextileTest.Id == filtrationPlaneGeotextileTestUpdate.Id);

            if (dbFiltrationPlaneGeotextileTest == null)
            {
                return false;
            }

            if (dbFiltrationPlaneGeotextileTest.TestNumber != filtrationPlaneGeotextileTestUpdate.TestNumber)
            {
                dbFiltrationPlaneGeotextileTest.TestNumber = filtrationPlaneGeotextileTestUpdate.TestNumber;
            }

            if (dbFiltrationPlaneGeotextileTest.MaterialName != filtrationPlaneGeotextileTestUpdate.MaterialName)
            {
                dbFiltrationPlaneGeotextileTest.MaterialName = filtrationPlaneGeotextileTestUpdate.MaterialName;
            }

            if (dbFiltrationPlaneGeotextileTest.CustomerId != filtrationPlaneGeotextileTestUpdate.CustomerId)
            {
                dbFiltrationPlaneGeotextileTest.CustomerId = filtrationPlaneGeotextileTestUpdate.CustomerId;
            }

            if (dbFiltrationPlaneGeotextileTest.DateTest != filtrationPlaneGeotextileTestUpdate.DateTest)
            {
                dbFiltrationPlaneGeotextileTest.DateTest = filtrationPlaneGeotextileTestUpdate.DateTest;
            }

            if (dbFiltrationPlaneGeotextileTest.DocumentTest != filtrationPlaneGeotextileTestUpdate.DocumentTest)
            {
                dbFiltrationPlaneGeotextileTest.DocumentTest = filtrationPlaneGeotextileTestUpdate.DocumentTest;
            }

            if (dbFiltrationPlaneGeotextileTest.WaterVolume.DimensionValue != filtrationPlaneGeotextileTestUpdate.WaterVolume.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(filtrationPlaneGeotextileTestUpdate.WaterVolume);
            }

            if (dbFiltrationPlaneGeotextileTest.TimeWaterFiltration.DimensionValue != filtrationPlaneGeotextileTestUpdate.TimeWaterFiltration.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(filtrationPlaneGeotextileTestUpdate.TimeWaterFiltration);
            }

            if (dbFiltrationPlaneGeotextileTest.ThicknessPackage.DimensionValue != filtrationPlaneGeotextileTestUpdate.ThicknessPackage.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(filtrationPlaneGeotextileTestUpdate.ThicknessPackage);
            }

            if (dbFiltrationPlaneGeotextileTest.ActualTemperature.DimensionValue != filtrationPlaneGeotextileTestUpdate.ActualTemperature.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(filtrationPlaneGeotextileTestUpdate.ActualTemperature);
            }

            if (dbFiltrationPlaneGeotextileTest.GeotextileFiltration.DimensionValue != filtrationPlaneGeotextileTestUpdate.GeotextileFiltration.DimensionValue)
            {
                await _dimensionManager.UpdateAsync(filtrationPlaneGeotextileTestUpdate.GeotextileFiltration);
            }

            _appDb.SaveChanges();

            return true;
        }
    }
}
