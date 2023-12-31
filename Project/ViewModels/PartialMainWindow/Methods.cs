﻿using Project.Views.UserControls.AuthUserControl;
using ProjectCommon.ViewModelBase;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// Загрузка списка заказчиков из базы данных.
        /// </summary>
        /// <returns></returns>
        private async Task LoadCostumersFromBD()
        {
            try
            {
                Customers = await _customerDBService.GetAll(CUSTOMER_ADRESS, User.Jwt);
                if (isSelectingCustomer)
                {
                    MainUserControl = CustomersSelectUserControl;
                }
                else
                {
                    MainUserControl = CustomersListUserControl;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Метод для редактирования заказчика в базе данных.
        /// </summary>
        /// <returns></returns>
        private async Task EditCostumer()
        {
            try
            {
                await _customerDBService.Update(CUSTOMER_ADRESS, selectedCustomer, User.Jwt);
                Customers[Customers.IndexOf(Customers.First(x => x.Id == selectedCustomer.Id))] = selectedCustomer;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }

        }

        /// <summary>
        /// Метод для добавления нового заказчика в базу данных.
        /// </summary>
        /// <returns></returns>
        private async Task SaveCostumer()
        {
            try
            {
                selectedCustomer = await _customerDBService.Add(CUSTOMER_ADRESS, selectedCustomer, User.Jwt);
                Customers.Add(selectedCustomer);
                isSavedCustomer = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }

        }

        /// <summary>
        /// Метод для авторизации пользователя.
        /// </summary>
        /// <returns></returns>
        public async Task LoginUser()
        {
            try
            {
                var item = await _authInterface.Login(LOGIN_ADRESS, LoginRequest);
                User = item;
                AuthUserControl = new LoggedUserControl();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Метод для регистрации пользователя.
        /// </summary>
        /// <returns></returns>
        public async Task RegisterUser()
        {
            try
            {
                await _authInterface.Registration(REGISTER_ADRESS, RegisterRequest);
                AuthUserControl = new LoginUserControl();
                ErrorMessage = "Вы зарегистрировались.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка короткого списка тестов из базы данных.
        /// </summary>
        /// <returns></returns>
        public async Task LoadAllTest()
        {
            try
            {
                var collection = await _testDBService.GetAll(LOAD_ALL_TEST_ADRESS, User.Jwt);
                LoadedListTests = collection;
                MainUserControl = LoadTestsListUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению влажности грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadMoistureSoilTest()
        {
            try
            {
                var item = await _moistureSoilTestDBService.Get(MOISTURE_SOIL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                MoistureSoilTest = item;
                EditTest = item;
                MainUserControl = MoistureSoilTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению предела раскатываемости грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadRollingBoundarySoilTest()
        {
            try
            {
                var item = await _rollingBoundarySoilTestDBService.Get(ROLLING_BOUNDARY_SOIL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                RollingBoundarySoilTest = item;
                EditTest = item;
                MainUserControl = RollingBoundarySoilTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению предела текучести грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadYieldLimitSoilTest()
        {
            try
            {
                var item = await _yieldLimitSoilTestDBService.Get(YIELD_LIMIT_SOIL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                YieldLimitSoilTest = item;
                EditTest = item;
                MainUserControl = YieldLimitSoilTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению плотности грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDensitySoilTest()
        {
            try
            {
                var item = await _densitySoilTestDBService.Get(DENSITY_SOIL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                DensitySoilTest = item;
                EditTest = item;
                MainUserControl = DensitySoilTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению содержания зерен слабых пород из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadWeakGrainsGravelTest()
        {
            try
            {
                var item = await _weakGrainsGravelTestDBService.Get(WEAK_GRAINS_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                WeakGrainsGravelTest = item;
                EditTest = item;
                MainUserControl = WeakGrainsGravelTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению влажности щебня из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadMoistureGravelTest()
        {
            try
            {
                var item = await _moistureGravelTestDBService.Get(MOISTURE_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                MoistureGravelTest = item;
                EditTest = item;
                MainUserControl = MoistureGravelTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadFlakyGrainsGravelTest()
        {
            try
            {
                var item = await _flakyGrainsGravelTestDBService.Get(FLAKY_GRAINS_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                FlakyGrainsGravelTest = item;
                EditTest = item;
                MainUserControl = FlakyGrainsGravelTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению содержания пылевидных и глинистых частиц в щебне из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDustGravelTest()
        {
            try
            {
                var item = await _dustGravelTestDBService.Get(DUST_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                DustGravelTest = item;
                EditTest = item;
                MainUserControl = DustGravelTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению содержания дробленых зерен в щебне из гравия из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadCrushedGrainsGravelTest()
        {
            try
            {
                var item = await _crushedGrainsGravelTestDBService.Get(CRUSHED_GRAINS_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                CrushedGrainsGravelTest = item;
                EditTest = item;
                MainUserControl = CrushedGrainsGravelTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению дробимости щебня из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadCrushabilityGravelTest()
        {
            try
            {
                var item = await _crushabilityGravelTestDBService.Get(CRUSHABILITY_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                CrushabilityGravelTest = item;
                EditTest = item;
                MainUserControl = CrushabilityGravelTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению содержания глины в комках в щебне из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadClayInLumpsGravelTest()
        {
            try
            {
                var item = await _clayInLumpsGravelTestDBService.Get(CLAY_IN_LUMPS_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                ClayInLumpsGravelTest = item;
                EditTest = item;
                MainUserControl = ClayInLumpsGravelTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению насыпной плотности щебня из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadBulkDensityGravelTest()
        {
            try
            {
                var item = await _bulkDensityGravelTestDBService.Get(BULK_DENSITY_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                BulkDensityGravelTest = item;
                EditTest = item;
                MainUserControl = BulkDensityGravelTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению насыпной плотности ПГС из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadBulkDensitySandAndGravelTest()
        {
            try
            {
                var item = await _bulkDensitySandAndGravelTestDBService.Get(BULK_DENSITY_SAND_AND_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                BulkDensitySandAndGravelTest = item;
                EditTest = item;
                MainUserControl = BulkDensitySandAndGravelTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению фильтрации в плоскости геотекстильного полотна из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadFiltrationPlaneGeotextileTest()
        {
            try
            {
                var item = await _filtrationPlaneGeotextileTestDBService.Get(FILTRATION_PLANE_GEOTEXTILE_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                FiltrationPlaneGeotextileTest = item;
                EditTest = item;
                MainUserControl = FiltrationPlaneGeotextileTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению влажности песка из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadMoistureSandTest()
        {
            try
            {
                var item = await _moistureSandTestDBService.Get(MOISTURE_SAND_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                MoistureSandTest = item;
                EditTest = item;
                MainUserControl = MoistureSandTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению содержания пылевидных и глинистых частиц в песке из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDustSandTest()
        {
            try
            {
                var item = await _dustSandTestDBService.Get(DUST_SAND_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                DustSandTest = item;
                EditTest = item;
                MainUserControl = DustSandTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Загрузка теста по определению насыпной плотности песка из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadBulkDensitySandTest()
        {
            try
            {
                var item = await _bulkDensitySandTestDBService.Get(BULK_DENSITY_SAND_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                BulkDensitySandTest = item;
                EditTest = item;
                MainUserControl = BulkDensitySandTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению влажности грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteMoistureSoilTest()
        {
            try
            {
                await _moistureSoilTestDBService.Delete(MOISTURE_SOIL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению предела раскатываемости грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteRollingBoundarySoilTest()
        {
            try
            {
                await _rollingBoundarySoilTestDBService.Delete(ROLLING_BOUNDARY_SOIL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению предела текучести грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteYieldLimitSoilTest()
        {
            try
            {
                await _yieldLimitSoilTestDBService.Delete(YIELD_LIMIT_SOIL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению плотности грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteDensitySoilTest()
        {
            try
            {
                await _densitySoilTestDBService.Delete(DENSITY_SOIL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению содержания зерен слабых пород из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteWeakGrainsGravelTest()
        {
            try
            {
                await _weakGrainsGravelTestDBService.Delete(WEAK_GRAINS_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению влажности щебня из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteMoistureGravelTest()
        {
            try
            {
                await _moistureGravelTestDBService.Delete(MOISTURE_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteFlakyGrainsGravelTest()
        {
            try
            {
                await _flakyGrainsGravelTestDBService.Delete(FLAKY_GRAINS_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению содержания пылевидных и глинистых частиц в щебне из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteDustGravelTest()
        {
            try
            {
                await _dustGravelTestDBService.Delete(DUST_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению содержания дробленых зерен в щебне из гравия из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteCrushedGrainsGravelTest()
        {
            try
            {
                await _crushedGrainsGravelTestDBService.Delete(CRUSHED_GRAINS_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению дробимости щебня из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteCrushabilityGravelTest()
        {
            try
            {
                await _crushabilityGravelTestDBService.Delete(CRUSHABILITY_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению содержания глины в комках в щебне из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteClayInLumpsGravelTest()
        {
            try
            {
                await _clayInLumpsGravelTestDBService.Delete(CLAY_IN_LUMPS_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению насыпной плотности щебня из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteBulkDensityGravelTest()
        {
            try
            {
                await _bulkDensityGravelTestDBService.Delete(BULK_DENSITY_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению насыпной плотности ПГС из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteBulkDensitySandAndGravelTest()
        {
            try
            {
                await _bulkDensitySandAndGravelTestDBService.Delete(BULK_DENSITY_SAND_AND_GRAVEL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению фильтрации в плоскости геотекстильного полотна из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteFiltrationPlaneGeotextileTest()
        {
            try
            {
                await _filtrationPlaneGeotextileTestDBService.Delete(FILTRATION_PLANE_GEOTEXTILE_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению влажности песка из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteMoistureSandTest()
        {
            try
            {
                await _moistureSandTestDBService.Delete(MOISTURE_SAND_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению содержания пылевидных и глинистых частиц в песке из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteDustSandTest()
        {
            try
            {
                await _dustSandTestDBService.Delete(DUST_SAND_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Удаление теста по определению насыпной плотности песка из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteBulkDensitySandTest()
        {
            try
            {
                await _bulkDensitySandTestDBService.Delete(BULK_DENSITY_SAND_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                LoadedListTests.Remove(TestForLoading);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }
    }
}
