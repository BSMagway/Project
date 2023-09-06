using Project.Models.Data.Tests;
using Project.ViewModels.Base;
using Project.ViewModels.Comands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project.ViewModels.TestViewModel.Soil
{
    internal class MoistureSoilTestViewModel : ViewModel
    {
        private MoistureTest moistureTest;

        public MoistureTest MoistureTest
        {
            get => moistureTest;
            set => Set(ref moistureTest, value);
        }

        #region Commands
        public ICommand CalculateMoistureCommand { get; }
        private bool CanCalculateMoistureCommandExecute(object p) => true;
        private void OnCalculateMoistureCommandExecuted(object p)
        {
            moistureTest.CalculateMoistureSoil();
        }
        #endregion

        #region Constructors
        public MoistureSoilTestViewModel()
        {
            moistureTest = new MoistureTest();

            CalculateMoistureCommand = new LambdaCommand(OnCalculateMoistureCommandExecuted, CanCalculateMoistureCommandExecute);
        }
        #endregion
    }
}
