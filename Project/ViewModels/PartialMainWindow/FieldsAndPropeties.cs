using ProjectCommon.Models;
using ProjectCommon.Models.Authentication;
using ProjectCommon.Models.Base;
using ProjectCommon.ViewModelBase;
using System.Collections.ObjectModel;
using NLog;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// Логирование в фаил.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private User user;
        private LoginRequest loginRequest;
        private RegisterRequest registerRequest;

        private ObservableCollection<Test> loadedListTests;

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        private Test testForLoading;

        private string errorMessage = string.Empty;

        /// <summary>
        /// Статус теста сохранен или нет в базе данных.
        /// </summary>
        private bool isSavedTest = true;

        /// <summary>
        /// Статус заказчика сохранен или нет в базе данных.
        /// </summary>
        private bool isSavedCustomer = true;

        /// <summary>
        /// Статус редактируется ли в данный момент тест.
        /// </summary>
        private bool isEditingTest = false;

        /// <summary>
        /// Статус выбирается ли в данный момент заказчик.
        /// </summary>
        private bool isSelectingCustomer = false;

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User
        {
            get
            {
                if (user == null)
                {
                    user = new User();
                }

                return user;
            }

            set => Set(ref user, value);
        }

        /// <summary>
        /// Модель для логина.
        /// </summary>
        public LoginRequest LoginRequest
        {
            get
            {
                if (loginRequest == null)
                {
                    loginRequest = new LoginRequest();
                }

                return loginRequest;
            }

            set => Set(ref loginRequest, value);
        }

        /// <summary>
        /// Модель для регистрации.
        /// </summary>
        public RegisterRequest RegisterRequest
        {
            get
            {
                if (registerRequest == null)
                {
                    registerRequest = new RegisterRequest();
                }

                return registerRequest;
            }

            set => Set(ref registerRequest, value);
        }

        /// <summary>
        /// Список всех тестов.
        /// </summary>
        public ObservableCollection<Test> LoadedListTests
        {
            get
            {
                if (loadedListTests == null)
                {
                    loadedListTests = new ObservableCollection<Test>();
                }

                return loadedListTests;
            }

            set => Set(ref loadedListTests, value);
        }

        /// <summary>
        /// Список всех заказчиков.
        /// </summary>
        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (customers == null)
                {
                    customers = new ObservableCollection<Customer>();
                }

                return customers;
            }
            set
            {
                Set(ref customers, value);
            }

        }

        /// <summary>
        /// Выбранный для загрузки или установки в тесте заказчик.
        /// </summary>
        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set => Set(ref selectedCustomer, value);
        }

        /// <summary>
        /// Выбранный для загрузки тест.
        /// </summary>
        public Test TestForLoading
        {
            get => testForLoading;
            set => Set(ref testForLoading, value);
        }

        /// <summary>
        /// Сообщение о ошибке.
        /// </summary>
        public string ErrorMessage
        {
            get => errorMessage;
            set => Set(ref errorMessage, value);
        }
    }
}
