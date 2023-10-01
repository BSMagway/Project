using Project.Views.UserControls.CustomersUserControl;
using ProjectCommon.Enums;
using ProjectCommon.Models;
using ProjectCommon.ViewModelBase;
using System;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        #region Select Commands

        /// <summary>
        /// Команда для выбора новой задачи (создание нового теста, загрузка существующего теста и тд.).
        /// </summary>
        public ICommand SelectNewTaskCommand { get; }
        private bool CanSelectNewTaskCommandExecute(object p) => true;
        private void OnSelectNewTaskCommandExecuted(object p)
        {
            var task = (Enum)p;

            switch (task)
            {
                case TaskType.NewTest:
                    {
                        MainUserControl = SelectTypeTestUserControl;
                        saveTestStatus = false;
                    }
                    break;
                case TaskType.LoadTest:
                    {
                        LoadAllTest();
                        MainUserControl = LoadTestsListUserControl;
                    }
                    break;
                case TaskType.CostumersList:
                    {
                        MainUserControl = CustomersListUserControl;
                    }
                    break;
            }

        }

        /// <summary>
        /// Команда для выбора теста в зависимости от испытываемого материала.
        /// </summary>
        public ICommand SelectTypeTestCommand { get; }
        private bool CanSelectTypeTestCommandExecute(object p) => true;

        private void OnSelectTypeTestCommandExecuted(object p)
        {
            var material = (Enum)p;

            switch (material)
            {
                case MaterialType.Soil:
                    {
                        MainUserControl = SoilTestsUserControl;
                    }
                    break;
                case MaterialType.Sand:
                    {
                        MainUserControl = SandTestsUserControl;
                    }
                    break;
                case MaterialType.Gravel:
                    {
                        MainUserControl = GravelTestsUserControl;
                    }
                    break;
                case MaterialType.SandAndGravel:
                    {
                        MainUserControl = SandAndGravelTestsUserControl;
                    }
                    break;
                case MaterialType.Geotextile:
                    {
                        MainUserControl = GeotextileTestsUserControl;
                    }
                    break;
            }

        }

        /// <summary>
        /// Команда для выбора вида испытания грунта.
        /// </summary>
        public ICommand SelectSoilTestCommand { get; }
        private bool CanSelectSoilTestCommandExecute(object p) => true;
        private void OnSelectSoilTestCommandExecuted(object p)
        {
            var test = (Enum)p;

            switch (test)
            {
                case ExperimentType.Moister:
                    MainUserControl = MoistureSoilTestUserControl;
                    break;
            }
        }

        /// <summary>
        /// Команда возвращения к меню выбора новой задачи.
        /// </summary>
        public ICommand ReturnToNewTaskPageCommand { get; }
        private bool CanReturnToNewTaskPageCommandExecute(object p) => true;
        private void OnReturnToNewTaskPageCommandExecuted(object p)
        {
            MainUserControl = SelectNewTaskUserControl;
        }

        #endregion

        #region Commands
        /// <summary>
        /// Команда отвечающая за загрузку теста из базы данных.
        /// </summary>
        public ICommand LoadTestFromBDCommand { get; }
        private bool CanLoadTestFromBDCommandExecute(object p) => true;
        private void OnLoadTestFromBDCommandExecuted(object p)
        {
            switch (TestForLoading.MaterialEnum)
            {
                case MaterialType.Soil:

                    switch (TestForLoading.TestEnum)
                    {
                        case ExperimentType.Moister:
                            LoadMoistureSoilTest();
                            MainUserControl = MoistureSoilTestUserControl;
                            break;
                    }

                    break;
            }
        }
        /// <summary>
        /// Команда отвечающая за добавление нового и редактирование существующего заказчика.
        /// </summary>
        public ICommand SaveEditCustomerInBDCommand { get; }
        private bool CanSaveEditCustomerInBDCommandExecute(object p) => true;
        private void OnSaveEditCustomerInBDCommandExecuted(object p)
        {
            if (saveCustomerStatus)
            {
                EditCostumer();
            }
            else
            {
                SaveCostumer();
            }

            MainUserControl = CustomersListUserControl;
        }
        /// <summary>
        /// Команда отвечающая за открытие формы для редактирования заказчика.
        /// </summary>
        public ICommand OpenFormForCustomerEditCommand { get; }
        private bool CanOpenFormForCustomerEditCommandExecute(object p) => true;
        private void OnOpenFormForCustomerEditCommandExecuted(object p)
        {
            MainUserControl = new FormForCustomerAddEditUserControl();
            MainUserControl.DataContext = this;
        }

        /// <summary>
        /// Команда отвечающая за открытие формы для добавления заказчика.
        /// </summary>
        public ICommand OpenFormForCustomerAddCommand { get; }
        private bool CanOpenFormForCustomerAddCommandExecute(object p) => true;
        private void OnOpenFormForCustomerAddCommandExecuted(object p)
        {
            SelectedCustomer = new Customer();
            MainUserControl = new FormForCustomerAddEditUserControl();
            MainUserControl.DataContext = this;
            saveCustomerStatus = false;
        }

        /// <summary>
        /// Команда для открытия выбора заказчика для добавления в тест.
        /// </summary>
        public ICommand OpenSelectCustomerCommand { get; }
        private bool CanOpenSelectCustomerCommandExecute(object p) => true;
        private void OnOpenSelectCustomerCommandExecuted(object p)
        {
            MainUserControl = CustomersSelectUserControl;
        }
        #endregion

        /// <summary>
        /// Команда для добавления выбранного заказчика в тест.
        /// </summary>
        public ICommand LoadCustomerFromListCommand { get; }
        private bool CanLoadCustomerFromListCommandExecute(object p) => true;
        private void OnLoadCustomerFromListCommandExecuted(object p)
        {
           //MoistureTest.Customer = SelectedCustomer;
            MainUserControl = MoistureSoilTestUserControl;
        }
    }
}
