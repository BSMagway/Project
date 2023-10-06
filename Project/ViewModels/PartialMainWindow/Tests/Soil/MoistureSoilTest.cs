using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// Тест по определению важности грунта
        /// </summary>
        private MoistureSoilTest moistureTest;

        /// <summary>
        /// Тест по определению важности грунта
        /// </summary>
        public MoistureSoilTest MoistureTest
        {
            get
            {
                if (moistureTest == null)
                {
                    moistureTest = new MoistureSoilTest();
                }

                return moistureTest;
            }
            set => Set(ref moistureTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста в бд
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewMoistureSoilTest()
        {
            try
            {
                await _moistureSoilTestDBService.Add(MOISTURE_SOIL_TEST_ADRESS, MoistureTest, User.Jwt);
                isSavedTest = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Метод дя редактирования теста в бд
        /// </summary>
        /// <returns></returns>
        public async Task EditMoistureSoilTest()
        {
            try
            {
                await _moistureSoilTestDBService.Update(MOISTURE_SOIL_TEST_ADRESS, MoistureTest, User.Jwt);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для расчета влажности грунта
        /// </summary>
        public ICommand CalculateMoistureCommand { get; }
        private bool CanCalculateMoistureCommandExecute(object p) => true;
        private void OnCalculateMoistureCommandExecuted(object p)
        {
            try
            {
                MoistureTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению влажности грунта
        /// </summary>
        public ICommand SaveMoistureSoilTestCommand { get; }
        private bool CanSaveMoistureSoilTestCommandExecute(object p) => true;
        private void OnSaveMoistureSoilTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditMoistureSoilTest();
            }
            else
            {
                SaveNewMoistureSoilTest();
            }
        }
    }
}
