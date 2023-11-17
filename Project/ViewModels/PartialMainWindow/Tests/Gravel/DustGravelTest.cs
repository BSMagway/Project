using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private DustGravelTest dustGravelTest;

        /// <summary>
        /// Тест по определению содержания содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        public DustGravelTest DustGravelTest
        {
            get
            {
                if (dustGravelTest == null)
                {
                    dustGravelTest = new DustGravelTest();
                }

                return dustGravelTest;
            }
            set => Set(ref dustGravelTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению содержания пылевидных и глинистых частиц в щебне в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewDustGravelTest()
        {
            try
            {
                await _dustGravelTestDBService.Add(DUST_GRAVEL_TEST_ADRESS, DustGravelTest, User.Jwt);
                isSavedTest = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Метод дя редактирования теста по определению содержания пылевидных и глинистых частиц в щебне в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditDustGravelTest()
        {
            try
            {
                await _dustGravelTestDBService.Update(DUST_GRAVEL_TEST_ADRESS, DustGravelTest, User.Jwt);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        public ICommand CalculateDustGravelTestCommand { get; }
        private bool CanCalculateDustGravelTestCommandExecute(object p) => true;
        private void OnCalculateDustGravelTestCommandExecuted(object p)
        {
            try
            {
                DustGravelTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        public ICommand SaveDustGravelTestCommand { get; }
        private bool CanSaveDustGravelTestCommandExecute(object p) => true;
        private void OnSaveDustGravelTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditDustGravelTest();
            }
            else
            {
                SaveNewDustGravelTest();
            }
        }
    }
}
