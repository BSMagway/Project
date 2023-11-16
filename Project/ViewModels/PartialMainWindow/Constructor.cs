using Project.Interfaces.Services;
using Project.ViewModels.Commands;
using Project.Views.UserControls.AuthUserControl;
using ProjectCommon.Models;
using ProjectCommon.Models.Base;
using ProjectCommon.Models.Material.Geotextile;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Sand;
using ProjectCommon.Models.Material.SandAndGravel;
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
            IWorkWithBDGeneric<DensitySoilTest> densitySoilTestDBService,
            IWorkWithBDGeneric<WeakGrainsGravelTest> weakGrainsGravelTestDBService,
            IWorkWithBDGeneric<MoistureGravelTest> moistureGravelTestDBService,
            IWorkWithBDGeneric<FlakyGrainsGravelTest> flakyGrainsGravelTestDBService,
            IWorkWithBDGeneric<DustGravelTest> dustGravelTestDBService,
            IWorkWithBDGeneric<CrushedGrainsGravelTest> crushedGrainsGravelTestDBService,
            IWorkWithBDGeneric<CrushabilityGravelTest> crushabilityGravelTestDBService,
            IWorkWithBDGeneric<ClayInLumpsGravelTest> clayInLumpsGravelTestDBService,
            IWorkWithBDGeneric<BulkDensityGravelTest> bulkDensityGravelTestDBService,
            IWorkWithBDGeneric<BulkDensitySandAndGravelTest> bulkDensitySandAndGravelTestDBService,
            IWorkWithBDGeneric<FiltrationPlaneGeotextileTest> filtrationPlaneGeotextileTestDBService,
            IWorkWithBDGeneric<MoistureSandTest> moistureSandTestDBService,
            IWorkWithBDGeneric<DustSandTest> dustSandTestDBService,
            IWorkWithBDGeneric<BulkDensitySandTest> bulkDensitySandTestDBService,
            IWorkWithBDGeneric<Test> testDbService,
            IAuthInterface authService)
        {
            MainUserControl = SelectNewTaskUserControl;
            AuthUserControl = new LoginUserControl();

            _customerDBService = customerDBService;

            _moistureSoilTestDBService = moistureSoilTestDBService;
            _rollingBoundarySoilTestDBService = rollingBoundarySoilTestDBService;
            _yieldLimitSoilTestDBService = yieldLimitSoilTestDBService;
            _densitySoilTestDBService = densitySoilTestDBService;

            _weakGrainsGravelTestDBService = weakGrainsGravelTestDBService;
            _moistureGravelTestDBService = moistureGravelTestDBService;
            _flakyGrainsGravelTestDBService = flakyGrainsGravelTestDBService;
            _dustGravelTestDBService = dustGravelTestDBService;
            _crushedGrainsGravelTestDBService = crushedGrainsGravelTestDBService;
            _crushabilityGravelTestDBService = crushabilityGravelTestDBService;
            _clayInLumpsGravelTestDBService = clayInLumpsGravelTestDBService;
            _bulkDensityGravelTestDBService = bulkDensityGravelTestDBService;

            _bulkDensitySandAndGravelTestDBService = bulkDensitySandAndGravelTestDBService;

            _filtrationPlaneGeotextileTestDBService = filtrationPlaneGeotextileTestDBService;

            _moistureSandTestDBService = moistureSandTestDBService;
            _dustSandTestDBService = dustSandTestDBService;
            _bulkDensitySandTestDBService = bulkDensitySandTestDBService;

            _testDBService = testDbService;
            _authInterface = authService;

            #region Create Commands
            SelectNewTaskCommand = new LambdaCommand(OnSelectNewTaskCommandExecuted, CanSelectNewTaskCommandExecute);
            SelectTypeTestCommand = new LambdaCommand(OnSelectTypeTestCommandExecuted, CanSelectTypeTestCommandExecute);
            ReturnToNewTaskPageCommand = new LambdaCommand(OnReturnToNewTaskPageCommandExecuted, CanReturnToNewTaskPageCommandExecute);
            SelectSoilTestCommand = new LambdaCommand(OnSelectSoilTestCommandExecuted, CanSelectSoilTestCommandExecute);
            SelectSandAndGravelTestCommand = new LambdaCommand(OnSelectSandAndGravelTestCommandExecuted, CanSelectSandAndGravelTestCommandExecute);
            SelectGravelTestCommand = new LambdaCommand(OnSelectGravelTestCommandExecuted, CanSelectGravelTestCommandExecute);
            SelectSandTestCommand = new LambdaCommand(OnSelectSandTestCommandExecuted, CanSelectSandTestCommandExecute);
            SelectGeotextileTestCommand = new LambdaCommand(OnSelectGeotextileTestCommandExecuted, CanSelectGeotextileTestCommandExecute);

            CalculateMoistureSoilTestCommand = new LambdaCommand(OnCalculateMoistureSoilTestCommandExecuted, CanCalculateMoistureSoilTestCommandExecute);
            SaveMoistureSoilTestCommand = new LambdaCommand(OnSaveMoistureSoilTestCommandExecuted, CanSaveMoistureSoilTestCommandExecute);
            CalculateRollingBoundarySoilTestCommand = new LambdaCommand(OnCalculateRollingBoundarySoilTestCommandExecuted, CanCalculateRollingBoundarySoilTestCommandExecute);
            SaveRollingBoundarySoilTestCommand = new LambdaCommand(OnSaveRollingBoundarySoilTestCommandExecuted, CanSaveRollingBoundarySoilTestCommandExecute);
            CalculateYieldLimitSoilTestCommand = new LambdaCommand(OnCalculateYieldLimitSoilTestCommandExecuted, CanCalculateYieldLimitSoilTestCommandExecute);
            SaveYieldLimitSoilTestCommand = new LambdaCommand(OnSaveYieldLimitSoilTestCommandExecuted, CanSaveYieldLimitSoilTestCommandExecute);
            CalculateDensitySoilTestCommand = new LambdaCommand(OnCalculateDensitySoilTestCommandExecuted, CanCalculateDensitySoilTestCommandExecute);
            SaveDensitySoilTestCommand = new LambdaCommand(OnSaveDensitySoilTestCommandExecuted, CanSaveDensitySoilTestCommandExecute);

            CalculateWeakGrainsGravelTestCommand = new LambdaCommand(OnCalculateWeakGrainsGravelTestCommandExecuted, CanCalculateWeakGrainsGravelTestCommandExecute);
            SaveWeakGrainsGravelTestCommand = new LambdaCommand(OnSaveWeakGrainsGravelTestCommandExecuted, CanSaveWeakGrainsGravelTestCommandExecute);
            CalculateMoistureGravelTestCommand = new LambdaCommand(OnCalculateMoistureGravelTestCommandExecuted, CanCalculateMoistureGravelTestCommandExecute);
            SaveMoistureGravelTestCommand = new LambdaCommand(OnSaveMoistureGravelTestCommandExecuted, CanSaveMoistureGravelTestCommandExecute);
            CalculateFlakyGrainsGravelTestCommand = new LambdaCommand(OnCalculateFlakyGrainsGravelTestCommandExecuted, CanCalculateFlakyGrainsGravelTestCommandExecute);
            SaveFlakyGrainsGravelTestCommand = new LambdaCommand(OnSaveFlakyGrainsGravelTestCommandExecuted, CanSaveFlakyGrainsGravelTestCommandExecute);
            CalculateDustGravelTestCommand = new LambdaCommand(OnCalculateDustGravelTestCommandExecuted, CanCalculateDustGravelTestCommandExecute);
            SaveDustGravelTestCommand = new LambdaCommand(OnSaveDustGravelTestCommandExecuted, CanSaveDustGravelTestCommandExecute);
            CalculateCrushedGrainsGravelTestCommand = new LambdaCommand(OnCalculateCrushedGrainsGravelTestCommandExecuted, CanCalculateCrushedGrainsGravelTestCommandExecute);
            SaveCrushedGrainsGravelTestCommand = new LambdaCommand(OnSaveCrushedGrainsGravelTestCommandExecuted, CanSaveCrushedGrainsGravelTestCommandExecute);
            CalculateCrushabilityGravelTestCommand = new LambdaCommand(OnCalculateCrushabilityGravelTestCommandExecuted, CanCalculateCrushabilityGravelTestCommandExecute);
            SaveCrushabilityGravelTestCommand = new LambdaCommand(OnSaveCrushabilityGravelTestCommandExecuted, CanSaveCrushabilityGravelTestCommandExecute);
            CalculateClayInLumpsGravelTestCommand = new LambdaCommand(OnCalculateClayInLumpsGravelTestCommandExecuted, CanCalculateClayInLumpsGravelTestCommandExecute);
            SaveClayInLumpsGravelTestCommand = new LambdaCommand(OnSaveClayInLumpsGravelTestCommandExecuted, CanSaveClayInLumpsGravelTestCommandExecute);
            CalculateBulkDensityGravelTestCommand = new LambdaCommand(OnCalculateBulkDensityGravelTestCommandExecuted, CanCalculateBulkDensityGravelTestCommandExecute);
            SaveBulkDensityGravelTestCommand = new LambdaCommand(OnSaveBulkDensityGravelTestCommandExecuted, CanSaveBulkDensityGravelTestCommandExecute);

            CalculateBulkDensitySandAndGravelTestCommand = new LambdaCommand(OnCalculateBulkDensitySandAndGravelTestCommandExecuted, CanCalculateBulkDensitySandAndGravelTestCommandExecute);
            SaveBulkDensitySandAndGravelTestCommand = new LambdaCommand(OnSaveBulkDensitySandAndGravelTestCommandExecuted, CanSaveBulkDensitySandAndGravelTestCommandExecute);

            CalculateFiltrationPlaneGeotextileTestCommand = new LambdaCommand(OnCalculateFiltrationPlaneGeotextileTestCommandExecuted, CanCalculateFiltrationPlaneGeotextileTestCommandExecute);
            SaveFiltrationPlaneGeotextileTestCommand = new LambdaCommand(OnSaveFiltrationPlaneGeotextileTestCommandExecuted, CanSaveFiltrationPlaneGeotextileTestCommandExecute);

            CalculateMoistureSandTestCommand = new LambdaCommand(OnCalculateMoistureSandTestCommandExecuted, CanCalculateMoistureSandTestCommandExecute);
            SaveMoistureSandTestCommand = new LambdaCommand(OnSaveMoistureSandTestCommandExecuted, CanSaveMoistureSandTestCommandExecute);
            CalculateDustSandTestCommand = new LambdaCommand(OnCalculateDustSandTestCommandExecuted, CanCalculateDustSandTestCommandExecute);
            SaveDustSandTestCommand = new LambdaCommand(OnSaveDustSandTestCommandExecuted, CanSaveDustSandTestCommandExecute);
            CalculateBulkDensitySandTestCommand = new LambdaCommand(OnCalculateBulkDensitySandTestCommandExecuted, CanCalculateBulkDensitySandTestCommandExecute);
            SaveBulkDensitySandTestCommand = new LambdaCommand(OnSaveBulkDensitySandTestCommandExecuted, CanSaveBulkDensitySandTestCommandExecute);


            OpenSelectCustomerCommand = new LambdaCommand(OnOpenSelectCustomerCommandExecuted, CanOpenSelectCustomerCommandExecute);
            LoadCustomerFromListCommand = new LambdaCommand(OnLoadCustomerFromListCommandExecuted, CanLoadCustomerFromListCommandExecute);
            LoadTestFromBDCommand = new LambdaCommand(OnLoadTestFromBDCommandExecuted, CanLoadTestFromBDCommandExecute);
 
            OpenFormForCustomerAddCommand = new LambdaCommand(OnOpenFormForCustomerAddCommandExecuted, CanOpenFormForCustomerAddCommandExecute);
            OpenFormForCustomerEditCommand = new LambdaCommand(OnOpenFormForCustomerEditCommandExecuted, CanOpenFormForCustomerEditCommandExecute);
            SaveEditCustomerInBDCommand = new LambdaCommand(OnSaveEditCustomerInBDCommandExecuted, CanSaveEditCustomerInBDCommandExecute);

            LoginUserCommand = new LambdaCommand(OnLoginUserCommandExecuted, CanLoginUserCommandExecute);
            OpenRegisterUserFormCommand = new LambdaCommand(OnOpenRegisterUserFormCommandExecuted, CanOpenRegisterUserFormCommandExecute);
            ReturnToLoginUserFormCommand = new LambdaCommand(OnReturnToLoginUserFormCommandExecuted, CanReturnToLoginUserFormCommandExecute);
            RegisterNewUserFormCommand = new LambdaCommand(OnRegisterNewUserFormCommandExecuted, CanRegisterNewUserFormCommandExecute);
            ExitUserFormCommand = new LambdaCommand(OnExitUserFormCommandExecuted, CanExitUserFormCommandExecute);
            #endregion
        }
    }
}
