using Project.Views.UserControls.CustomersUserControl;
using Project.Views.UserControls.LoadUserControl;
using Project.Views.UserControls.SelectUserControls;
using Project.Views.UserControls.TestUserControls.Soil;
using Project.Views.UserControls.TestUserControls.SandAndGravel;
using ProjectCommon.ViewModelBase;
using System.Windows.Controls;
using Project.Views.UserControls.TestUserControls.Sand;
using Project.Views.UserControls.TestUserControls.Geotextile;
using Project.Views.UserControls.TestUserControls.Gravel;

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
        private UserControl yieldLimitSoilTestUserControl;
        private UserControl densitySoilTestUserControl;

        private UserControl bulkDensitySandAndGravelTestUserControl;

        private UserControl moistureSandTestUserControl;
        private UserControl dustSandTestUserControl;
        private UserControl bulkDensitySandTestUserControl;

        private UserControl filtrationPlaneGeotextileTestUserControl;

        private UserControl weakGrainsGravelTestUserControl;
        private UserControl moistureGravelTestUserControl;
        private UserControl flakyGrainsGravelTestUserControl;
        private UserControl dustGravelTestUserControl;
        private UserControl crushedGrainsGravelTestUserControl;
        private UserControl crushabilityGravelTestUserControl;
        private UserControl clayInLumpsGravelTestUserControl;
        private UserControl bulkDensityGravelTestUserControl;

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
                    moistureSoilTestUserControl = new MoistureSoilTestUserControl();
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

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение предела текучести грунта.
        /// </summary>
        public UserControl YieldLimitSoilTestUserControl
        {
            get
            {
                if (yieldLimitSoilTestUserControl == null)
                {
                    yieldLimitSoilTestUserControl = new YieldLimitSoilTestUserControl();
                    yieldLimitSoilTestUserControl.DataContext = this;
                }

                return yieldLimitSoilTestUserControl;
            }

            set => yieldLimitSoilTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение плотности грунта.
        /// </summary>
        public UserControl DensitySoilTestUserControl
        {
            get
            {
                if (densitySoilTestUserControl == null)
                {
                    densitySoilTestUserControl = new DensitySoilTestUserControl();
                    densitySoilTestUserControl.DataContext = this;
                }

                return densitySoilTestUserControl;
            }

            set => densitySoilTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение насыпной плотности ПГС.
        /// </summary>
        public UserControl BulkDensitySandAndGravelTestUserControl
        {
            get
            {
                if (bulkDensitySandAndGravelTestUserControl == null)
                {
                    bulkDensitySandAndGravelTestUserControl = new BulkDensitySandAndGravelTestUserControl();
                    bulkDensitySandAndGravelTestUserControl.DataContext = this;
                }

                return bulkDensitySandAndGravelTestUserControl;
            }

            set => bulkDensitySandAndGravelTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение влажности песка.
        /// </summary>
        public UserControl MoistureSandTestUserControl
        {
            get
            {
                if (moistureSandTestUserControl == null)
                {
                    moistureSandTestUserControl = new MoistureSandTestUserControl();
                    moistureSandTestUserControl.DataContext = this;
                }

                return moistureSandTestUserControl;
            }

            set => moistureSandTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        public UserControl DustSandTestUserControl
        {
            get
            {
                if (dustSandTestUserControl == null)
                {
                    dustSandTestUserControl = new DustSandTestUserControl();
                    dustSandTestUserControl.DataContext = this;
                }

                return dustSandTestUserControl;
            }

            set => dustSandTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение насыпной плотности песка.
        /// </summary>
        public UserControl BulkDensitySandTestUserControl
        {
            get
            {
                if (bulkDensitySandTestUserControl == null)
                {
                    bulkDensitySandTestUserControl = new BulkDensitySandTestUserControl();
                    bulkDensitySandTestUserControl.DataContext = this;
                }

                return bulkDensitySandTestUserControl;
            }

            set => bulkDensitySandTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        public UserControl FiltrationPlaneGeotextileTestUserControl
        {
            get
            {
                if (filtrationPlaneGeotextileTestUserControl == null)
                {
                    filtrationPlaneGeotextileTestUserControl = new FiltrationPlaneGeotextileTestUserControl();
                    filtrationPlaneGeotextileTestUserControl.DataContext = this;
                }

                return filtrationPlaneGeotextileTestUserControl;
            }

            set => filtrationPlaneGeotextileTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение содержания зерен слабых пород.
        /// </summary>
        public UserControl WeakGrainsGravelTestUserControl
        {
            get
            {
                if (weakGrainsGravelTestUserControl == null)
                {
                    weakGrainsGravelTestUserControl = new WeakGrainsGravelTestUserControl();
                    weakGrainsGravelTestUserControl.DataContext = this;
                }

                return weakGrainsGravelTestUserControl;
            }

            set => weakGrainsGravelTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение влажности щебня.
        /// </summary>
        public UserControl MoistureGravelTestUserControl
        {
            get
            {
                if (moistureGravelTestUserControl == null)
                {
                    moistureGravelTestUserControl = new MoistureGravelTestUserControl();
                    moistureGravelTestUserControl.DataContext = this;
                }

                return moistureGravelTestUserControl;
            }

            set => moistureGravelTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        public UserControl FlakyGrainsGravelTestUserControl
        {
            get
            {
                if (flakyGrainsGravelTestUserControl == null)
                {
                    flakyGrainsGravelTestUserControl = new FlakyGrainsGravelTestUserControl();
                    flakyGrainsGravelTestUserControl.DataContext = this;
                }

                return flakyGrainsGravelTestUserControl;
            }

            set => flakyGrainsGravelTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        public UserControl DustGravelTestUserControl
        {
            get
            {
                if (dustGravelTestUserControl == null)
                {
                    dustGravelTestUserControl = new DustGravelTestUserControl();
                    dustGravelTestUserControl.DataContext = this;
                }

                return dustGravelTestUserControl;
            }

            set => dustGravelTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение содержания дробленых зерен в щебне из гравия.
        /// </summary>
        public UserControl CrushedGrainsGravelTestUserControl
        {
            get
            {
                if (crushedGrainsGravelTestUserControl == null)
                {
                    crushedGrainsGravelTestUserControl = new CrushedGrainsGravelTestUserControl();
                    crushedGrainsGravelTestUserControl.DataContext = this;
                }

                return crushedGrainsGravelTestUserControl;
            }

            set => crushedGrainsGravelTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение дробимости щебня.
        /// </summary>
        public UserControl CrushabilityGravelTestUserControl
        {
            get
            {
                if (crushabilityGravelTestUserControl == null)
                {
                    crushabilityGravelTestUserControl = new CrushabilityGravelTestUserControl();
                    crushabilityGravelTestUserControl.DataContext = this;
                }

                return crushabilityGravelTestUserControl;
            }

            set => crushabilityGravelTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение содержания глины в комках в щебне.
        /// </summary>
        public UserControl ClayInLumpsGravelTestUserControl
        {
            get
            {
                if (clayInLumpsGravelTestUserControl == null)
                {
                    clayInLumpsGravelTestUserControl = new ClayInLumpsGravelTestUserControl();
                    clayInLumpsGravelTestUserControl.DataContext = this;
                }

                return clayInLumpsGravelTestUserControl;
            }

            set => clayInLumpsGravelTestUserControl = value;
        }

        /// <summary>
        /// Элемент отвечающий за отображение теста на определение насыпной плотности щебня.
        /// </summary>
        public UserControl BulkDensityGravelTestUserControl
        {
            get
            {
                if (bulkDensityGravelTestUserControl == null)
                {
                    bulkDensityGravelTestUserControl = new BulkDensityGravelTestUserControl();
                    bulkDensityGravelTestUserControl.DataContext = this;
                }

                return bulkDensityGravelTestUserControl;
            }

            set => bulkDensityGravelTestUserControl = value;
        }


    }


}
