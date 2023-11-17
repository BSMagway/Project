using ProjectCommon.Models.Material.Sand;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private BulkDensitySandTest bulkDensitySandTest;

        /// <summary>
        /// Тест по определению насыпной плотности песка.
        /// </summary>
        public BulkDensitySandTest BulkDensitySandTest
        {
            get
            {
                if (bulkDensitySandTest == null)
                {
                    bulkDensitySandTest = new BulkDensitySandTest();
                }

                return bulkDensitySandTest;
            }
            set => Set(ref bulkDensitySandTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению насыпной плотности песка в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewBulkDensitySandTest()
        {
            try
            {
                await _bulkDensitySandTestDBService.Add(BULK_DENSITY_SAND_TEST_ADRESS, BulkDensitySandTest, User.Jwt);
                isSavedTest = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Метод дя редактирования теста по определению насыпной плотности песка в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditBulkDensitySandTest()
        {
            try
            {
                await _bulkDensitySandTestDBService.Update(BULK_DENSITY_SAND_TEST_ADRESS, BulkDensitySandTest, User.Jwt);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета насыпной плотности песка.
        /// </summary>
        public ICommand CalculateBulkDensitySandTestCommand { get; }
        private bool CanCalculateBulkDensitySandTestCommandExecute(object p) => true;
        private void OnCalculateBulkDensitySandTestCommandExecuted(object p)
        {
            try
            {
                BulkDensitySandTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению насыпной плотности песка.
        /// </summary>
        public ICommand SaveBulkDensitySandTestCommand { get; }
        private bool CanSaveBulkDensitySandTestCommandExecute(object p) => true;
        private void OnSaveBulkDensitySandTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditBulkDensitySandTest();
            }
            else
            {
                SaveNewBulkDensitySandTest();
            }
        }
    }
}
