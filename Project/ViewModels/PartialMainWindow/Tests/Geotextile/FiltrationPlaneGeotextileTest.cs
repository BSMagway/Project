using ProjectCommon.Models.Material.Geotextile;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.ViewModelBase;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private FiltrationPlaneGeotextileTest filtrationPlaneGeotextileTest;

        /// <summary>
        /// Тест по определению фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        public FiltrationPlaneGeotextileTest FiltrationPlaneGeotextileTest
        {
            get
            {
                if (filtrationPlaneGeotextileTest == null)
                {
                    filtrationPlaneGeotextileTest = new FiltrationPlaneGeotextileTest();
                }

                return filtrationPlaneGeotextileTest;
            }
            set => Set(ref filtrationPlaneGeotextileTest, value);
        }

        /// <summary>
        /// Метод по добавлению нового теста по определению фильтрации в плоскости геотекстильного полотна в базу данных.
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewFiltrationPlaneGeotextileTest()
        {
            try
            {
                await _filtrationPlaneGeotextileTestDBService.Add(FILTRATION_PLANE_GEOTEXTILE_TEST_ADRESS, FiltrationPlaneGeotextileTest, User.Jwt);
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
        /// Метод дя редактирования теста по определению фильтрации в плоскости геотекстильного полотна в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task EditFiltrationPlaneGeotextileTest()
        {
            try
            {
                await _filtrationPlaneGeotextileTestDBService.Update(FILTRATION_PLANE_GEOTEXTILE_TEST_ADRESS, FiltrationPlaneGeotextileTest, User.Jwt);
                ErrorMessage = "Протокол изменен.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Команда для расчета фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        public ICommand CalculateFiltrationPlaneGeotextileTestCommand { get; }
        private bool CanCalculateFiltrationPlaneGeotextileTestCommandExecute(object p) => true;
        private void OnCalculateFiltrationPlaneGeotextileTestCommandExecuted(object p)
        {
            try
            {
                FiltrationPlaneGeotextileTest.Calculate();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        public ICommand SaveFiltrationPlaneGeotextileTestCommand { get; }
        private bool CanSaveFiltrationPlaneGeotextileTestCommandExecute(object p) => true;
        private void OnSaveFiltrationPlaneGeotextileTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditFiltrationPlaneGeotextileTest();
            }
            else
            {
                SaveNewFiltrationPlaneGeotextileTest();
            }
        }
    }
}
