using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private MoistureSoilTest moistureSoilTest;

        /// <summary>
        /// Тест по определению важности грунта.
        /// </summary>
        public MoistureSoilTest MoistureSoilTest
        {
            get
            {
                if (moistureSoilTest == null)
                {
                    moistureSoilTest = new MoistureSoilTest();
                }

                return moistureSoilTest;
            }
            set => Set(ref moistureSoilTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению влажности грунта в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewMoistureSoilTest()
        {
            try
            {
                await _moistureSoilTestDBService.Add(MOISTURE_SOIL_TEST_ADRESS, MoistureSoilTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению влажности грунта в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditMoistureSoilTest()
        {
            try
            {
                await _moistureSoilTestDBService.Update(MOISTURE_SOIL_TEST_ADRESS, MoistureSoilTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета влажности грунта.
        /// </summary>
        public ICommand CalculateMoistureSoilTestCommand { get; }
        private bool CanCalculateMoistureSoilTestCommandExecute(object p) => true;
        private void OnCalculateMoistureSoilTestCommandExecuted(object p)
        {
            try
            {
                MoistureSoilTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению влажности грунта.
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
