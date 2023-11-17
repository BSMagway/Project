using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private CrushabilityGravelTest crushabilityGravelTest;

        /// <summary>
        /// Тест по определению дробимости щебня.
        /// </summary>
        public CrushabilityGravelTest CrushabilityGravelTest
        {
            get
            {
                if (crushabilityGravelTest == null)
                {
                    crushabilityGravelTest = new CrushabilityGravelTest();
                }

                return crushabilityGravelTest;
            }
            set => Set(ref crushabilityGravelTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению дробимости щебня в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewCrushabilityGravelTest()
        {
            try
            {
                await _crushabilityGravelTestDBService.Add(CRUSHABILITY_GRAVEL_TEST_ADRESS, CrushabilityGravelTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению дробимости щебня в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditCrushabilityGravelTest()
        {
            try
            {
                await _crushabilityGravelTestDBService.Update(CRUSHABILITY_GRAVEL_TEST_ADRESS, CrushabilityGravelTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета дробимости щебня.
        /// </summary>
        public ICommand CalculateCrushabilityGravelTestCommand { get; }
        private bool CanCalculateCrushabilityGravelTestCommandExecute(object p) => true;
        private void OnCalculateCrushabilityGravelTestCommandExecuted(object p)
        {
            try
            {
                CrushabilityGravelTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению дробимости щебня.
        /// </summary>
        public ICommand SaveCrushabilityGravelTestCommand { get; }
        private bool CanSaveCrushabilityGravelTestCommandExecute(object p) => true;
        private void OnSaveCrushabilityGravelTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditCrushabilityGravelTest();
            }
            else
            {
                SaveNewCrushabilityGravelTest();
            }
        }
    }
}
