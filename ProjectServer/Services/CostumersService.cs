using ProjectServer.Data;
using ProjectServer.Entities;
using ProjectServer.Services.Interface;

namespace ProjectServer.Services
{
    public class CostumersService : ICostumersService
    {
        #region Fields
        private readonly AppDbContext _appDb;
        #endregion

        #region Constructor
        public CostumersService(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        #endregion
        public Costumer Get(Guid costumerId)
        {
            return _appDb.Costumers.Where(x => x.Id == costumerId).FirstOrDefault();
        }

        public Costumer[] GetAll()
        {
            return _appDb.Costumers.ToArray();
        }

        public Costumer Add(Costumer costumer)
        {
            costumer.Id = Guid.NewGuid();

            var entity = _appDb.Costumers.Add(costumer);
            _appDb.SaveChanges();

            return entity.Entity;
        }

        public bool Remove(Guid costumerId)
        {

            var costumer = _appDb.Costumers
                .Where(x => x.Id == costumerId)
                .FirstOrDefault();

            if (costumer == null)
            {
                return false;
            }

            _appDb.Costumers.Remove(costumer);
            _appDb.SaveChanges();

            return true;
        }

        public bool Update(Costumer costumer)
        {
            var dbCostumer = _appDb.Costumers
                .Where(x => x.Id == costumer.Id)
                .FirstOrDefault();

            if (dbCostumer == null)
            {
                return false;
            }

            dbCostumer.Title = costumer.Title;
            dbCostumer.ContractNumber = costumer.ContractNumber;

            _appDb.SaveChanges();

            return true;
        }
    }
}
