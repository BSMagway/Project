using ProjectCommon.Models;

// CRUD = Manager, сменить название на *Manager
// UnitOfWork (https://metanit.com/sharp/mvc5/23.3.php)

namespace ProjectServer.Interfaces.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Customer[] GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Task<Customer> GetAsync(Guid customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer Add(Customer customer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool Update(Customer customer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool Remove(Guid customerId);
    }
}
