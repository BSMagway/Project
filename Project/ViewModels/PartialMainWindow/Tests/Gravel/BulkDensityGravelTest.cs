using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private BulkDensityGravelTest bulkDensityGravelTest;

        /// <summary>
        /// Тест по определению насыпной плотности щебня.
        /// </summary>
        public BulkDensityGravelTest BulkDensityGravelTest
        {
            get
            {
                if (bulkDensityGravelTest == null)
                {
                    bulkDensityGravelTest = new BulkDensityGravelTest();
                }

                return bulkDensityGravelTest;
            }
            set => Set(ref bulkDensityGravelTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению насыпной плотности щебня в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewBulkDensityGravelTest()
        {
            try
            {
                await _bulkDensityGravelTestDBService.Add(BULK_DENSITY_GRAVEL_TEST_ADRESS, BulkDensityGravelTest, User.Jwt);
                isSavedTest = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Метод дя редактирования теста по определению насыпной плотности щебня в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditBulkDensityGravelTest()
        {
            try
            {
                await _bulkDensityGravelTestDBService.Update(BULK_DENSITY_GRAVEL_TEST_ADRESS, BulkDensityGravelTest, User.Jwt);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета насыпной плотности щебня.
        /// </summary>
        public ICommand CalculateBulkDensityGravelTestCommand { get; }
        private bool CanCalculateBulkDensityGravelTestCommandExecute(object p) => true;
        private void OnCalculateBulkDensityGravelTestCommandExecuted(object p)
        {
            try
            {  
                BulkDensityGravelTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению насыпной плотности щебня.
        /// </summary>
        public ICommand SaveBulkDensityGravelTestCommand { get; }
        private bool CanSaveBulkDensityGravelTestCommandExecute(object p) => true;
        private void OnSaveBulkDensityGravelTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditBulkDensityGravelTest();
            }
            else
            {
                SaveNewBulkDensityGravelTest();
            }
        }
    }
}
