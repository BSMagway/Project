using Project.Interfaces.Services;
using ProjectCommon.Models;
using ProjectCommon.Models.Base;
using ProjectCommon.Models.Material.Geotextile;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Sand;
using ProjectCommon.Models.Material.SandAndGravel;
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
        /// Сервис для работы с базой данных тестов по опеределнию предела раскатываемости грунта.
        /// </summary>
        IWorkWithBDGeneric<RollingBoundarySoilTest> _rollingBoundarySoilTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию предела текучести грунта.
        /// </summary>
        IWorkWithBDGeneric<YieldLimitSoilTest> _yieldLimitSoilTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию плотности грунта.
        /// </summary>
        IWorkWithBDGeneric<DensitySoilTest> _densitySoilTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию содержания зерен слабых пород.
        /// </summary>
        IWorkWithBDGeneric<WeakGrainsGravelTest> _weakGrainsGravelTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию влажности щебня.
        /// </summary>
        IWorkWithBDGeneric<MoistureGravelTest> _moistureGravelTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию содержания зерен пластинчатой (лещадной) и игловатой формы.
        /// </summary>
        IWorkWithBDGeneric<FlakyGrainsGravelTest> _flakyGrainsGravelTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию содержания пылевидных и глинистых частиц в щебне.
        /// </summary>
        IWorkWithBDGeneric<DustGravelTest> _dustGravelTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию содержания дробленых зерен в щебне из гравия.
        /// </summary>
        IWorkWithBDGeneric<CrushedGrainsGravelTest> _crushedGrainsGravelTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию предела дробимости щебня.
        /// </summary>
        IWorkWithBDGeneric<CrushabilityGravelTest> _crushabilityGravelTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию содержания глины в комках в щебне.
        /// </summary>
        IWorkWithBDGeneric<ClayInLumpsGravelTest> _clayInLumpsGravelTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию насыпной плотности щебня.
        /// </summary>
        IWorkWithBDGeneric<BulkDensityGravelTest> _bulkDensityGravelTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию насыпной плотности ПГС.
        /// </summary>
        IWorkWithBDGeneric<BulkDensitySandAndGravelTest> _bulkDensitySandAndGravelTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию фильтрации в плоскости геотекстильного полотна.
        /// </summary>
        IWorkWithBDGeneric<FiltrationPlaneGeotextileTest> _filtrationPlaneGeotextileTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию влажности песка.
        /// </summary>
        IWorkWithBDGeneric<MoistureSandTest> _moistureSandTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию содержания пылевидных и глинистых частиц в песке.
        /// </summary>
        IWorkWithBDGeneric<DustSandTest> _dustSandTestDBService;

        /// <summary>
        /// Сервис для работы с базой данных тестов по опеределнию насыпной плотности песка.
        /// </summary>
        IWorkWithBDGeneric<BulkDensitySandTest> _bulkDensitySandTestDBService;


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
