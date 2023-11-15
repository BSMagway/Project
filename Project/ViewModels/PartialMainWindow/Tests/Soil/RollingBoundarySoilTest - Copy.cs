using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private YieldLimitSoilTest yieldLimitSoilTest;

        /// <summary>
        /// Тест по определению границы раскатываемости грунта.
        /// </summary>
        public YieldLimitSoilTest YieldLimitSoilTest
        {
            get
            {
                if (yieldLimitSoilTest == null)
                {
                    yieldLimitSoilTest = new YieldLimitSoilTest();
                }

                return yieldLimitSoilTest;
            }
            set => Set(ref yieldLimitSoilTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению границы раскатываемости в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewYieldLimitSoilTest()
        {
            try
            {
                await _yieldLimitSoilTestDBService.Add(YIELD_LIMIT_SOIL_TEST_ADRESS, YieldLimitSoilTest, User.Jwt);
                isSavedTest = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Метод дя редактирования теста по определению границы расскатываемости в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditYieldLimitSoilTest()
        {
            try
            {
                await _rollingBoundarySoilTestDBService.Update(ROLLING_BOUNDARY_SOIL_TEST_ADRESS, RollingBoundarySoilTest, User.Jwt);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для расчета границы раскатываемости грунта.
        /// </summary>
        public ICommand CalculateYieldLimitSoilTestCommand { get; }
        private bool CanCalculateYieldLimitSoilTestCommandExecute(object p) => true;
        private void OnCalculateYieldLimitSoilTestCommandExecuted(object p)
        {
            try
            {
                YieldLimitSoilTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению границы раскатываемости грунта.
        /// </summary>
        public ICommand SaveYieldLimitSoilTestCommand { get; }
        private bool CanSaveYieldLimitSoilTestCommandExecute(object p) => true;
        private void OnSaveYieldLimitSoilTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditYieldLimitSoilTest();
            }
            else
            {
                SaveNewYieldLimitSoilTest();
            }
        }
    }
}
