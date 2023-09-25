using ProjectCommon.Models;

namespace ProjectServer.Interfaces.Services
{
    public interface IEmployeeManager
    {

        public Employee Get(Employee employee);

        public Employee Add(Employee employee);

    }
}
