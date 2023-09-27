using ProjectCommon.ViewModelBase;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// Команда для добавления выбранного заказчика в тест.
        /// </summary>
        public ICommand LoadCostumerFromListCommand { get; }
        private bool CanLoadCostumerFromListCommandExecute(object p) => true;
        private void OnLoadCostumerFromListCommandExecuted(object p)
        {
            MoistureTest.CustomerTest = SelectedCostumer;
            FramePage = MoistureSoilTestUserControl;
        }
    }
}
