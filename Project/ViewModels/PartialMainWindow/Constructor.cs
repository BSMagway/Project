using Project.Interfaces.Services;
using Project.ViewModels.Commands;
using ProjectCommon.Models;
using ProjectCommon.Models.Base;
using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel(IWorkWithBDGeneric<Customer> customerDBService,
            IWorkWithBDGeneric<MoistureSoilTest> moistureSoilTestDBService,
            IWorkWithBDGeneric<Test> testDbService)
        {
            MainUserControl = SelectNewTaskUserControl;
            LoginUserControl = EmployeeLoginFormUserControl;

            _customerDBService = customerDBService;
            _moistureSoilTestDBService = moistureSoilTestDBService;
            _testDBService = testDbService;

            LoadCostumersFromBD();

            #region Create Commands
            SelectNewTaskCommand = new LambdaCommand(OnSelectNewTaskCommandExecuted, CanSelectNewTaskCommandExecute);
            SelectTypeTestCommand = new LambdaCommand(OnSelectTypeTestCommandExecuted, CanSelectTypeTestCommandExecute);
            ReturnToNewTaskPageCommand = new LambdaCommand(OnReturnToNewTaskPageCommandExecuted, CanReturnToNewTaskPageCommandExecute);
            SelectSoilTestCommand = new LambdaCommand(OnSelectSoilTestCommandExecuted, CanSelectSoilTestCommandExecute);
            CalculateMoistureCommand = new LambdaCommand(OnCalculateMoistureCommandExecuted, CanCalculateMoistureCommandExecute);
            SaveMoistureSoilTestCommand = new LambdaCommand(OnSaveMoistureSoilTestCommandExecuted, CanSaveMoistureSoilTestCommandExecute);
            OpenSelectCustomerCommand = new LambdaCommand(OnOpenSelectCustomerCommandExecuted, CanOpenSelectCustomerCommandExecute);
            LoadCustomerFromListCommand = new LambdaCommand(OnLoadCustomerFromListCommandExecuted, CanLoadCustomerFromListCommandExecute);
            LoadTestFromBDCommand = new LambdaCommand(OnLoadTestFromBDCommandExecuted, CanLoadTestFromBDCommandExecute);
            OpenFormForCustomerAddCommand = new LambdaCommand(OnOpenFormForCustomerAddCommandExecuted, CanOpenFormForCustomerAddCommandExecute);
            OpenFormForCustomerEditCommand = new LambdaCommand(OnOpenFormForCustomerEditCommandExecuted, CanOpenFormForCustomerEditCommandExecute);
            SaveEditCustomerInBDCommand = new LambdaCommand(OnSaveEditCustomerInBDCommandExecuted, CanSaveEditCustomerInBDCommandExecute);
            #endregion
        }
    }
}
