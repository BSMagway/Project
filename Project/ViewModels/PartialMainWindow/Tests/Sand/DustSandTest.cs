using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Sand;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private DustSandTest dustSandTest;

        /// <summary>
        /// Тест по определению содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        public DustSandTest DustSandTest
        {
            get
            {
                if (dustSandTest == null)
                {
                    dustSandTest = new DustSandTest();
                }

                return dustSandTest;
            }
            set => Set(ref dustSandTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewDustSandTest()
        {
            try
            {
                await _dustSandTestDBService.Add(DUST_SAND_TEST_ADRESS, DustSandTest, User.Jwt);
                isSavedTest = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Метод дя редактирования теста по определению содержания пылевидных и глинистых частиц в песке в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditDustSandTest()
        {
            try
            {
                await _dustSandTestDBService.Update(DUST_SAND_TEST_ADRESS, DustSandTest, User.Jwt);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для расчета содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        public ICommand CalculateDustSandTestCommand { get; }
        private bool CanCalculateDustSandTestCommandExecute(object p) => true;
        private void OnCalculateDustSandTestCommandExecuted(object p)
        {
            try
            {
                DustSandTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        public ICommand SaveDustSandTestCommand { get; }
        private bool CanSaveDustSandTestCommandExecute(object p) => true;
        private void OnSaveDustSandTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditDustSandTest();
            }
            else
            {
                SaveNewDustSandTest();
            }
        }
    }
}
