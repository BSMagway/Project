using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;

namespace ProjectServer.Managers

{
    /// <inheritdoc cref="ICustomerManager"/>
    public class CustomerManager : ICustomerManager
    {
        private readonly AppDbContext _appDb;

        public CustomerManager(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public async Task<Customer> GetAsync(int customerId)
        {
            var model = await _appDb.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);
            return model;
        }

        public async Task<Customer[]> GetAllAsync()
        {
            var model = await _appDb.Customers.ToArrayAsync();
            return model;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {

            var entity = await _appDb.Customers.AddAsync(customer);
            _appDb.SaveChanges();

            return entity.Entity;
        }

        public async Task<bool> RemoveAsync(int customerId)
        {
            var model = await _appDb.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);

            if (model == null)
            {
                return false;
            }

            _appDb.Customers.Remove(model);
            _appDb.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            var dbCustomer = await _appDb.Customers
                .FirstOrDefaultAsync(x => x.Id == customer.Id);

            if (dbCustomer == null)
            {
                return false;
            }

            if (dbCustomer.Title != customer.Title)
            {
                dbCustomer.Title = customer.Title;
            }

            if (dbCustomer.ContractNumber != customer.ContractNumber)
            {
                dbCustomer.ContractNumber = customer.ContractNumber;
            }

            _appDb.SaveChanges();

            return true;
        }
    }
}
