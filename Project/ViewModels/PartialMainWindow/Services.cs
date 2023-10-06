using Project.Interfaces.Services;
using ProjectCommon.Models;
using ProjectCommon.Models.Base;
using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// Сервис для работы с базой данных заказчиков.
        /// </summary>
        IWorkWithBDGeneric<Customer> _customerDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по определению влажности грунта.
        /// </summary>
        IWorkWithBDGeneric<MoistureSoilTest> _moistureSoilTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных всех тестов с общей информацией о них.
        /// </summary>
        IWorkWithBDGeneric<Test> _testDBService;

        /// <summary>
        /// Сервис для работы с авторизацией пользователя.
        /// </summary>
        IAuthInterface _authInterface;


    }
}
