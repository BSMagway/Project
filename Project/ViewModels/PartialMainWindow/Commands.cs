using Project.Views.UserControls.AuthUserControl;
using Project.Views.UserControls.CustomersUserControl;
using ProjectCommon.Enums;
using ProjectCommon.Models;
using ProjectCommon.Models.Authentication;
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
                    MoistureSoilTest = null;
                    MainUserControl = MoistureSoilTestUserControl;
                    break;
                case ExperimentType.Rolling_Boundary:
                    RollingBoundarySoilTest = null;
                    MainUserControl = RollingBoundarySoilTestUserControl;
                    break;
                case ExperimentType.Yield_Limit:
                    YieldLimitSoilTest = null;
                    MainUserControl = YieldLimitSoilTestUserControl;
                    break;
                case ExperimentType.Density:
                    DensitySoilTest = null;
                    MainUserControl = DensitySoilTestUserControl;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Команда для выбора вида испытания ПГС.
        /// </summary>
        public ICommand SelectSandAndGravelTestCommand { get; }
        private bool CanSelectSandAndGravelTestCommandExecute(object p) => true;
        private void OnSelectSandAndGravelTestCommandExecuted(object p)
        {
            var test = (Enum)p;

            switch (test)
            {
                case ExperimentType.Density:
                    BulkDensitySandAndGravelTest = null;
                    MainUserControl = BulkDensitySandAndGravelTestUserControl;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Команда для выбора вида испытания щебня.
        /// </summary>
        public ICommand SelectGravelTestCommand { get; }
        private bool CanSelectGravelTestCommandExecute(object p) => true;
        private void OnSelectGravelTestCommandExecuted(object p)
        {
            var test = (Enum)p;

            switch (test)
            {
                case ExperimentType.Weak_Grains:
                    WeakGrainsGravelTest = null;
                    MainUserControl = WeakGrainsGravelTestUserControl;
                    break;
                case ExperimentType.Moister:
                    MoistureGravelTest = null;
                    MainUserControl = MoistureGravelTestUserControl;
                    break;
                case ExperimentType.Flaky_Grains:
                    FlakyGrainsGravelTest = null;
                    MainUserControl = FlakyGrainsGravelTestUserControl;
                    break;
                case ExperimentType.Dust:
                    DustGravelTest = null;
                    MainUserControl = DustGravelTestUserControl;
                    break;
                case ExperimentType.Crushed_Grains:
                    CrushedGrainsGravelTest = null;
                    MainUserControl = CrushedGrainsGravelTestUserControl;
                    break;
                case ExperimentType.Crushability:
                    CrushabilityGravelTest = null;
                    MainUserControl = CrushabilityGravelTestUserControl;
                    break;
                case ExperimentType.Clay_In_Lumps:
                    ClayInLumpsGravelTest = null;
                    MainUserControl = ClayInLumpsGravelTestUserControl;
                    break;
                case ExperimentType.Bulk_Density:
                    BulkDensityGravelTest = null;
                    MainUserControl = BulkDensityGravelTestUserControl;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Команда для выбора вида испытания геотекстиля.
        /// </summary>
        public ICommand SelectGeotextileTestCommand { get; }
        private bool CanSelectGeotextileTestCommandExecute(object p) => true;
        private void OnSelectGeotextileTestCommandExecuted(object p)
        {
            var test = (Enum)p;

            switch (test)
            {
                case ExperimentType.Filtration:
                    FiltrationPlaneGeotextileTest = null;
                    MainUserControl = FiltrationPlaneGeotextileTestUserControl;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Команда для выбора вида испытания грунта.
        /// </summary>
        public ICommand SelectSandTestCommand { get; }
        private bool CanSelectSandTestCommandExecute(object p) => true;
        private void OnSelectSandTestCommandExecuted(object p)
        {
            var test = (Enum)p;

            switch (test)
            {
                case ExperimentType.Moister:
                    MoistureSandTest = null;
                    MainUserControl = MoistureGravelTestUserControl;
                    break;
                case ExperimentType.Dust:
                    DustSandTest = null;
                    MainUserControl = DustSandTestUserControl;
                    break;
                case ExperimentType.Bulk_Density:
                    BulkDensitySandTest = null;
                    MainUserControl = BulkDensitySandTestUserControl;
                    break;
                default:
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
                        case ExperimentType.Rolling_Boundary:
                            LoadRollingBoundarySoilTest();
                            break;
                        case ExperimentType.Yield_Limit:
                            LoadYieldLimitSoilTest();
                            break;
                        case ExperimentType.Density:
                            LoadDensitySoilTest();
                            break;
                        default: 
                            break;
                    }
                 break;
                case MaterialType.Gravel:
                    switch (TestForLoading.TestEnum)
                    {
                        case ExperimentType.Weak_Grains:
                            LoadWeakGrainsGravelTest();
                            break;
                        case ExperimentType.Moister:
                            LoadMoistureGravelTest();
                            break;
                        case ExperimentType.Flaky_Grains:
                            LoadFlakyGrainsGravelTest();
                            break;
                        case ExperimentType.Dust:
                            LoadDustSandTest();
                            break;
                        case ExperimentType.Crushed_Grains:
                            LoadCrushedGrainsGravelTest();
                            break;
                        case ExperimentType.Crushability:
                            LoadCrushabilityGravelTest();
                            break;
                        case ExperimentType.Clay_In_Lumps:
                            LoadClayInLumpsGravelTest();
                            break;
                        case ExperimentType.Bulk_Density:
                            LoadBulkDensityGravelTest();
                            break;
                        default:
                            break;
                    }
                    break;
                case MaterialType.Sand:
                    switch (TestForLoading.TestEnum)
                    {
                        case ExperimentType.Moister:
                            LoadMoistureSandTest();
                            break;
                        case ExperimentType.Dust:
                            LoadDustSandTest();
                            break;
                        case ExperimentType.Bulk_Density:
                            LoadBulkDensitySandTest();
                            break;
                        default:
                            break;
                    }
                    break;
                case MaterialType.SandAndGravel:
                    switch (TestForLoading.TestEnum)
                    {
                        case ExperimentType.Bulk_Density:
                            LoadBulkDensitySandAndGravelTest();
                            break;
                        default:
                            break;
                    }
                    break;
                case MaterialType.Geotextile:
                    switch (TestForLoading.TestEnum)
                    {
                        case ExperimentType.Filtration:
                            LoadFiltrationPlaneGeotextileTest();
                            break;
                        default:
                            break;
                    }
                    break;
                default: 
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

        /// <summary>
        /// Команда для авторизации пользователя.
        /// </summary>
        public ICommand OpenRegisterUserFormCommand { get; }
        private bool CanOpenRegisterUserFormCommandExecute(object p) => true;
        private void OnOpenRegisterUserFormCommandExecuted(object p)
        {
            RegisterRequest = new RegisterRequest();
            AuthUserControl = new RegisterUserControl();
            LoginRequest = null;
        }

        /// <summary>
        /// Команда для возврата в меню логина.
        /// </summary>
        public ICommand ReturnToLoginUserFormCommand { get; }
        private bool CanReturnToLoginUserFormCommandExecute(object p) => true;
        private void OnReturnToLoginUserFormCommandExecuted(object p)
        {
            AuthUserControl = new LoginUserControl();
        }

        /// <summary>
        /// Команда для регистрации нового пользователя.
        /// </summary>
        public ICommand RegisterNewUserFormCommand { get; }
        private bool CanRegisterNewUserFormCommandExecute(object p) => true;
        private void OnRegisterNewUserFormCommandExecuted(object p)
        {
            RegisterUser();
        }

        /// <summary>
        /// Команда для выхода пользователя.
        /// </summary>
        public ICommand ExitUserFormCommand { get; }
        private bool CanExitUserFormCommandExecute(object p) => true;
        private void OnExitUserFormCommandExecuted(object p)
        {
            User = null;
            LoginRequest = null;
            AuthUserControl = new LoginUserControl();
        }
    }
}
