using ProjectCommon.Models.Material.Sand;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private MoistureSandTest moistureSandTest;

        /// <summary>
        /// Тест по определению влажности песка.
        /// </summary>
        public MoistureSandTest MoistureSandTest
        {
            get
            {
                if (moistureSandTest == null)
                {
                    moistureSandTest = new MoistureSandTest();
                }

                return moistureSandTest;
            }
            set => Set(ref moistureSandTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению влажности песка в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewMoistureSandTest()
        {
            try
            {
                await _moistureSandTestDBService.Add(MOISTURE_SAND_TEST_ADRESS, MoistureSandTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению влажности песка в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditMoistureSandTest()
        {
            try
            {
                await _moistureSandTestDBService.Update(MOISTURE_SAND_TEST_ADRESS, MoistureSandTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета влажности песка.
        /// </summary>
        public ICommand CalculateMoistureSandTestCommand { get; }
        private bool CanCalculateMoistureSandTestCommandExecute(object p) => true;
        private void OnCalculateMoistureSandTestCommandExecuted(object p)
        {
            try
            {
                MoistureSandTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению влажности песка.
        /// </summary>
        public ICommand SaveMoistureSandTestCommand { get; }
        private bool CanSaveMoistureSandTestCommandExecute(object p) => true;
        private void OnSaveMoistureSandTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditMoistureSandTest();
            }
            else
            {
                SaveNewMoistureSandTest();
            }
        }
    }
}
