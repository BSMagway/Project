using Project.Models.Data.Base;
using Project.Models.Data.Tests.Soil;
using Project.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Project.Services.Implementation
{
    /// <summary>
    /// Класс сервиса для работы с базой данных
    /// </summary>
    internal class WorkWithBD : IWorkWithBD
    {
        #region Fields
        /// <summary>
        /// Клиент для запросов к базе данных
        /// </summary>
        static HttpClient httpClient = new HttpClient();
        #endregion

        #region Load List
        public async Task<ObservableCollection<LoadedListTest>> LoadAllTest(string adress)
        {
            using var response = await httpClient.GetAsync(adress);

            ObservableCollection<LoadedListTest> loadedListTests = new ObservableCollection<LoadedListTest>();

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {

            }
            else
            {
                loadedListTests = await response.Content.ReadFromJsonAsync<ObservableCollection<LoadedListTest>>();
            }

            return loadedListTests;
        }
        public async Task<ObservableCollection<Costumer>> LoadCostumersFromBD(string adress)
        {
            using var response = await httpClient.GetAsync(adress);

            ObservableCollection<Costumer> costumers = new ObservableCollection<Costumer>();    

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {

            }
            else
            {
                costumers = await response.Content.ReadFromJsonAsync<ObservableCollection<Costumer>>();
            }

            return costumers;
        }
        #endregion

        #region Moisture
        public async Task<MoistureSoilTest> SaveMoistureSoilTestInBD(string adress, MoistureSoilTest moistureSoilTest)
        {
            JsonSerializerOptions optionsCyr = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            JsonContent content = JsonContent.Create(moistureSoilTest, null, optionsCyr);

            using var response = await httpClient.PostAsync(adress, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {

                moistureSoilTest = await response.Content.ReadFromJsonAsync<MoistureSoilTest>();

            }



            return moistureSoilTest;
        }
        public async Task EditMoistureSoilTestInBD(string adress, MoistureSoilTest moistureSoilTest)
        {
            JsonSerializerOptions optionsCyr = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            JsonContent content = JsonContent.Create(moistureSoilTest, null, optionsCyr);

            using var response = await httpClient.PutAsync(adress, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {

            }
        }
        public async Task<MoistureSoilTest> GetMoistureSoilTestFromBD(string adress, Guid id)
        {
            MoistureSoilTest moistureSoilTest = new MoistureSoilTest();

            using var response = await httpClient.GetAsync(adress + $"?moistureSoilTestId={id}");

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                moistureSoilTest = await response.Content.ReadFromJsonAsync<MoistureSoilTest>();
            }

            return moistureSoilTest;
        }
        #endregion

        #region Costumer

        public async Task EditCostumerInBD(string adress, Costumer costumer)
        {
            JsonSerializerOptions optionsCyr = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            JsonContent content = JsonContent.Create(costumer, null, optionsCyr);

            using var response = await httpClient.PutAsync(adress, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {

            }
        }

        public async Task<Costumer> SaveCostumerInBD(string adress, Costumer costumer)
        {
            JsonSerializerOptions optionsCyr = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            JsonContent content = JsonContent.Create(costumer, null, optionsCyr);

            using var response = await httpClient.PostAsync(adress, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {

                costumer = await response.Content.ReadFromJsonAsync<Costumer>();

            }



            return costumer;
        }

        public async Task<Costumer> GetCostumerFromBD(string adress, Guid id)
        {
            Costumer costumer = new Costumer();

            using var response = await httpClient.GetAsync(adress + $"?costumerId={id}");

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                costumer = await response.Content.ReadFromJsonAsync<Costumer>();
            }

            return costumer;
        }

        #endregion

        #region Employee
        public async Task<Employee> LoginEmployee(string adress, Employee employee)
        {
            JsonSerializerOptions optionsCyr = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            JsonContent content = JsonContent.Create(employee, null, optionsCyr);

            using var response = await httpClient.PostAsync(adress, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {

                employee = await response.Content.ReadFromJsonAsync<Employee>();

            }



            return employee;
        }
        #endregion

    }
}
