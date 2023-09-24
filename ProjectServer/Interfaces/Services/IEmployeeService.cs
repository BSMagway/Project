using ProjectCommon.Models;

namespace ProjectServer.Interfaces.Services
{
    public interface IEmployeeService
    {

        public Employee Get(Employee employee);

        public Employee Add(Employee employee);

    }
}
