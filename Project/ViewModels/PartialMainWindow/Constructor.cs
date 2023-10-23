using Project.Interfaces.Services;
using Project.ViewModels.Commands;
using Project.Views.UserControls.AuthUserControl;
using ProjectCommon.Models;
using ProjectCommon.Models.Base;
using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel(IWorkWithBDGeneric<Customer> customerDBService,
            IWorkWithBDGeneric<MoistureSoilTest> moistureSoilTestDBService,
            IWorkWithBDGeneric<RollingBoundarySoilTest> rollingBoundarySoilTestDBService,
            IWorkWithBDGeneric<YieldLimitSoilTest> yieldLimitSoilTestDBService,
            IWorkWithBDGeneric<Test> testDbService,
            IAuthInterface authService)
        {
            MainUserControl = SelectNewTaskUserControl;
            AuthUserControl = new LoginUserControl();

            _customerDBService = customerDBService;
            _moistureSoilTestDBService = moistureSoilTestDBService;
            _rollingBoundarySoilTestDBService = rollingBoundarySoilTestDBService;
            _yieldLimitSoilTestDBService = yieldLimitSoilTestDBService;
            _testDBService = testDbService;
            _authInterface = authService;

            #region Create Commands
            SelectNewTaskCommand = new LambdaCommand(OnSelectNewTaskCommandExecuted, CanSelectNewTaskCommandExecute);
            SelectTypeTestCommand = new LambdaCommand(OnSelectTypeTestCommandExecuted, CanSelectTypeTestCommandExecute);
            ReturnToNewTaskPageCommand = new LambdaCommand(OnReturnToNewTaskPageCommandExecuted, CanReturnToNewTaskPageCommandExecute);
            SelectSoilTestCommand = new LambdaCommand(OnSelectSoilTestCommandExecuted, CanSelectSoilTestCommandExecute);
            CalculateMoistureSoilTestCommand = new LambdaCommand(OnCalculateMoistureSoilTestCommandExecuted, CanCalculateMoistureSoilTestCommandExecute);
            SaveMoistureSoilTestCommand = new LambdaCommand(OnSaveMoistureSoilTestCommandExecuted, CanSaveMoistureSoilTestCommandExecute);
            CalculateRollingBoundarySoilTestCommand = new LambdaCommand(OnCalculateRollingBoundarySoilTestCommandExecuted, CanCalculateRollingBoundarySoilTestCommandExecute);
            SaveRollingBoundarySoilTestCommand = new LambdaCommand(OnSaveRollingBoundarySoilTestCommandExecuted, CanSaveRollingBoundarySoilTestCommandExecute);
            OpenSelectCustomerCommand = new LambdaCommand(OnOpenSelectCustomerCommandExecuted, CanOpenSelectCustomerCommandExecute);
            LoadCustomerFromListCommand = new LambdaCommand(OnLoadCustomerFromListCommandExecuted, CanLoadCustomerFromListCommandExecute);
            LoadTestFromBDCommand = new LambdaCommand(OnLoadTestFromBDCommandExecuted, CanLoadTestFromBDCommandExecute);
            OpenFormForCustomerAddCommand = new LambdaCommand(OnOpenFormForCustomerAddCommandExecuted, CanOpenFormForCustomerAddCommandExecute);
            OpenFormForCustomerEditCommand = new LambdaCommand(OnOpenFormForCustomerEditCommandExecuted, CanOpenFormForCustomerEditCommandExecute);
            SaveEditCustomerInBDCommand = new LambdaCommand(OnSaveEditCustomerInBDCommandExecuted, CanSaveEditCustomerInBDCommandExecute);
            LoginUserCommand = new LambdaCommand(OnLoginUserCommandExecuted, CanLoginUserCommandExecute);
            #endregion
        }
    }
}
