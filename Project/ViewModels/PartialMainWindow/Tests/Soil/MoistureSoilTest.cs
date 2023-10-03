using ProjectCommon.Models.Material.Soil;
using ProjectCommon.ViewModelBase;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        #region Moisture Soil Test
        #region Fields
        /// <summary>
        /// Тест по определению важности грунта
        /// </summary>
        private MoistureSoilTest moistureTest;
        #endregion

        #region Properties
        /// <summary>
        /// Тест по определению важности грунта
        /// </summary>
        public MoistureSoilTest MoistureTest
        {
            get
            {
                if (moistureTest == null)
                {
                    moistureTest = new MoistureSoilTest();
                }

                return moistureTest;
            }
            set => Set(ref moistureTest, value);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Метод по добавлению нового теста в бд
        /// </summary>
        /// <returns></returns>
        public async Task SaveNewMoistureSoilTest()
        {
            await _moistureSoilTestDBService.Add(MOISTURE_SOIL_TEST_ADRESS, MoistureTest);
        }


        /// <summary>
        /// Метод дя редактирования теста в бд
        /// </summary>
        /// <returns></returns>
        public async Task EditMoistureSoilTest()
        {
            await _moistureSoilTestDBService.Update(MOISTURE_SOIL_TEST_ADRESS, MoistureTest);
        }
        #endregion

        #region Commands
        /// <summary>
        /// Команда для расчета влажности грунта
        /// </summary>
        public ICommand CalculateMoistureCommand { get; }
        private bool CanCalculateMoistureCommandExecute(object p) => true;
        private void OnCalculateMoistureCommandExecuted(object p)
        {
            MoistureTest.Calculate();
        }
        /// <summary>
        /// Команда для сохранения и редактирования тестов по определению влажности грунта
        /// </summary>
        public ICommand SaveMoistureSoilTestCommand { get; }
        private bool CanSaveMoistureSoilTestCommandExecute(object p) => true;
        private void OnSaveMoistureSoilTestCommandExecuted(object p)
        {
            if (isSavedTest)
            {
                EditMoistureSoilTest();
            }
            else
            {
                SaveNewMoistureSoilTest();
                isSavedTest = true;
            }
        }
        #endregion
        #endregion
    }
}
