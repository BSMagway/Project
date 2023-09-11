using Project.Models.Data.Base;
using Project.Models.Data.Tests.Soil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Interface
{
    internal interface IWorkWithBD
    {

        public Task<ObservableCollection<LoadedListTest>> LoadAllTest(string adress);

        public Task<ObservableCollection<Costumer>> LoadCostumersFromBD(string adress);

        public Task<MoistureSoilTest> SaveMoistureSoilTestInBD(string adress, MoistureSoilTest moistureSoilTest);
    }
}
