using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private ClayInLumpsGravelTest clayInLumpsGravelTest;

        /// <summary>
        /// Тест по определению содержания глины в комках в щебне.
        /// </summary>
        public ClayInLumpsGravelTest ClayInLumpsGravelTest
        {
            get
            {
                if (clayInLumpsGravelTest == null)
                {
                    clayInLumpsGravelTest = new ClayInLumpsGravelTest();
                }

                return clayInLumpsGravelTest;
            }
            set => Set(ref clayInLumpsGravelTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению содержания глины в комках в щебне в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewClayInLumpsGravelTest()
        {
            try
            {
                await _clayInLumpsGravelTestDBService.Add(CLAY_IN_LUMPS_GRAVEL_TEST_ADRESS, ClayInLumpsGravelTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению содержания глины в комках в щебне в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditClayInLumpsGravelTest()
        {
            try
            {
                await _clayInLumpsGravelTestDBService.Update(CLAY_IN_LUMPS_GRAVEL_TEST_ADRESS, ClayInLumpsGravelTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета содержания глины в комках в щебне.
        /// </summary>
        public ICommand CalculateClayInLumpsGravelTestCommand { get; }
        private bool CanCalculateClayInLumpsGravelTestCommandExecute(object p) => true;
        private void OnCalculateClayInLumpsGravelTestCommandExecuted(object p)
        {
            try
            {
                ClayInLumpsGravelTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению содержания глины в комках в щебне.
        /// </summary>
        public ICommand SaveClayInLumpsGravelTestCommand { get; }
        private bool CanSaveClayInLumpsGravelTestCommandExecute(object p) => true;
        private void OnSaveClayInLumpsGravelTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditClayInLumpsGravelTest();
            }
            else
            {
                SaveNewClayInLumpsGravelTest();
            }
        }
    }
}
