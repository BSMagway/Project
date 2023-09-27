using Project.Interfaces.Services;
using Project.ViewModels.Commands;
using ProjectCommon.Models;
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
        #region Constructors
        public MainWindowViewModel(IWorkWithBDGeneric<Customer> customerDBService,
            IWorkWithBDGeneric<MoistureSoilTest> moistureSoilTestDBService,
            IWorkWithBDGeneric<FullShortListTests> fullShortListTestDBService)
        {
            FramePage = SelectNewTaskPage;
            LoginUserControl = EmployeeLoginFormUserControl;

            _customerDBService = customerDBService;
            _fullShortListTestDBService = fullShortListTestDBService;
            _moistureSoilTestDBService = moistureSoilTestDBService;

            LoadCostumersFromBD();

            #region Create Commands
            SelectNewTaskCommand = new LambdaCommand(OnSelectNewTaskCommandExecuted, CanSelectNewTaskCommandExecute);
            SelectTypeTestCommand = new LambdaCommand(OnSelectTypeTestCommandExecuted, CanSelectTypeTestCommandExecute);
            ReturnToNewTaskPageCommand = new LambdaCommand(OnReturnToNewTaskPageCommandExecuted, CanReturnToNewTaskPageCommandExecute);
            SelectSoilTestCommand = new LambdaCommand(OnSelectSoilTestCommandExecuted, CanSelectSoilTestCommandExecute);
            CalculateMoistureCommand = new LambdaCommand(OnCalculateMoistureCommandExecuted, CanCalculateMoistureCommandExecute);
            SaveMoistureSoilTestCommand = new LambdaCommand(OnSaveMoistureSoilTestCommandExecuted, CanSaveMoistureSoilTestCommandExecute);
            OpenSelectCostumerCommand = new LambdaCommand(OnOpenSelectCostumerCommandExecuted, CanOpenSelectCostumerCommandExecute);
            LoadCostumerFromListCommand = new LambdaCommand(OnLoadCostumerFromListCommandExecuted, CanLoadCostumerFromListCommandExecute);
            LoadTestFromBDCommand = new LambdaCommand(OnLoadTestFromBDCommandExecuted, CanLoadTestFromBDCommandExecute);
            OpenFormForCostumerAddEditCommand = new LambdaCommand(OnOpenFormForCostumerAddEditCommandExecuted, CanOpenFormForCostumerAddEditCommandExecute);
            SaveEditCostumerInBDCommand = new LambdaCommand(OnSaveEditCostumerInBDCommandExecuted, CanOpenFormForCostumerAddEditCommandExecute);
            #endregion
        }
        #endregion

    }
}
