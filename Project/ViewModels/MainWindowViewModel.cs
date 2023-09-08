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
using Project.ViewModels.TestViewModel.Soil;
using Microsoft.Extensions.DependencyInjection;
using Project.Models.Data.Base;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net;
using Azure.Identity;
using System.Net.Http.Json;

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
            LoadTest
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
        //private IServiceProvider serviceProvider;

        private ObservableCollection<Costumer> costumers;
        /// <summary>
        /// Http клиент для загрузки из БД 
        /// </summary>
        private HttpClient httpClient = new HttpClient();
        #endregion

        #region Properties

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
                }

                return loadUserControl;
            }

            set => loadUserControl = value;
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
            FramePage = new MoistureSoilTestUC();
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
        public MainWindowViewModel()
        {
            FramePage = SelectNewTaskPage;

            LoadCostumersFromBD();

            #region Create Commands
            SelectNewTaskCommand = new LambdaCommand(OnSelectNewTaskCommandExecuted, CanSelectNewTaskCommandExecute);
            SelectTypeTestCommand = new LambdaCommand(OnSelectTypeTestCommandExecuted, CanSelectTypeTestCommandExecute);
            ReturnToNewTaskPageCommand = new LambdaCommand(OnReturnToNewTaskPageCommandExecuted, CanReturnToNewTaskPageCommandExecute);
            SelectSoilTestCommand = new LambdaCommand(OnSelectSoilTestCommandExecuted, CanSelectSoilTestCommandExecute);
            #endregion
        }

        //public MainWindowViewModel(IServiceProvider serviceProvider) : this()
        //{
        //    this.serviceProvider = serviceProvider;
        //}
        #endregion

        #region Load Methods
        /// <summary>
        /// Загрузка списка заказчиков из БД
        /// </summary>
        /// <returns></returns>
        private async Task LoadCostumersFromBD()
        {
            using var response = await httpClient.GetAsync("https://localhost:7143/api/Costumers/all");

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                
            }
            else
            {
                Costumers = await response.Content.ReadFromJsonAsync<ObservableCollection<Costumer>>();
            }
        }


        #endregion
    }


}
