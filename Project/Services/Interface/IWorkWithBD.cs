using Project.Models.Data.Base;
using Project.Models.Data.Tests.Soil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Interface
{
    /// <summary>
    /// Интерфейс сервиса для работы с базой данных
    /// </summary>
    internal interface IWorkWithBD
    {
        #region Load List
        /// <summary>
        /// Загрузка короткого списка всех тестов
        /// </summary>
        /// <param name="adress">Адресная строка для загрузки короткого списка всех тестов</param>
        /// <returns>Коллекция краткой информации о всех тестах</returns>
        public Task<ObservableCollection<LoadedListTest>> LoadAllTest(string adress);
        /// <summary>
        /// Загрузка заказчиков
        /// </summary>
        /// <param name="adress">Адресная строка для загрузки заказчиков</param>
        /// <returns>Коллекция заказчиков</returns>
        public Task<ObservableCollection<Costumer>> LoadCostumersFromBD(string adress);
        #endregion

        #region Costumer
        /// <summary>
        /// Редактирование заказчика в базе данных
        /// </summary>
        /// <param name="adress">Адресная строка для доступа к заказчикам</param>
        /// <param name="costumer">Отредактированная версия заказчика для добавления в базу данных</param>
        /// <returns></returns>
        public Task EditCostumerInBD(string adress, Costumer costumer);
        /// <summary>
        /// Добавления нового заказчика в базу данных
        /// </summary>
        /// <param name="adress">Адресная строка для доступа к заказчикам</param>
        /// <param name="costumer">Новый заказчик для добавления в базу данных</param>
        /// <returns></returns>
        public Task<Costumer> SaveCostumerInBD(string adress, Costumer costumer);
        /// <summary>
        /// Получение заказчика из базы данных
        /// </summary>
        /// <param name="adress">Адресная строка для доступа к заказчикам</param>
        /// <param name="id">Id необходимого для загрузки заказчика</param>
        /// <returns></returns>
        public Task<Costumer> GetCostumerFromBD(string adress, Guid id);
        #endregion

        #region Moisture test
        /// <summary>
        /// Добавления нового теста по определению влажности грунта в базу данных
        /// </summary>
        /// <param name="adress">Адресная строка для доступа к тестам по определению влажности грунта</param>
        /// <param name="moistureSoilTest">Новый тест для добавления в базу данных</param>
        /// <returns></returns>
        public Task<MoistureSoilTest> SaveMoistureSoilTestInBD(string adress, MoistureSoilTest moistureSoilTest);
        /// <summary>
        /// Редактирование теста по определению влажности грунта в базе данных
        /// </summary>
        /// <param name="adress">Адресная строка для доступа к тестам по определению влажности грунта</param>
        /// <param name="moistureSoilTest">Тест для редактирования в базе данных</param>
        /// <returns></returns>
        public Task EditMoistureSoilTestInBD(string adress, MoistureSoilTest moistureSoilTest);
        /// <summary>
        /// Получение теста по определению влажности грунта из базы данных
        /// </summary>
        /// <param name="adress">Адресная строка для доступа к тестам по определению влажности грунта</param>
        /// <param name="id">Id для получения теста по определению влажности грунта из базы данных</param>
        /// <returns></returns>
        public Task<MoistureSoilTest> GetMoistureSoilTestFromBD(string adress, Guid id);
        #endregion

        #region Employee
        /// <summary>
        /// Логин сотрудника для заполнения теста
        /// </summary>
        /// <param name="adress"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Task<Employee> LoginEmployee(string adress, Employee employee);
        #endregion
    }
}
