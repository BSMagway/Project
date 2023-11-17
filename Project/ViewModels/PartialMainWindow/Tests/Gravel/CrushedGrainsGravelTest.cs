using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private CrushedGrainsGravelTest crushedGrainsGravelTest;

        /// <summary>
        /// Тест по определению содержания содержания дробленых зерен в щебне из гравия.
        /// </summary>
        public CrushedGrainsGravelTest CrushedGrainsGravelTest
        {
            get
            {
                if (crushedGrainsGravelTest == null)
                {
                    crushedGrainsGravelTest = new CrushedGrainsGravelTest();
                }

                return crushedGrainsGravelTest;
            }
            set => Set(ref crushedGrainsGravelTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению содержания дробленых зерен в щебне из гравия в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewCrushedGrainsGravelTest()
        {
            try
            {
                await _crushedGrainsGravelTestDBService.Add(CRUSHED_GRAINS_GRAVEL_TEST_ADRESS, CrushedGrainsGravelTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению содержания дробленых зерен в щебне из гравия в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditCrushedGrainsGravelTest()
        {
            try
            {
                await _crushedGrainsGravelTestDBService.Update(CRUSHED_GRAINS_GRAVEL_TEST_ADRESS, CrushedGrainsGravelTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета содержания дробленых зерен в щебне из гравия.
        /// </summary>
        public ICommand CalculateCrushedGrainsGravelTestCommand { get; }
        private bool CanCalculateCrushedGrainsGravelTestCommandExecute(object p) => true;
        private void OnCalculateCrushedGrainsGravelTestCommandExecuted(object p)
        {
            try
            {
                CrushedGrainsGravelTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению содержания дробленых зерен в щебне из гравия.
        /// </summary>
        public ICommand SaveCrushedGrainsGravelTestCommand { get; }
        private bool CanSaveCrushedGrainsGravelTestCommandExecute(object p) => true;
        private void OnSaveCrushedGrainsGravelTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditCrushedGrainsGravelTest();
            }
            else
            {
                SaveNewCrushedGrainsGravelTest();
            }
        }
    }
}
