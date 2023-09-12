using Project.Views.UserControls.SelectUsercontrols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Project.ViewModels.Base;
using System.Windows.Input;
using Project.ViewModels.Comands;
using Project.Views.UserControls.TestUserControls.Soil;
using Project.Views.UserControls.LoadUserControl;
using Microsoft.Extensions.DependencyInjection;
using Project.Models.Data.Base;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net;
using Azure.Identity;
using System.Net.Http.Json;
using Project.Views.Windows;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using Project.Models.Data.Tests.Soil;
using Project.Services.Interface;
using Project.Views.UserControls.CostumersUserControl;

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
        enum SelectTypeTestEnum
        {
            Soil,
            Sand,            
            Gravel,
            SandAndGravel,
            Geotextile
        }

        #endregion

        #region Fields
        private const string LOADALLTESTADRESS = "https://localhost:7143/api/FullTestsList";
        private const string LOADCOSTUMERSADRESS = "https://localhost:7143/api/Costumers/all";
        private const string SAVEMOISTURESOILTESTADRESS = "https://localhost:7143/api/MoistureSoilTest";

        IWorkWithBD workWithBDService;

        private ObservableCollection<LoadedListTest> loadedListTests;
        private ObservableCollection<Costumer> costumers;
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

        #region Commands

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
                    break;
                case (int)SelectNewTaskEnum.LoadTest:
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
                case (int)SelectTypeTestEnum.Soil:
                    FramePage = SoilTestsPage;
                    break;
                case (int)SelectTypeTestEnum.Sand:
                    FramePage = SandTestsPage;
                    break;
                case (int)SelectTypeTestEnum.Gravel:
                    FramePage = GravelTestsPage;
                    break;
                case (int)SelectTypeTestEnum.SandAndGravel:
                    FramePage = SandAndGravelTestsPage;
                    break;
                case (int)SelectTypeTestEnum.Geotextile:
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
            FramePage = MoistureSoilTestUserControl;
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

        #region Constructors
        public MainWindowViewModel(IWorkWithBD workWithBDService)
        {
            FramePage = SelectNewTaskPage;
            this.workWithBDService = workWithBDService; 

            LoadCostumersFromBD();
            LoadAllTest();

            #region Create Commands
            SelectNewTaskCommand = new LambdaCommand(OnSelectNewTaskCommandExecuted, CanSelectNewTaskCommandExecute);
            SelectTypeTestCommand = new LambdaCommand(OnSelectTypeTestCommandExecuted, CanSelectTypeTestCommandExecute);
            ReturnToNewTaskPageCommand = new LambdaCommand(OnReturnToNewTaskPageCommandExecuted, CanReturnToNewTaskPageCommandExecute);
            SelectSoilTestCommand = new LambdaCommand(OnSelectSoilTestCommandExecuted, CanSelectSoilTestCommandExecute);


            CalculateMoistureCommand = new LambdaCommand(OnCalculateMoistureCommandExecuted, CanCalculateMoistureCommandExecute);
            SaveTestCommand = new LambdaCommand(OnSaveTestCommandExecuted, CanSaveTestCommandExecute);
            OpenSelectCostumerCommand = new LambdaCommand(OnOpenSelectCostumerCommandExecuted, CanOpenSelectCostumerCommandExecute);
            LoadCostumerFromListCommand = new LambdaCommand(OnLoadCostumerFromListCommandExecuted, CanLoadCostumerFromListCommandExecute);
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
            Costumers = await workWithBDService.LoadCostumersFromBD(LOADCOSTUMERSADRESS);
        }
        public async Task LoadAllTest()
        {
            LoadedListTests = await workWithBDService.LoadAllTest(LOADALLTESTADRESS);
        }


        #endregion

        #region Moisture Soil Test
        #region Fields
        private MoistureSoilTest moistureTest;
        private Costumer selectedCostumer;
        private Window window;

        public MainWindowViewModel ViewModel { get; set; }
        #endregion

        #region Properties
        public Costumer SelectedCostumer
        {
            get => selectedCostumer;
            set => Set(ref selectedCostumer, value);
        }
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

        public async Task SaveTest()
        {
            workWithBDService.SaveMoistureSoilTestInBD(SAVEMOISTURESOILTESTADRESS, MoistureTest);
        }
        #endregion

        #region Commands
        public ICommand CalculateMoistureCommand { get; }
        private bool CanCalculateMoistureCommandExecute(object p) => true;
        private void OnCalculateMoistureCommandExecuted(object p)
        {
            moistureTest.CalculateMoistureSoil();
        }

        public ICommand SaveTestCommand { get; }
        private bool CanSaveTestCommandExecute(object p) => true;
        private void OnSaveTestCommandExecuted(object p)
        {
            SaveTest();
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
