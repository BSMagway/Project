﻿using ProjectCommon.Models;
using ProjectCommon.Models.Base;
using ProjectCommon.ViewModelBase;
using System.Collections.ObjectModel;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        private ObservableCollection<Test> loadedListTests;

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        private Test testForLoading;

        /// <summary>
        /// Статус теста сохранен или нет в базе данных.
        /// </summary>
        private bool isSavedTest = true;

        /// <summary>
        /// Статус заказчика сохранен или нет в базе данных.
        /// </summary>
        private bool isSavedCustomer = true;

        /// <summary>
        /// Статус редактируется ли в данный момент тест.
        /// </summary>
        private bool isEditingTest = false;

        /// <summary>
        /// Сокращенный список всех тестов.
        /// </summary>
        public ObservableCollection<Test> LoadedListTests
        {
            get
            {
                if (loadedListTests == null)
                {
                    loadedListTests = new ObservableCollection<Test>();
                }

                return loadedListTests;
            }

            set => Set(ref loadedListTests, value);
        }

        /// <summary>
        /// Список всех заказчиков.
        /// </summary>
        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (customers == null)
                {
                    customers = new ObservableCollection<Customer>();
                }

                return customers;
            }
            set
            {
                Set(ref customers, value);
            }

        }

        /// <summary>
        /// Выбранный для загрузки или установки в тесте заказчик.
        /// </summary>
        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set => Set(ref selectedCustomer, value);
        }

        /// <summary>
        /// Выбранный для загрузки тест.
        /// </summary>
        public Test TestForLoading
        {
            get => testForLoading;
            set => Set(ref testForLoading, value);
        }
    }
}
