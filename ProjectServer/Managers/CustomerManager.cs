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
        private readonly ILogger<CustomerManager> _logger;

        public CustomerManager(AppDbContext appDb, ILogger<CustomerManager> logger)
        {
            _appDb = appDb;
            _logger = logger;
        }

        public async Task<Customer> GetAsync(int customerId)
        {
            try
            {
                var model = await _appDb.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Customer[]> GetAllAsync()
        {
            try
            {
                var model = await _appDb.Customers.ToArrayAsync();
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            try
            {
                var entity = await _appDb.Customers.AddAsync(customer);
                _appDb.SaveChanges();

                return entity.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int customerId)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
