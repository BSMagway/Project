using Project.Interfaces.Services;
using ProjectCommon.Models;
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
        /// Сервис для работы загрузки короткого списка протоколов.
        /// </summary>
        IWorkWithBDGeneric<FullShortListTests> _fullShortListTestDBService;
    }
}
