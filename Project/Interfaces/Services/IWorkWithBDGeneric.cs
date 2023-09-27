using ProjectCommon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Interfaces.Services
{
    /// <summary>
    /// Интерфейс обобщенного типа для отправки запросов в базу данных.
    /// </summary>
    /// <typeparam name="T">Обобщенный тип с которым работают в базе данных.</typeparam>
    public interface IWorkWithBDGeneric<T>
    {
        /// <summary>
        /// Отправка запроса для получения всех объектов типа Т из базы данных.
        /// </summary>
        /// <param name="adress">Адрес по которому отправляется запрос.</param>
        /// <returns>Коллекция объектов типа Т.</returns>
        public Task<ObservableCollection<T>> GetAll(string adress);

        /// <summary>
        /// Отправка запроса для получения объекта из базы данных по id.
        /// </summary>
        /// <param name="adress">Адрес по которому отправляется запрос.</param>
        /// <param name="id">Id объекта который необходимо получить из базы данных.</param>
        /// <returns>Объект типа Т.</returns>
        public Task<T> Get(string adress, int id);

        /// <summary>
        /// Отправка запроса для добавления объекта в базу данных.
        /// </summary>
        /// <param name="adress">Адрес по которому отправляется запрос.</param>
        /// <param name="item">Объект для добавления в базу данных.</param>
        /// <returns>Объект типа Т.</returns>
        public Task<T> Add(string adress, T item);

        /// <summary>
        /// Отправка запроса для изменения объекта в базе данных.
        /// </summary>
        /// <param name="adress">Адрес по которому отправляется запрос.</param>
        /// <param name="item">Объект для изменения в базе данных.</param>
        /// <returns></returns>
        public Task Update(string adress, T item);

        /// <summary>
        /// Отправка запроса для удаления объекта в базе данных.
        /// </summary>
        /// <param name="adress">Адрес по которому отправляется запрос.</param>
        /// <param name="id">Id объекта который необходимо удалить из базы данных.</param>
        /// <returns></returns>
        public Task Delete(string adress, int id);
    }
}
