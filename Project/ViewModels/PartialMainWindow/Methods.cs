﻿using ProjectCommon.ViewModelBase;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        #region Customer methods
        /// <summary>
        /// Загрузка списка заказчиков из базы данных.
        /// </summary>
        /// <returns></returns>
        private async Task LoadCostumersFromBD()
        {
            Customers = await _customerDBService.GetAll(CUSTOMER_ADRESS);
        }

        /// <summary>
        /// Метод для редактирования заказчика в базе данных.
        /// </summary>
        /// <returns></returns>
        private async Task EditCostumer()
        {
            await _customerDBService.Update(CUSTOMER_ADRESS, selectedCustomer);
            Customers[Customers.IndexOf(Customers.First(x => x.Id == selectedCustomer.Id))] = selectedCustomer;
        }

        /// <summary>
        /// Метод для добавления нового заказчика в базу данных.
        /// </summary>
        /// <returns></returns>
        private async Task SaveCostumer()
        {
            selectedCustomer = await _customerDBService.Add(CUSTOMER_ADRESS, selectedCustomer);
            Customers.Add(selectedCustomer);
            saveCustomerStatus = true;
        }
        #endregion

        #region Tests methods

        /// <summary>
        /// Загрузка короткого списка тестов из базы данных.
        /// </summary>
        /// <returns></returns>
        public async Task LoadAllTest()
        {
            var collection = await _fullShortListTestDBService.GetAll(LOAD_ALL_TEST_ADRESS);
            LoadedListTests = collection;
        }

        /// <summary>
        /// Загрузка теста по определению влажности грунта из базы данных по id.
        /// </summary>
        /// <returns></returns>
        public async Task LoadMoistureSoilTest()
        {
            var item = await _moistureSoilTestDBService.Get(MOISTURE_SOIL_TEST_ADRESS, TestForLoading.TestId);
            MoistureTest = item;
        }
        #endregion
    }
}
