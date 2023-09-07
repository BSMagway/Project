using Project.Models.Data.Base;
using Project.Models.Data.Tests;
using Project.ViewModels.Base;
using Project.ViewModels.Comands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.Http.Json;
using System.Text.Json;

namespace Project.ViewModels.TestViewModel.Soil
{
    internal class MoistureSoilTestViewModel : ViewModel
    {
        private MoistureTest moistureTest;
        private string contentSt;

        public MoistureTest MoistureTest
        {
            get => moistureTest;
            set => Set(ref moistureTest, value);
        }

        public string ContentSt
        {
            get => contentSt;
            set => Set(ref contentSt, value);
        }

        HttpClient httpClient = new HttpClient();

        public async Task SaveTest()
        {
            JsonContent content = JsonContent.Create(MoistureTest);
            ContentSt = JsonSerializer.Serialize(MoistureTest);
            using var response = await httpClient.PostAsync("https://localhost:7143/api/MoistureSoilTest", content);
            
            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                // если запрос завершился успешно, получаем объект Person


            }
        }

        #region Commands
        public ICommand CalculateMoistureCommand { get; }
        private bool CanCalculateMoistureCommandExecute(object p) => true;
        private void OnCalculateMoistureCommandExecuted(object p)
        {
            moistureTest.CalculateMoistureSoil();
        }

        public ICommand SaveTestCommand { get; }
        private bool CanSaveTestCommandExecute(object p) => true;
        private void OnSaveTestCommandExecuted(object p)
        {
            SaveTest();
        }
        #endregion

        #region Constructors
        public MoistureSoilTestViewModel()
        {
            moistureTest = new MoistureTest();

            CalculateMoistureCommand = new LambdaCommand(OnCalculateMoistureCommandExecuted, CanCalculateMoistureCommandExecute);
            SaveTestCommand = new LambdaCommand(OnSaveTestCommandExecuted, CanSaveTestCommandExecute);
        }
        #endregion
    }
}
