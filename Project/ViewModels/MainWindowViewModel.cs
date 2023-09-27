using ProjectCommon.Models;
using Project.ViewModels.Commands;
using Project.Views.UserControls.CostumersUserControl;
using Project.Views.UserControls.EmployeeUserControl;
using Project.Views.UserControls.LoadUserControl;
using Project.Views.UserControls.SelectUsercontrols;
using Project.Views.UserControls.TestUserControls.Soil;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectCommon.ViewModelBase;
using Project.Interfaces.Services;
using ProjectCommon.Enums;

namespace Project.ViewModels
{

    internal partial class MainWindowViewModel : ViewModel
    {


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

        /// <summary>
        /// 
        /// </summary>
        public UserControl FramePage
        {
            get => framePage;
            set => Set(ref framePage, value);
        }
        public UserControl LoginUserControl
        {
            get => loginUserControl;
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
                case (int)TaskType.NewTest:
                    FramePage = SelectTypeTestPage;
                    saveTestStatus = false;
                    break;
                case (int)TaskType.LoadTest:
                    LoadAllTest();
                    FramePage = LoadUserControl;
                    break;
                case (int)TaskType.CostumersList:
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
                case (int)MaterialType.Soil:
                    {
                        FramePage = SoilTestsPage;
                    }
                    break;
                case (int)MaterialType.Sand:
                    FramePage = SandTestsPage;
                    break;
                case (int)MaterialType.Gravel:
                    FramePage = GravelTestsPage;
                    break;
                case (int)MaterialType.SandAndGravel:
                    FramePage = SandAndGravelTestsPage;
                    break;
                case (int)MaterialType.Geotextile:
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
                case (int)ExperimentType.Moister:
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
            switch (TestForLoading.MaterialType)
            {
                case MaterialType.Soil:

                    switch (TestForLoading.ExperimentType)
                    {
                        case ExperimentType.Moister:
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

            if (key == "add")
            {
                SelectedCostumer = new Customer();
                saveCostumerStatus = false;
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


        #endregion



        #region Load Methods
        /// <summary>
        /// Загрузка списка заказчиков из БД
        /// </summary>
        /// <returns></returns>
        private async Task LoadCostumersFromBD()
        {
            Costumers = await _customerDBService.GetAll(LOAD_COSTUMERS_ADRESS);
        }
        /// <summary>
        /// Загрузка короткого списка тестов из БД
        /// </summary>
        /// <returns></returns>
        public async Task LoadAllTest()
        {
            var collection = await _fullShortListTestDBService.GetAll(LOAD_ALL_TEST_ADRESS); // List
            LoadedListTests = collection; // Что хочешь
        }
        /// <summary>
        /// Загрузка теста по определению влажности грунта
        /// </summary>
        /// <returns></returns>
        public async Task LoadMoistureSoilTest()
        {
            MoistureTest = await _moistureSoilTestDBService.Get(MOISTURE_SOIL_TEST_ADRESS, TestForLoading.TestId);
        }
        #endregion

        #region Save Methods
        /// <summary>
        /// Метод для редактирования заказчика
        /// </summary>
        /// <returns></returns>
        private async Task EditCostumer()
        {
            await _customerDBService.Update(COSTUMER_ADRESS, selectedCostumer);
            Costumers[Costumers.IndexOf(Costumers.First(x => x.Id == selectedCostumer.Id))] = selectedCostumer;
        }
        /// <summary>
        /// Метод для добавления нового заказчика
        /// </summary>
        /// <returns></returns>
        private async Task SaveCostumer()
        {
            selectedCostumer = await _customerDBService.Add(COSTUMER_ADRESS, selectedCostumer);
            Costumers.Add(selectedCostumer);
        }

        #endregion

        

    }


}
