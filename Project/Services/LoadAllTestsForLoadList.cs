using Microsoft.Build.Tasks;
using Project.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    internal class LoadAllTestsForLoadList
    {
        static HttpClient httpClient = new HttpClient();
        ObservableCollection<LoadedListTest> LoadedListTests = new ObservableCollection<LoadedListTest>();

        public static async Task LoadAllTest()
        {
            using var response = await httpClient.GetAsync("https://localhost:7094/1");

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                // если запрос завершился успешно, получаем объект Person
                ObservableCollection<LoadedListTest> LoadedListTests = await response.Content.ReadFromJsonAsync<ObservableCollection<LoadedListTest>>();


            }
        }

    }
}
