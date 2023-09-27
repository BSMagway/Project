
using Project.Interfaces.Services;
using ProjectCommon.Models;
using ProjectCommon.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {

        #region 
        /// <summary>
        /// Сервис для работы с базой данных заказчиков
        /// </summary>


        /// <summary>
        /// Сокращенный список всех тестов
        /// </summary>
        private ObservableCollection<FullShortListTests> loadedListTests;
        /// <summary>
        /// выбранный для загрузки тест
        /// </summary>
        private FullShortListTests testForLoading;
        /// <summary>
        /// Статус теста сохранен или нет в базе данных
        /// </summary>
        private bool saveTestStatus = true;
        /// <summary>
        /// Список всех заказчиков
        /// </summary>
        private ObservableCollection<Customer> costumers;
        /// <summary>
        /// Выбранный для загрузки или установки в тесте заказчик
        /// </summary>
        private Customer selectedCostumer;
        /// <summary>
        /// Статус заказчика сохранен или нет в базе данных
        /// </summary>
        private bool saveCostumerStatus = true;
        #endregion

        #region Properties
        public ObservableCollection<FullShortListTests> LoadedListTests
        {
            get
            {
                if (loadedListTests == null)
                {
                    loadedListTests = new ObservableCollection<FullShortListTests>();
                }

                return loadedListTests;
            }

            set => Set(ref loadedListTests, value);
        }
        public ObservableCollection<Customer> Costumers
        {
            get
            {
                if (costumers == null)
                {
                    costumers = new ObservableCollection<Customer>();
                }

                return costumers;
            }
            set
            {
                Set(ref costumers, value);
            }

        }
        public Customer SelectedCostumer
        {
            get => selectedCostumer;
            set => Set(ref selectedCostumer, value);
        }
        public FullShortListTests TestForLoading
        {
            get => testForLoading;
            set => Set(ref testForLoading, value);
        }
        #endregion

    }
}
