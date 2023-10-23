using Project.Views.UserControls.CustomersUserControl;
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
        private UserControl authUserControl;

        private UserControl selectNewTaskUserControl;
        private UserControl selectTypeTestUserControl;
        private UserControl selectSoilTestsUserControl;
        private UserControl selectSandTestsUserControl;
        private UserControl selectGravelTestsUserControl;
        private UserControl selectSandAndGravelTestsUserControl;
        private UserControl selectGeotextileTestsUserControl;

        private UserControl loadTestsListUserControl;

        private UserControl customersSelectUserControl;
        private UserControl customersListUserControl;

        private UserControl moistureSoilTestUserControl;
        private UserControl rollingBoundarySoilTestUserControl;

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
        public UserControl AuthUserControl
        {
            get => authUserControl;
            set => Set(ref authUserControl, value);
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
        public UserControl SelectSoilTestsUserControl
        {
            get
            {
                if (selectSoilTestsUserControl == null)
                {
                    selectSoilTestsUserControl = new SelectNewTestSoil();
                    selectSoilTestsUserControl.DataContext = this;
                }

                return selectSoilTestsUserControl;
            }

            set => selectSoilTestsUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор вида испытания песка.
        /// </summary>
        public UserControl SelectSandTestsUserControl
        {
            get
            {
                if (selectSandTestsUserControl == null)
                {
                    selectSandTestsUserControl = new SelectNewTestSand();
                    selectSandTestsUserControl.DataContext = this;
                }

                return selectSandTestsUserControl;
            }

            set => selectSandTestsUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор вида испытания щебня.
        /// </summary>
        public UserControl SelectGravelTestsUserControl
        {
            get
            {
                if (selectGravelTestsUserControl == null)
                {
                    selectGravelTestsUserControl = new SelectNewTestGravel();
                    selectGravelTestsUserControl.DataContext = this;
                }

                return selectGravelTestsUserControl;
            }

            set => selectGravelTestsUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор вида испытания ПГС.
        /// </summary>
        public UserControl SelectSandAndGravelTestsUserControl
        {
            get
            {
                if (selectSandAndGravelTestsUserControl == null)
                {
                    selectSandAndGravelTestsUserControl = new SelectNewTestSandAndGravel();
                    selectSandAndGravelTestsUserControl.DataContext = this;
                }

                return selectSandAndGravelTestsUserControl;
            }

            set => selectSandAndGravelTestsUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за выбор вида испытания геотекстиля.
        /// </summary>
        public UserControl SelectGeotextileTestsUserControl
        {
            get
            {
                if (selectGeotextileTestsUserControl == null)
                {
                    selectGeotextileTestsUserControl = new SelectNewTestGeotextile();
                    selectGeotextileTestsUserControl.DataContext = this;
                }

                return selectGeotextileTestsUserControl;
            }

            set => selectGeotextileTestsUserControl = value;
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
        /// Элемент отвечающий за отображение теста на определение границы раскатываемости грунта.
        /// </summary>
        public UserControl RollingBoundarySoilTestUserControl
        {
            get
            {
                if (rollingBoundarySoilTestUserControl == null)
                {
                    rollingBoundarySoilTestUserControl = new RollingBoundarySoilTestUserControl();
                    rollingBoundarySoilTestUserControl.DataContext = this;
                }

                return rollingBoundarySoilTestUserControl;
            }

            set => rollingBoundarySoilTestUserControl = value;
        }
    }


}
