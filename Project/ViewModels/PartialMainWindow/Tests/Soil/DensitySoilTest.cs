using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private DensitySoilTest densitySoilTest;

        /// <summary>
        /// Тест по определению плотности грунта.
        /// </summary>
        public DensitySoilTest DensitySoilTest
        {
            get
            {
                if (densitySoilTest == null)
                {
                    densitySoilTest = new DensitySoilTest();
                }

                return densitySoilTest;
            }
            set => Set(ref densitySoilTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению плотности грунта в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewDensitySoilTest()
        {
            try
            {
                await _densitySoilTestDBService.Add(DENSITY_SOIL_TEST_ADRESS, DensitySoilTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению плотности грунта в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditDensitySoilTest()
        {
            try
            {
                await _densitySoilTestDBService.Update(DENSITY_SOIL_TEST_ADRESS, DensitySoilTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета плотности грунта.
        /// </summary>
        public ICommand CalculateDensitySoilTestCommand { get; }
        private bool CanCalculateDensitySoilTestCommandExecute(object p) => true;
        private void OnCalculateDensitySoilTestCommandExecuted(object p)
        {
            try
            {
                DensitySoilTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению плотности грунта.
        /// </summary>
        public ICommand SaveDensitySoilTestCommand { get; }
        private bool CanSaveDensitySoilTestCommandExecute(object p) => true;
        private void OnSaveDensitySoilTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditDensitySoilTest();
            }
            else
            {
                SaveNewDensitySoilTest();
            }
        }
    }
}
