using Project.Models.Data.Base;
using Project.Models.Data.Tests.Soil;
using Project.ViewModels.Base;
using Project.ViewModels.Comands;
using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Microsoft.Extensions.DependencyInjection;
using Project.Views.Windows;
using System.Windows;

namespace Project.ViewModels.TestViewModel.Soil
{
    internal class MoistureSoilTestViewModel : ViewModel
    {
        #region Fields
        private MoistureSoilTest moistureTest;
        private Costumer selectedCostumer;
        private Window window;
        //private IServiceProvider serviceProv;

        public MainWindowViewModel ViewModel { get; set; }
        public Costumer SelectedCostumer
        {
            get => selectedCostumer;
            set => Set(ref selectedCostumer, value);    
        }


        HttpClient httpClient = new HttpClient();
        //private string contentSt;
        #endregion

        #region Properties
        public MoistureSoilTest MoistureTest
        {
            get => moistureTest;
            set => Set(ref moistureTest, value);
        }

        //public string ContentSt
        //{
        //    get => contentSt;
        //    set => Set(ref contentSt, value);
        //}

        #endregion

        #region Methods

        public async Task SaveTest()
        {
            JsonSerializerOptions optionsCyr = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            JsonContent content = JsonContent.Create(MoistureTest, null, optionsCyr);
           
            //ContentSt = JsonSerializer.Serialize(MoistureTest);
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
        #endregion

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

        public ICommand OpenSelectCostumerCommand { get; }
        private bool CanOpenSelectCostumerCommandExecute(object p) => true;
        private void OnOpenSelectCostumerCommandExecuted(object p)
        {
            window = new LoadCostumerDialogWindow();
            window.DataContext = this;
            window.ShowDialog();
        }

        public ICommand LoadCostumerFromListCommand { get; }
        private bool CanLoadCostumerFromListCommandExecute(object p) => true;
        private void OnLoadCostumerFromListCommandExecuted(object p)
        {
            MoistureTest.CostumerTest = SelectedCostumer;
            window.DialogResult = true;
        }

        #endregion

        #region Constructors
        public MoistureSoilTestViewModel()
        {
            moistureTest = new MoistureSoilTest();

            CalculateMoistureCommand = new LambdaCommand(OnCalculateMoistureCommandExecuted, CanCalculateMoistureCommandExecute);
            SaveTestCommand = new LambdaCommand(OnSaveTestCommandExecuted, CanSaveTestCommandExecute);
            OpenSelectCostumerCommand = new LambdaCommand(OnOpenSelectCostumerCommandExecuted, CanOpenSelectCostumerCommandExecute);
            LoadCostumerFromListCommand = new LambdaCommand(OnLoadCostumerFromListCommandExecuted, CanLoadCostumerFromListCommandExecute);

            ViewModel = App.Current.MainWindow.DataContext as MainWindowViewModel;

        }

        //public MoistureSoilTestViewModel(IServiceProvider serviceProvider) : this()
        //{
        //    serviceProv = serviceProvider;
        //    ViewModel1 = serviceProv.GetRequiredService<MainWindowViewModel>();
        //}


        #endregion
    }
}
