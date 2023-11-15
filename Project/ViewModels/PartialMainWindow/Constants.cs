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
        /// Адресная строка для работы с базой данных тестов по определению предела текучести грунта.
        /// </summary>
        private const string YIELD_LIMIT_SOIL_TEST_ADRESS = "https://localhost:7143/api/YieldLimitSoilTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению плотности грунта.
        /// </summary>
        private const string DENSITY_SOIL_TEST_ADRESS = "https://localhost:7143/api/DensitySoilTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению содержания зерен слабых пород.
        /// </summary>
        private const string WEAK_GRAINS_GRAVEL_TEST_ADRESS = "https://localhost:7143/api/WeakGrainsGravelTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению влажности щебня.
        /// </summary>
        private const string MOISTURE_GRAVEL_TEST_ADRESS = "https://localhost:7143/api/MoistureGravelTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        private const string FLAKY_GRAINS_GRAVEL_TEST_ADRESS = "https://localhost:7143/api/FlakyGrainsGravelTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению пылевидных и глинистых частиц в щебне.
        /// </summary>
        private const string DUST_GRAVEL_TEST_ADRESS = "https://localhost:7143/api/DustGravelTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению дробленых зерен в щебне из гравия.
        /// </summary>
        private const string CRUSHED_GRAINS_GRAVEL_TEST_ADRESS = "https://localhost:7143/api/CrushedGrainsGravelTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению предела дробимости щебня.
        /// </summary>
        private const string CRUSHABILITY_GRAVEL_TEST_ADRESS = "https://localhost:7143/api/CrushabilityGravelTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению содержания глины в комках в щебне.
        /// </summary>
        private const string CLAY_IN_LUMPS_GRAVEL_TEST_ADRESS = "https://localhost:7143/api/ClayInLumpsGravelTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению насыпной плотности щебня.
        /// </summary>
        private const string BULK_DENSITY_GRAVEL_TEST_ADRESS = "https://localhost:7143/api/BulkDensityGravelTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению насыпной плотности ПГС.
        /// </summary>
        private const string BULK_DENSITY_SAND_AND_GRAVEL_TEST_ADRESS = "https://localhost:7143/api/BulkDensitySandAndGravelTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        private const string FILTRATION_PLANE_GEOTEXTILE_TEST_ADRESS = "https://localhost:7143/api/FiltrationPlaneGeotextileTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению влажности песка.
        /// </summary>
        private const string MOISTURE_SAND_TEST_ADRESS = "https://localhost:7143/api/MoistureSandTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        private const string DUST_SAND_TEST_ADRESS = "https://localhost:7143/api/DustSandTest";

        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению насыпной плотности песка.
        /// </summary>
        private const string BULK_DENSITY_SAND_TEST_ADRESS = "https://localhost:7143/api/BulkDensitySandTest";

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
