using ProjectCommon.ViewModelBase;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// Адресная строка для загрузки всех тестов для отображения списком.
        /// </summary>
        private const string LOAD_ALL_TEST_ADRESS = "https://localhost:7143/api/Tests";

        /// <summary>
        /// Адресная строка для работы с базой данных заказчиков.
        /// </summary>
        private const string CUSTOMER_ADRESS = "https://localhost:7143/api/Customer";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению влажности грунта.
        /// </summary>
        private const string MOISTURE_SOIL_TEST_ADRESS = "https://localhost:7143/api/MoistureSoilTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению границы раскатываемости грунта.
        /// </summary>
        private const string ROLLING_BOUNDARY_SOIL_TEST_ADRESS = "https://localhost:7143/api/RollingBoundarySoilTest";

        /// <summary>
        /// Адресная строка для регистрации пользователя.
        /// </summary>
        private const string REGISTER_ADRESS = "https://localhost:7143/api/User/Register";

        /// <summary>
        /// Адресная строка для логина пользователя.
        /// </summary>
        private const string LOGIN_ADRESS = "https://localhost:7143/api/User/Login";
    }
}
