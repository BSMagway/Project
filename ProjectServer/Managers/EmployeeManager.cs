using ProjectServer.Data;
using ProjectServer.Interfaces.Services;
using ProjectCommon.Models;

namespace ProjectServer.Services
{
    public class EmployeeManager : IEmployeeManager
    {
        #region Fields
        private readonly AppDbContext _appDb;
        #endregion

        #region Constructor
        public EmployeeManager(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        #endregion
        public Employee Get(Employee employee)
        {
            return _appDb.Employees.Where(x => x.Login == employee.Login && x.Password == employee.Password).FirstOrDefault();
        }

        public Employee Add(Employee employee)
        {
            var entity = _appDb.Employees.Add(employee);
            _appDb.SaveChanges();

            return entity.Entity;
        }
    }
}
