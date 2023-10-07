using Project.Views.UserControls.AuthUserControl;
using ProjectCommon.ViewModelBase;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// Загрузка списка заказчиков из базы данных.
        /// </summary>
        /// <returns></returns>
        private async Task LoadCostumersFromBD()
        {
            try
            {
                Customers = await _customerDBService.GetAll(CUSTOMER_ADRESS, User.Jwt);
                if (isSelectingCustomer)
                {
                    MainUserControl = CustomersSelectUserControl;
                }
                else
                {
                    MainUserControl = CustomersListUserControl;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Метод для редактирования заказчика в базе данных.
        /// </summary>
        /// <returns></returns>
        private async Task EditCostumer()
        {
            try
            {
                await _customerDBService.Update(CUSTOMER_ADRESS, selectedCustomer, User.Jwt);
                Customers[Customers.IndexOf(Customers.First(x => x.Id == selectedCustomer.Id))] = selectedCustomer;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }

        /// <summary>
        /// Метод для добавления нового заказчика в базу данных.
        /// </summary>
        /// <returns></returns>
        private async Task SaveCostumer()
        {
            try
            {
                selectedCustomer = await _customerDBService.Add(CUSTOMER_ADRESS, selectedCustomer, User.Jwt);
                Customers.Add(selectedCustomer);
                isSavedCustomer = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }

        /// <summary>
        /// Загрузка короткого списка тестов из базы данных.
        /// </summary>
        /// <returns></returns>
        public async Task LoadAllTest()
        {
            try
            {
                var collection = await _testDBService.GetAll(LOAD_ALL_TEST_ADRESS, User.Jwt);
                LoadedListTests = collection;
                MainUserControl = LoadTestsListUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Загрузка теста по определению влажности грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadMoistureSoilTest()
        {
            try
            {
                var item = await _moistureSoilTestDBService.Get(MOISTURE_SOIL_TEST_ADRESS, TestForLoading.Id, User.Jwt);
                MoistureTest = item;
                MainUserControl = MoistureSoilTestUserControl;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Метод для авторизации пользователя.
        /// </summary>
        /// <returns></returns>
        public async Task LoginUser()
        {
            try
            {
                var item = await _authInterface.Login(LOGIN_ADRESS, LoginRequest);
                User = item;
                AuthUserControl = new LoggedUserControl();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
