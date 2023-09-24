using Microsoft.EntityFrameworkCore;
using ProjectServer.Data;
using ProjectServer.Interfaces.Services;
using ProjectCommon.Models;

namespace ProjectServer.Services
{
    /// <inheritdoc cref="ICustomerService"/>
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _appDb;

        public CustomerService(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public async Task<Customer> GetAsync(Guid CustomerId)
        {
            //return _appDb.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();

            // Повторить (https://linqsamples.com/)
            var model =  await _appDb.Customers.FirstOrDefaultAsync(x => x.Id == CustomerId);
            return model;
        }

        public Customer[] GetAll()
        {
            return _appDb.Customers.ToArray();
        }

        public Customer Add(Customer Customer)
        {
            Customer.Id = Guid.NewGuid();

            var entity = _appDb.Customers.Add(Customer);
            _appDb.SaveChanges();

            return entity.Entity;
        }

        public bool Remove(Guid CustomerId)
        {
            // x - anonymous type, правильно customer
            var model = _appDb.Customers
                .Where(customer => customer.Id == CustomerId)
                .FirstOrDefault();

            //var Customer1 = _appDb.Customers.Find(CustomerId);

            if (model == null)
            {
                return false;
            }

            _appDb.Customers.Remove(model);
            _appDb.SaveChanges();

            return true;
        }

        public bool Update(Customer Customer)
        {
            var dbCustomer = _appDb.Customers
                .Where(x => x.Id == Customer.Id)
                .FirstOrDefault();

            if (dbCustomer == null)
            {
                return false;
            }

            dbCustomer.Title = Customer.Title;
            dbCustomer.ContractNumber = Customer.ContractNumber;

            _appDb.SaveChanges();

            return true;
        }
    }
}
