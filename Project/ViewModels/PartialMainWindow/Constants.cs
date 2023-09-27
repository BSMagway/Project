using ProjectCommon.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {

        /// <summary>
        /// Адресная строка для загрузки всех тестов для отображения списком.
        /// </summary>
        private const string LOAD_ALL_TEST_ADRESS = "https://localhost:7143/api/FullTestsList";
        /// <summary>
        /// Адресная строка для загрузки всех заказчиков для отображения списком.
        /// </summary>
        private const string LOAD_COSTUMERS_ADRESS = "https://localhost:7143/api/Customer";
        /// <summary>
        /// Адресная строка для работы с базой данных заказчиков.
        /// </summary>
        private const string COSTUMER_ADRESS = "https://localhost:7143/api/Customer";

        private const string COSTUMER_ID_ADRESS = "https://localhost:7143/api/Customer";
        /// <summary>
        /// Адресная строка для работы с базой данных тестов по определению влажности грунта.
        /// </summary>
        private const string MOISTURE_SOIL_TEST_ADRESS = "https://localhost:7143/api/MoistureSoilTest";
        private const string MOISTURE_SOIL_TEST_ID_ADRESS = "https://localhost:7143/api/MoistureSoilTest";
    }
}
