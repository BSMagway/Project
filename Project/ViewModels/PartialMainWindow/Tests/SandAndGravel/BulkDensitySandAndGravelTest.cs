using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.SandAndGravel;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private BulkDensitySandAndGravelTest bulkDensitySandAndGravelTest;

        /// <summary>
        /// Тест по определению насыпной плотности ПГС.
        /// </summary>
        public BulkDensitySandAndGravelTest BulkDensitySandAndGravelTest
        {
            get
            {
                if (bulkDensitySandAndGravelTest == null)
                {
                    bulkDensitySandAndGravelTest = new BulkDensitySandAndGravelTest();
                }

                return bulkDensitySandAndGravelTest;
            }
            set => Set(ref bulkDensitySandAndGravelTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению насыпной плотности ПГС в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewBulkDensitySandAndGravelTest()
        {
            try
            {
                await _bulkDensitySandAndGravelTestDBService.Add(BULK_DENSITY_SAND_AND_GRAVEL_TEST_ADRESS, BulkDensitySandAndGravelTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению насыпной плотности ПГС в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditBulkDensitySandAndGravelTest()
        {
            try
            {
                await _bulkDensitySandAndGravelTestDBService.Update(BULK_DENSITY_SAND_AND_GRAVEL_TEST_ADRESS, BulkDensitySandAndGravelTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета насыпной плотности ПГС.
        /// </summary>
        public ICommand CalculateBulkDensitySandAndGravelTestCommand { get; }
        private bool CanCalculateBulkDensitySandAndGravelTestCommandExecute(object p) => true;
        private void OnCalculateBulkDensitySandAndGravelTestCommandExecuted(object p)
        {
            try
            {
                BulkDensitySandAndGravelTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению насыпной плотности ПГС.
        /// </summary>
        public ICommand SaveBulkDensitySandAndGravelTestCommand { get; }
        private bool CanSaveBulkDensitySandAndGravelTestCommandExecute(object p) => true;
        private void OnSaveBulkDensitySandAndGravelTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditBulkDensitySandAndGravelTest();
            }
            else
            {
                SaveNewBulkDensitySandAndGravelTest();
            }
        }
    }
}
