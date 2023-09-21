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
using Project.Views.UserControls.EmployeeUserControl;

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
        /// Enum содержащий возможные материалы для проведения испытаний
        /// </summary>
        enum SelectMaterialTypeTestEnum
        {
            Soil,
            Sand,            
            Gravel,
            SandAndGravel,
            Geotextile
        }
        /// <summary>
        /// Enum содержащий виды испытаний
        /// </summary>
        enum SelectTypeTestEnum
        {
            Moister
        }

        #endregion

        #region Fields
        /// <summary>
        /// Адресная строка для загрузки всех тестов для отображения списком
        /// </summary>
        private const string LOAD_ALL_TEST_ADRESS = "https://localhost:7143/api/FullTestsList";
        /// <summary>
        /// Адресная строка для загрузки всех заказчиков для отображения списком
        /// </summary>
        private const string LOAD_COSTUMERS_ADRESS = "https://localhost:7143/api/Costumers/all";
        /// <summary>
        /// Адресная строка для работы с базой данных заказчиков
        /// </summary>
        private const string COSTUMER_ADRESS = "https://localhost:7143/api/Costumers";
        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению влажности грунта
        /// </summary>
        private const string MOISTURE_SOIL_TEST_ADRESS = "https://localhost:7143/api/MoistureSoilTest";
        /// <summary>
        /// Адресная строка для работы с сотрудниками
        /// </summary>
        private const string EMPLOYEE_ADRESS = "https://localhost:7143/api/Employee";
        /// <summary>
        /// Сервис для работы с базой данных
        /// </summary>
        IWorkWithBD workWithBDService;
        /// <summary>
        /// Сокращенный список всех тестов
        /// </summary>
        private ObservableCollection<LoadedListTest> loadedListTests;
        /// <summary>
        /// выбранный для загрузки тест
        /// </summary>
        private LoadedListTest testForLoading;
        /// <summary>
        /// Статус теста сохранен или нет в базе данных
        /// </summary>
        private bool saveTestStatus = true;
        /// <summary>
        /// Список всех заказчиков
        /// </summary>
        private ObservableCollection<Costumer> costumers;
        /// <summary>
        /// Выбранный для загрузки или установки в тесте заказчик
        /// </summary>
        private Costumer selectedCostumer;
        /// <summary>
        /// Статус заказчика сохранен или нет в базе данных
        /// </summary>
        private bool saveCostumerStatus = true;
        /// <summary>
        /// Сотрудник заполняющий результаты испытания
        /// </summary>
        private Employee employeeTest;
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

        public Employee EmployeeTest
        {
            get
            {
                if(employeeTest == null)
                {
                    employeeTest = new Employee();
                }

                return employeeTest;
            }
            set => Set(ref employeeTest, value);
        }
        #endregion

        #region UserControls

        /// <summary>
        /// Поле которое отображает основной выбранный элемент.
        /// </summary>
        private UserControl framePage;
        /// <summary>
        /// Поле которое отображает выбранный элемент в логин форме.
        /// </summary>
        private UserControl loginUserControl;
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
        /// <summary>
        /// Элемент отвечающий за загрузку краткой версии тестов в виде списка
        /// </summary>
        private UserControl loadUserControl;
        /// <summary>
        /// Элемент отвечающий за выбор заказчика для добавления в тест
        /// </summary>
        private UserControl costumersSelectUserControl;
        /// <summary>
        /// Элемент отвечающий за отображение списка заказчиков
        /// </summary>
        private UserControl costumersListUserControl;
        /// <summary>
        /// Элемент отвечающий за отображение теста на определение влажности грунта
        /// </summary>
        private UserControl moistureSoilTestUserControl;
        /// <summary>
        /// Элемент отвечающий за логин форму сотрудников
        /// </summary>
        private UserControl employeeLoginFormUserControl;
        public UserControl FramePage
        {
            get => framePage;
            set => Set(ref framePage, value);
        }
        public UserControl LoginUserControl
        {
            get =>loginUserControl;
            set => Set(ref loginUserControl, value);
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
        public UserControl EmployeeLoginFormUserControl
        {
            get
            {
                if (employeeLoginFormUserControl == null)
                {
                    employeeLoginFormUserControl = new EmployeeLoginFormUserControl();
                    employeeLoginFormUserControl.DataContext = this;
                }

                return employeeLoginFormUserControl;
            }

            set => employeeLoginFormUserControl = value;
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
        /// <summary>
        /// Команда отвечающая за загрузку теста из базы данных
        /// </summary>
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
        /// <summary>
        /// Команда отвечающая за добавление нового и редактирование существующего заказчика
        /// </summary>
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
        /// <summary>
        /// Команда отвечающая за открытие формы для редактирования или добавления заказчика
        /// </summary>
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

        public ICommand LoginEmployeeCommand { get; }
        private bool CanLoginEmployeeCommandExecute(object p) => true;
        private void OnLoginEmployeeCommandExecuted(object p)
        {
            LoginEmployee();
        }


        #endregion

        #region Constructors
        public MainWindowViewModel(IWorkWithBD workWithBDService)
        {
            FramePage = SelectNewTaskPage;
            LoginUserControl = EmployeeLoginFormUserControl;
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
            LoginEmployeeCommand = new LambdaCommand(OnLoginEmployeeCommandExecuted, CanLoginEmployeeCommandExecute);
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
        /// <summary>
        /// Загрузка короткого списка тестов из БД
        /// </summary>
        /// <returns></returns>
        private async Task LoadAllTest()
        {
            LoadedListTests = await workWithBDService.LoadAllTest(LOAD_ALL_TEST_ADRESS);
        }
        /// <summary>
        /// Загрузка теста по определению влажности грунта
        /// </summary>
        /// <returns></returns>
        private async Task LoadMoistureSoilTest()
        {
            MoistureTest = await workWithBDService.GetMoistureSoilTestFromBD(MOISTURE_SOIL_TEST_ADRESS, TestForLoading.TestId);
        }
        private async Task LoginEmployee()
        {
            EmployeeTest = await workWithBDService.LoginEmployee(EMPLOYEE_ADRESS, EmployeeTest);

            if (EmployeeTest.FirstNameEmployee == string.Empty && EmployeeTest.LastNameEmployee == string.Empty)
            {

            }
            else
            {
                LoginUserControl = new EmployeeUserControl();
            }

        }
        #endregion

        #region Save Methods
        /// <summary>
        /// Метод для редактирования заказчика
        /// </summary>
        /// <returns></returns>
        private async Task EditCostumer()
        {
            await workWithBDService.EditCostumerInBD(COSTUMER_ADRESS, selectedCostumer);
            Costumers[Costumers.IndexOf(Costumers.First(x => x.Id == selectedCostumer.Id))] = selectedCostumer;
        }
        /// <summary>
        /// Метод для добавления нового заказчика
        /// </summary>
        /// <returns></returns>
        private async Task SaveCostumer()
        {
            selectedCostumer = await workWithBDService.SaveCostumerInBD(COSTUMER_ADRESS, selectedCostumer);
            Costumers.Add(selectedCostumer);
        }

        #endregion

        #region Moisture Soil Test
        #region Fields
        /// <summary>
        /// Тест по определению важности грунта
        /// </summary>
        private MoistureSoilTest moistureTest;
        #endregion

        #region Properties
        /// <summary>
        /// Тест по определению важности грунта
        /// </summary>
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
        /// <summary>
        /// Метод по добавлению нового теста в бд
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewMoistureSoilTest()
        {
            workWithBDService.SaveMoistureSoilTestInBD(MOISTURE_SOIL_TEST_ADRESS, MoistureTest);
        }
        /// <summary>
        /// Метод дя редактирования теста в бд
        /// </summary>
        /// <returns></returns>
        public async Task EditMoistureSoilTest()
        {
            workWithBDService.EditMoistureSoilTestInBD(MOISTURE_SOIL_TEST_ADRESS, MoistureTest);
        }
        #endregion

        #region Commands
        /// <summary>
        /// Команда для расчета влажности грунта
        /// </summary>
        public ICommand CalculateMoistureCommand { get; }
        private bool CanCalculateMoistureCommandExecute(object p) => true;
        private void OnCalculateMoistureCommandExecuted(object p)
        {
            moistureTest.CalculateMoistureSoil();
        }
        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению влажности грунта
        /// </summary>
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
        /// <summary>
        /// Команда для открытия выбора заказчика для добавления в тест
        /// </summary>
        public ICommand OpenSelectCostumerCommand { get; }
        private bool CanOpenSelectCostumerCommandExecute(object p) => true;
        private void OnOpenSelectCostumerCommandExecuted(object p)
        {
            FramePage = CostumersSelectUserControl;            
        }
        /// <summary>
        /// Команда для добавления выбранного заказчика в тест
        /// </summary>
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
