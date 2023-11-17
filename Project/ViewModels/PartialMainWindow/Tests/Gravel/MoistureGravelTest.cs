using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private MoistureGravelTest moistureGravelTest;

        /// <summary>
        /// Тест по определению влажности щебня.
        /// </summary>
        public MoistureGravelTest MoistureGravelTest
        {
            get
            {
                if (moistureGravelTest == null)
                {
                    moistureGravelTest = new MoistureGravelTest();
                }

                return moistureGravelTest;
            }
            set => Set(ref moistureGravelTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению влажности щебня в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewMoistureGravelTest()
        {
            try
            {
                await _moistureGravelTestDBService.Add(MOISTURE_GRAVEL_TEST_ADRESS, MoistureGravelTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению влажности щебня в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditMoistureGravelTest()
        {
            try
            {
                await _moistureGravelTestDBService.Update(MOISTURE_GRAVEL_TEST_ADRESS, MoistureGravelTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета влажности щебня.
        /// </summary>
        public ICommand CalculateMoistureGravelTestCommand { get; }
        private bool CanCalculateMoistureGravelTestCommandExecute(object p) => true;
        private void OnCalculateMoistureGravelTestCommandExecuted(object p)
        {
            try
            {
                MoistureGravelTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению влажности щебня.
        /// </summary>
        public ICommand SaveMoistureGravelTestCommand { get; }
        private bool CanSaveMoistureGravelTestCommandExecute(object p) => true;
        private void OnSaveMoistureGravelTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditMoistureGravelTest();
            }
            else
            {
                SaveNewMoistureGravelTest();
            }
        }
    }
}
