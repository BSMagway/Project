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
    }
}
