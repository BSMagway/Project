﻿using Project.Views.UserControls.CustomersUserControl;
using ProjectCommon.Enums;
using ProjectCommon.Models;
using ProjectCommon.ViewModelBase;
using System;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
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
                        isSavedTest = false;
                    }
                    break;
                case TaskType.LoadTest:
                    {
                        LoadAllTest();
                    }
                    break;
                case TaskType.CostumersList:
                    {
                        LoadCostumersFromBD();
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
                        MainUserControl = SelectSoilTestsUserControl;
                    }
                    break;
                case MaterialType.Sand:
                    {
                        MainUserControl = SelectSandTestsUserControl;
                    }
                    break;
                case MaterialType.Gravel:
                    {
                        MainUserControl = SelectGravelTestsUserControl;
                    }
                    break;
                case MaterialType.SandAndGravel:
                    {
                        MainUserControl = SelectSandAndGravelTestsUserControl;
                    }
                    break;
                case MaterialType.Geotextile:
                    {
                        MainUserControl = SelectGeotextileTestsUserControl;
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
                case ExperimentType.Rolling_Boundary:
                    MainUserControl = RollingBoundarySoilTestUserControl;
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
            ErrorMessage = string.Empty;
        }

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
            if (isSavedCustomer)
            {
                EditCostumer();
            }
            else
            {
                SaveCostumer();
            }

            if (isSavedTest)
            {
                MainUserControl = CustomersListUserControl;
            }
            else
            {
                MainUserControl = CustomersSelectUserControl;
            }

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
            isSavedCustomer = false;
        }

        /// <summary>
        /// Команда для открытия выбора заказчика для добавления в тест.
        /// </summary>
        public ICommand OpenSelectCustomerCommand { get; }
        private bool CanOpenSelectCustomerCommandExecute(object p) => true;
        private void OnOpenSelectCustomerCommandExecuted(object p)
        {
            isSelectingCustomer = true;
            LoadCostumersFromBD();
        }

        /// <summary>
        /// Команда для добавления выбранного заказчика в тест.
        /// </summary>
        public ICommand LoadCustomerFromListCommand { get; }
        private bool CanLoadCustomerFromListCommandExecute(object p) => true;
        private void OnLoadCustomerFromListCommandExecuted(object p)
        {
            MoistureSoilTest.Customer = SelectedCustomer;
            isSelectingCustomer = false;
            MainUserControl = MoistureSoilTestUserControl;
        }

        /// <summary>
        /// Команда для авторизации пользователя.
        /// </summary>
        public ICommand LoginUserCommand { get; }
        private bool CanLoginUserCommandExecute(object p) => true;
        private void OnLoginUserCommandExecuted(object p)
        {
            LoginUser();
        }
    }
}
