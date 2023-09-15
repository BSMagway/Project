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
        #region Load List
        public Task<ObservableCollection<LoadedListTest>> LoadAllTest(string adress);

        public Task<ObservableCollection<Costumer>> LoadCostumersFromBD(string adress);
        #endregion

        #region Costumer
        public Task EditCostumerInBD(string adress, Costumer costumer);

        public Task<Costumer> SaveCostumerInBD(string adress, Costumer costumer);

        public Task<Costumer> GetCostumerFromBD(string adress, Guid id);
        #endregion

        #region Moisture test
        public Task<MoistureSoilTest> SaveMoistureSoilTestInBD(string adress, MoistureSoilTest moistureSoilTest);

        public Task EditMoistureSoilTestInBD(string adress, MoistureSoilTest moistureSoilTest);

        public Task<MoistureSoilTest> GetMoistureSoilTestFromBD(string adress, Guid id);
        #endregion
    }
}
