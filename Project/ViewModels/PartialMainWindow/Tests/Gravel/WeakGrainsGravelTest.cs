using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private WeakGrainsGravelTest weakGrainsGravelTest;

        /// <summary>
        /// Тест по определению содержания зерен слабых пород.
        /// </summary>
        public WeakGrainsGravelTest WeakGrainsGravelTest
        {
            get
            {
                if (weakGrainsGravelTest == null)
                {
                    weakGrainsGravelTest = new WeakGrainsGravelTest();
                }

                return weakGrainsGravelTest;
            }
            set => Set(ref weakGrainsGravelTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению содержания зерен слабых пород в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewWeakGrainsGravelTest()
        {
            try
            {
                await _weakGrainsGravelTestDBService.Add(WEAK_GRAINS_GRAVEL_TEST_ADRESS, WeakGrainsGravelTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению содержания зерен слабых пород в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditWeakGrainsGravelTest()
        {
            try
            {
                await _weakGrainsGravelTestDBService.Update(WEAK_GRAINS_GRAVEL_TEST_ADRESS, WeakGrainsGravelTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета содержания зерен слабых пород.
        /// </summary>
        public ICommand CalculateWeakGrainsGravelTestCommand { get; }
        private bool CanCalculateWeakGrainsGravelTestCommandExecute(object p) => true;
        private void OnCalculateWeakGrainsGravelTestCommandExecuted(object p)
        {
            try
            {
                WeakGrainsGravelTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению содержания зерен слабых пород.
        /// </summary>
        public ICommand SaveWeakGrainsGravelTestCommand { get; }
        private bool CanSaveWeakGrainsGravelTestCommandExecute(object p) => true;
        private void OnSaveWeakGrainsGravelTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditWeakGrainsGravelTest();
            }
            else
            {
                SaveNewWeakGrainsGravelTest();
            }
        }
    }
}
