using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private RollingBoundarySoilTest rollingBoundarySoilTest;

        /// <summary>
        /// Тест по определению границы раскатываемости грунта.
        /// </summary>
        public RollingBoundarySoilTest RollingBoundarySoilTest
        {
            get
            {
                if (rollingBoundarySoilTest == null)
                {
                    rollingBoundarySoilTest = new RollingBoundarySoilTest();
                }

                return rollingBoundarySoilTest;
            }
            set => Set(ref rollingBoundarySoilTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению границы раскатываемости в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewRollingBoundarySoilTest()
        {
            try
            {
                await _rollingBoundarySoilTestDBService.Add(ROLLING_BOUNDARY_SOIL_TEST_ADRESS, RollingBoundarySoilTest, User.Jwt);
                isSavedTest = true;
                ErrorMessage = "Протокол сохранен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Метод дя редактирования теста по определению границы расскатываемости в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditRollingBoundarySoilTest()
        {
            try
            {
                await _rollingBoundarySoilTestDBService.Update(ROLLING_BOUNDARY_SOIL_TEST_ADRESS, RollingBoundarySoilTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета границы раскатываемости грунта.
        /// </summary>
        public ICommand CalculateRollingBoundarySoilTestCommand { get; }
        private bool CanCalculateRollingBoundarySoilTestCommandExecute(object p) => true;
        private void OnCalculateRollingBoundarySoilTestCommandExecuted(object p)
        {
            try
            {
                RollingBoundarySoilTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению границы раскатываемости грунта.
        /// </summary>
        public ICommand SaveRollingBoundarySoilTestCommand { get; }
        private bool CanSaveRollingBoundarySoilTestCommandExecute(object p) => true;
        private void OnSaveRollingBoundarySoilTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditRollingBoundarySoilTest();
            }
            else
            {
                SaveNewRollingBoundarySoilTest();
            }
        }
    }
}
