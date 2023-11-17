using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private FlakyGrainsGravelTest flakyGrainsGravelTest;

        /// <summary>
        /// Тест по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        public FlakyGrainsGravelTest FlakyGrainsGravelTest
        {
            get
            {
                if (flakyGrainsGravelTest == null)
                {
                    flakyGrainsGravelTest = new FlakyGrainsGravelTest();
                }

                return flakyGrainsGravelTest;
            }
            set => Set(ref flakyGrainsGravelTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewFlakyGrainsGravelTest()
        {
            try
            {
                await _flakyGrainsGravelTestDBService.Add(FLAKY_GRAINS_GRAVEL_TEST_ADRESS, FlakyGrainsGravelTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению содержания зерен пластинчатой (лещадной) и игловатой формы в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditFlakyGrainsGravelTest()
        {
            try
            {
                await _flakyGrainsGravelTestDBService.Update(FLAKY_GRAINS_GRAVEL_TEST_ADRESS, FlakyGrainsGravelTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        public ICommand CalculateFlakyGrainsGravelTestCommand { get; }
        private bool CanCalculateFlakyGrainsGravelTestCommandExecute(object p) => true;
        private void OnCalculateFlakyGrainsGravelTestCommandExecuted(object p)
        {
            try
            {
                FlakyGrainsGravelTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        public ICommand SaveFlakyGrainsGravelTestCommand { get; }
        private bool CanSaveFlakyGrainsGravelTestCommandExecute(object p) => true;
        private void OnSaveFlakyGrainsGravelTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditFlakyGrainsGravelTest();
            }
            else
            {
                SaveNewFlakyGrainsGravelTest();
            }
        }
    }
}
