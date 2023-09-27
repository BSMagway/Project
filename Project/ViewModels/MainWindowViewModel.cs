using Project.Views.UserControls.CustomersUserControl;
using Project.Views.UserControls.EmployeeUserControl;
using Project.Views.UserControls.LoadUserControl;
using Project.Views.UserControls.SelectUserControls;
using Project.Views.UserControls.TestUserControls.Soil;
using ProjectCommon.ViewModelBase;
using System.Windows.Controls;

namespace Project.ViewModels
{

    internal partial class MainWindowViewModel : ViewModel
    {
        private UserControl mainUserControl;
        private UserControl loginUserControl;

        private UserControl selectNewTaskUserControl;
        private UserControl selectTypeTestUserControl;
        private UserControl soilTestsUserControl;
        private UserControl sandTestsUserControl;
        private UserControl gravelTestsUserControl;
        private UserControl sandAndGravelTestsUserControl;
        private UserControl geotextileTestsUserControl;

        private UserControl loadTestsListUserControl;

        private UserControl customersSelectUserControl;
        private UserControl customersListUserControl;

        private UserControl moistureSoilTestUserControl;

        private UserControl employeeLoginFormUserControl;

        /// <summary>
        /// Основной User Control отвечающий за основную область приложения.
        /// </summary>
        public UserControl MainUserControl
        {
            get => mainUserControl;
            set => Set(ref mainUserControl, value);
        }

        /// <summary>
        /// Вспомогательный User Control отвечающий за область приложения для логина.
        /// </summary>
        public UserControl LoginUserControl
        {
            get => loginUserControl;
            set => Set(ref loginUserControl, value);
        }

        /// <summary>
        /// Элемент отвечающий за выбор новой задачи.
        /// </summary>
        public UserControl SelectNewTaskUserControl
        {
            get
            {
                if (selectNewTaskUserControl == null)
                {
                    selectNewTaskUserControl = new SelectNewTask();
                    selectNewTaskUserControl.DataContext = this;
                }

                return selectNewTaskUserControl;
            }

            set => selectNewTaskUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор материала испытания. 
        /// </summary>
        public UserControl SelectTypeTestUserControl
        {
            get
            {
                if (selectTypeTestUserControl == null)
                {
                    selectTypeTestUserControl = new SelectTypeTest();
                    selectTypeTestUserControl.DataContext = this;
                }

                return selectTypeTestUserControl;
            }

            set => selectTypeTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор вида испытания грунта.
        /// </summary>
        public UserControl SoilTestsUserControl
        {
            get
            {
                if (soilTestsUserControl == null)
                {
                    soilTestsUserControl = new SelectNewTestSoil();
                    soilTestsUserControl.DataContext = this;
                }

                return soilTestsUserControl;
            }

            set => soilTestsUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор вида испытания песка.
        /// </summary>
        public UserControl SandTestsUserControl
        {
            get
            {
                if (sandTestsUserControl == null)
                {
                    sandTestsUserControl = new SelectNewTestSand();
                    sandTestsUserControl.DataContext = this;
                }

                return sandTestsUserControl;
            }

            set => sandTestsUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор вида испытания щебня.
        /// </summary>
        public UserControl GravelTestsUserControl
        {
            get
            {
                if (gravelTestsUserControl == null)
                {
                    gravelTestsUserControl = new SelectNewTestGravel();
                    gravelTestsUserControl.DataContext = this;
                }

                return gravelTestsUserControl;
            }

            set => gravelTestsUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор вида испытания ПГС.
        /// </summary>
        public UserControl SandAndGravelTestsUserControl
        {
            get
            {
                if (sandAndGravelTestsUserControl == null)
                {
                    sandAndGravelTestsUserControl = new SelectNewTestSandAndGravel();
                    sandAndGravelTestsUserControl.DataContext = this;
                }

                return sandAndGravelTestsUserControl;
            }

            set => sandAndGravelTestsUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор вида испытания геотекстиля.
        /// </summary>
        public UserControl GeotextileTestsUserControl
        {
            get
            {
                if (geotextileTestsUserControl == null)
                {
                    geotextileTestsUserControl = new SelectNewTestGeotextile();
                    geotextileTestsUserControl.DataContext = this;
                }

                return geotextileTestsUserControl;
            }

            set => geotextileTestsUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за загрузку краткой версии тестов в виде списка.
        /// </summary>
        public UserControl LoadTestsListUserControl
        {
            get
            {
                if (loadTestsListUserControl == null)
                {
                    loadTestsListUserControl = new LoadUserControl();
                    loadTestsListUserControl.DataContext = this;
                }

                return loadTestsListUserControl;
            }

            set => loadTestsListUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор заказчика для добавления в тест.
        /// </summary>
        public UserControl CustomersSelectUserControl
        {
            get
            {
                if (customersSelectUserControl == null)
                {
                    customersSelectUserControl = new CustomersSelectUserControl();
                    customersSelectUserControl.DataContext = this;
                }

                return customersSelectUserControl;
            }

            set => customersSelectUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение списка заказчиков.
        /// </summary>
        public UserControl CustomersListUserControl
        {
            get
            {
                if (customersListUserControl == null)
                {
                    customersListUserControl = new CustomersListUserControl();
                    customersListUserControl.DataContext = this;
                }

                return customersListUserControl;
            }

            set => customersListUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение влажности грунта.
        /// </summary>
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

        /// <summary>
        /// Элемент отвечающий за логин форму сотрудников.
        /// </summary>
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
    }


}
