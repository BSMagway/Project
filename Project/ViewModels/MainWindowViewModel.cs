using Project.Views.UserControls.SelectUsercontrols;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Project.ViewModels.Base;
using System.Windows.Input;
using Project.ViewModels.Comands;
using Project.Views.UserControls.TestUserControls.Soil;
using Project.Views.UserControls.LoadUserControl;
using Project.Models.Data.Base;
using System.Collections.ObjectModel;
using Project.Models.Data.Tests.Soil;
using Project.Services.Interface;
using Project.Views.UserControls.CostumersUserControl;
using System.Linq;

namespace Project.ViewModels
{

    internal class MainWindowViewModel : ViewModel
    {
        #region Enum

        /// <summary>
        /// Enum содержащий новые задачи.
        /// </summary>
        enum SelectNewTaskEnum
        {
            NewTest,
            LoadTest,
            CostumersList
        }

        /// <summary>
        /// Enum содержащий возможные материалы для роведения испытаний
        /// </summary>
        enum SelectMaterialTypeTestEnum
        {
            Soil,
            Sand,            
            Gravel,
            SandAndGravel,
            Geotextile
        }

        enum SelectTypeTestEnum
        {
            Moister
        }

        #endregion

        #region Fields
        private const string LOAD_ALL_TEST_ADRESS = "https://localhost:7143/api/FullTestsList";
        private const string LOAD_COSTUMERS_ADRESS = "https://localhost:7143/api/Costumers/all";
        private const string COSTUMER_ADRESS = "https://localhost:7143/api/Costumers";
        private const string SAVE_MOISTURE_SOIL_TEST_ADRESS = "https://localhost:7143/api/MoistureSoilTest";

        private const string LOAD_MOISTURE_SOIL_TEST_ADRESS = "https://localhost:7143/api/MoistureSoilTest";

        IWorkWithBD workWithBDService;

        private ObservableCollection<LoadedListTest> loadedListTests;
        private ObservableCollection<Costumer> costumers;
        private bool saveTestStatus = true;

        private Costumer selectedCostumer;
        private bool saveCostumerStatus = true;
        private LoadedListTest testForLoading;


        #endregion

        #region Properties
        public ObservableCollection<LoadedListTest> LoadedListTests
        {
            get
            {
                if (loadedListTests == null)
                {
                    loadedListTests = new ObservableCollection<LoadedListTest>();
                }

                return loadedListTests;
            }

            set => Set(ref loadedListTests, value);
        }
        public ObservableCollection<Costumer> Costumers
        {
            get
            {
                if(costumers == null) 
                {
                    costumers = new ObservableCollection<Costumer>();
                }

                return costumers;
            }
            set
            {
                Set(ref costumers, value);
            }
        
        }
        public Costumer SelectedCostumer
        {
            get => selectedCostumer;
            set => Set(ref selectedCostumer, value);
        }
        public LoadedListTest TestForLoading
        {
            get => testForLoading;
            set => Set(ref testForLoading, value);
        }
        #endregion

        #region UserControls

        /// <summary>
        /// Поле которое отображает выбранный элемент.
        /// </summary>
        private UserControl framePage;
        /// <summary>
        /// Элемент отвечающий за выбор новой задачи
        /// </summary>
        private UserControl selectNewTaskPage;
        /// <summary>
        /// Элемент отвечающий за выбор материала испытания. 
        /// </summary>
        private UserControl selectTypeTestPage;
        /// <summary>
        /// Элемент отвечающий за выбор вида испытания грунта.
        /// </summary>
        private UserControl soilTestsPage;
        /// <summary>
        /// Элемент отвечающий за выбор вида испытания песка.
        /// </summary>
        private UserControl sandTestsPage;
        /// <summary>
        /// Элемент отвечающий за выбор вида испытания щебня.
        /// </summary>
        private UserControl gravelTestsPage;
        /// <summary>
        /// Элемент отвечающий за выбор вида испытания ПГС.
        /// </summary>
        private UserControl sandAndGravelTestsPage;
        /// <summary>
        /// Элемент отвечающий за выбор вида испытания геотекстиля.
        /// </summary>
        private UserControl geotextileTestsPage;

        private UserControl loadUserControl;

        private UserControl costumersSelectUserControl;

        private UserControl costumersListUserControl;

        private UserControl moistureSoilTestUserControl;

        public UserControl FramePage
        {
            get => framePage;
            set => Set(ref framePage, value);
        }
        public UserControl SelectNewTaskPage
        {
            get
            {
                if (selectNewTaskPage == null)
                {
                    selectNewTaskPage = new SelectNewTask();
                    selectNewTaskPage.DataContext = this;
                }

                return selectNewTaskPage;
            }

            set => selectNewTaskPage = value;
        }
        public UserControl SelectTypeTestPage
        {
            get
            {
                if (selectTypeTestPage == null)
                {
                    selectTypeTestPage = new SelectTypeTest();
                    selectTypeTestPage.DataContext = this;
                }

                return selectTypeTestPage;
            }

            set => selectTypeTestPage = value;
        }
        public UserControl SoilTestsPage
        {
            get
            {
                if (soilTestsPage == null)
                {
                    soilTestsPage = new SelectNewTestSoil();
                    soilTestsPage.DataContext = this;
                }

                return soilTestsPage;
            }

            set => soilTestsPage = value;
        }
        public UserControl SandTestsPage
        {
            get
            {
                if (sandTestsPage == null)
                {
                    sandTestsPage = new SelectNewTestSand();
                    sandTestsPage.DataContext = this;
                }

                return sandTestsPage;
            }

            set => sandTestsPage = value;
        }
        public UserControl GravelTestsPage
        {
            get
            {
                if (gravelTestsPage == null)
                {
                    gravelTestsPage = new SelectNewTestGravel();
                    gravelTestsPage.DataContext = this;
                }

                return gravelTestsPage;
            }

            set => gravelTestsPage = value;
        }
        public UserControl SandAndGravelTestsPage
        {
            get
            {
                if (sandAndGravelTestsPage == null)
                {
                    sandAndGravelTestsPage = new SelectNewTestSandAndGravel();
                    sandAndGravelTestsPage.DataContext = this;
                }

                return sandAndGravelTestsPage;
            }

            set => sandAndGravelTestsPage = value;
        }
        public UserControl GeotextileTestsPage
        {
            get
            {
                if (geotextileTestsPage == null)
                {
                    geotextileTestsPage = new SelectNewTestGeotextile();
                    geotextileTestsPage.DataContext = this;
                }

                return geotextileTestsPage;
            }

            set => geotextileTestsPage = value;
        }
        public UserControl LoadUserControl
        {
            get
            {
                if (loadUserControl == null)
                {
                    loadUserControl = new LoadUserControl();
                    loadUserControl.DataContext = this;
                }

                return loadUserControl;
            }

            set => loadUserControl = value;
        }

        public UserControl CostumersSelectUserControl
        {
            get
            {
                if (costumersSelectUserControl == null)
                {
                    costumersSelectUserControl = new CostumersSelectUserControl();
                    costumersSelectUserControl.DataContext = this;
                }

                return costumersSelectUserControl;
            }

            set => costumersSelectUserControl = value;
        }

        public UserControl CostumersListUserControl
        {
            get
            {
                if (costumersListUserControl == null)
                {
                    costumersListUserControl = new CostumersListUserControl();
                    costumersListUserControl.DataContext = this;
                }

                return costumersListUserControl;
            }

            set => costumersListUserControl = value;
        }

        public UserControl MoistureSoilTestUserControl
        {
            get
            {
                if (moistureSoilTestUserControl == null)
                {
                    moistureSoilTestUserControl = new MoistureSoilTestUC();
                    moistureSoilTestUserControl.DataContext = this;
                }

                return moistureSoilTestUserControl;
            }

            set => moistureSoilTestUserControl = value;
        }

        #endregion

        #region Select Commands

        /// <summary>
        /// Команда для выбора новой задачи (создание нового теста, загрузка существующего теста и тд.).
        /// </summary>
        public ICommand SelectNewTaskCommand { get; }
        private bool CanSelectNewTaskCommandExecute(object p) => true;
        private void OnSelectNewTaskCommandExecuted(object p)
        {
            string task = p.ToString();

            switch (Convert.ToInt32(task))
            {
                case (int)SelectNewTaskEnum.NewTest:
                    FramePage = SelectTypeTestPage;
                    saveTestStatus = false;
                    break;
                case (int)SelectNewTaskEnum.LoadTest:
                    LoadAllTest();
                    FramePage = LoadUserControl;
                    break;
                case (int)SelectNewTaskEnum.CostumersList:
                    FramePage = CostumersListUserControl;
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
            string task = (string)p;

            switch (Convert.ToInt32(task))
            {
                case (int)SelectMaterialTypeTestEnum.Soil:
                    FramePage = SoilTestsPage;
                    break;
                case (int)SelectMaterialTypeTestEnum.Sand:
                    FramePage = SandTestsPage;
                    break;
                case (int)SelectMaterialTypeTestEnum.Gravel:
                    FramePage = GravelTestsPage;
                    break;
                case (int)SelectMaterialTypeTestEnum.SandAndGravel:
                    FramePage = SandAndGravelTestsPage;
                    break;
                case (int)SelectMaterialTypeTestEnum.Geotextile:
                    FramePage = GeotextileTestsPage;
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
            string task = (string)p;

            switch (Convert.ToInt32(task))
            {
                case (int)SelectTypeTestEnum.Moister:
                    FramePage = MoistureSoilTestUserControl;
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
            FramePage = SelectNewTaskPage;
        }

        #endregion

        #region Commands
        public ICommand LoadTestFromBDCommand { get; }
        private bool CanLoadTestFromBDCommandExecute(object p) => true;
        private void OnLoadTestFromBDCommandExecuted(object p)
        {
            switch(TestForLoading.MaterialTypeEnumNumber)
            {
                case (int)SelectMaterialTypeTestEnum.Soil:

                    switch(TestForLoading.TestTypeEnumNumber)
                    {
                        case (int)SelectTypeTestEnum.Moister:
                            LoadMoistureSoilTest();
                            FramePage = MoistureSoilTestUserControl;
                        break;
                    }

                break;
            }
        }

        public ICommand SaveEditCostumerInBDCommand { get; }
        private bool CanSaveEditCostumerInBDCommandExecute(object p) => true;
        private void OnSaveEditCostumerInBDCommandExecuted(object p)
        {
            if (saveCostumerStatus)
            {
                EditCostumer();
            } 
            else
            {
                SaveCostumer();
            }

            FramePage = CostumersListUserControl;
        }

        public ICommand OpenFormForCostumerAddEditCommand { get; }
        private bool CanOpenFormForCostumerAddEditCommandExecute(object p) => true;
        private void OnOpenFormForCostumerAddEditCommandExecuted(object p)
        {
            string key = string.Empty;

            if (p != null)
            {
                key = p.ToString();
            }

            FramePage = new FormForCostumerAddEditUserControl();
            FramePage.DataContext = this;
            
            if(key == "add")
            {
                SelectedCostumer = new Costumer();
                saveCostumerStatus = false;
            }

        }


        #endregion

        #region Constructors
        public MainWindowViewModel(IWorkWithBD workWithBDService)
        {
            FramePage = SelectNewTaskPage;
            this.workWithBDService = workWithBDService;
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

        #region Load Methods
        /// <summary>
        /// Загрузка списка заказчиков из БД
        /// </summary>
        /// <returns></returns>
        private async Task LoadCostumersFromBD()
        {
            Costumers = await workWithBDService.LoadCostumersFromBD(LOAD_COSTUMERS_ADRESS);
        }
        public async Task LoadAllTest()
        {
            LoadedListTests = await workWithBDService.LoadAllTest(LOAD_ALL_TEST_ADRESS);
        }
        public async Task LoadMoistureSoilTest()
        {
            MoistureTest = await workWithBDService.GetMoistureSoilTestFromBD(LOAD_MOISTURE_SOIL_TEST_ADRESS, TestForLoading.TestId);
        }


        #endregion

        #region Save Methods

        private async Task EditCostumer()
        {
            await workWithBDService.EditCostumerInBD(COSTUMER_ADRESS, selectedCostumer);
            Costumers[Costumers.IndexOf(Costumers.First(x => x.Id == selectedCostumer.Id))] = selectedCostumer;
        }

        private async Task SaveCostumer()
        {
            selectedCostumer = await workWithBDService.SaveCostumerInBD(COSTUMER_ADRESS, selectedCostumer);
            Costumers.Add(selectedCostumer);
        }

        #endregion

        #region Moisture Soil Test
        #region Fields
        private MoistureSoilTest moistureTest;
        #endregion

        #region Properties
        public MoistureSoilTest MoistureTest
        {
            get
            {
                if (moistureTest == null)
                {
                    moistureTest = new MoistureSoilTest();
                }

                return moistureTest;
            }
            set => Set(ref moistureTest, value);
        }

        #endregion

        #region Methods

        public async Task SaveNewMoistureSoilTest()
        {
            workWithBDService.SaveMoistureSoilTestInBD(SAVE_MOISTURE_SOIL_TEST_ADRESS, MoistureTest);
        }

        public async Task EditMoistureSoilTest()
        {
            workWithBDService.EditMoistureSoilTestInBD(SAVE_MOISTURE_SOIL_TEST_ADRESS, MoistureTest);
        }
        #endregion

        #region Commands
        public ICommand CalculateMoistureCommand { get; }
        private bool CanCalculateMoistureCommandExecute(object p) => true;
        private void OnCalculateMoistureCommandExecuted(object p)
        {
            moistureTest.CalculateMoistureSoil();
        }

        public ICommand SaveMoistureSoilTestCommand { get; }
        private bool CanSaveMoistureSoilTestCommandExecute(object p) => true;
        private void OnSaveMoistureSoilTestCommandExecuted(object p)
        {
            if (saveTestStatus)
            {
                EditMoistureSoilTest();
            } 
            else
            {
                SaveNewMoistureSoilTest();
                saveTestStatus = true;
            }
        }

        public ICommand OpenSelectCostumerCommand { get; }
        private bool CanOpenSelectCostumerCommandExecute(object p) => true;
        private void OnOpenSelectCostumerCommandExecuted(object p)
        {
            FramePage = CostumersSelectUserControl;            
        }

        public ICommand LoadCostumerFromListCommand { get; }
        private bool CanLoadCostumerFromListCommandExecute(object p) => true;
        private void OnLoadCostumerFromListCommandExecuted(object p)
        {
            MoistureTest.CostumerTest = SelectedCostumer;
            FramePage = MoistureSoilTestUserControl;
        }

        #endregion
        #endregion

    }


}
