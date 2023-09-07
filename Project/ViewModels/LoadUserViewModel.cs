using Microsoft.Extensions.DependencyInjection;
using Project.Models.Data.Base;
using Project.Services;
using Project.ViewModels.Base;
using Project.ViewModels.Comands.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Project.Views.UserControls.LoadUserControl;

namespace Project.ViewModels
{
    internal class LoadUserViewModel : ViewModel
    {
        private readonly IServiceProvider _Services;
        private ObservableCollection<LoadedListTest> loadedListTests;
        public ObservableCollection<LoadedListTest> LoadedListTests
        {
            get
            {
                if (loadedListTests == null)
                {
                    loadedListTests = new ObservableCollection<LoadedListTest>();
                }

                return loadedListTests;
            }

            set => Set(ref loadedListTests, value);
        }

        HttpClient httpClient = new HttpClient();

        public async Task LoadAllTest()
        {
            using var response = await httpClient.GetAsync("https://localhost:7143/api/FullTestsList");

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                // если запрос завершился успешно, получаем объект Person
                LoadedListTests = await response.Content.ReadFromJsonAsync<ObservableCollection<LoadedListTest>>();


            }
        }

        public LoadUserViewModel()
        {
            
            ObservableCollection<LoadedListTest> LoadedListTests = new ObservableCollection<LoadedListTest>();

            LoadAllTest();


        }


    }
}
