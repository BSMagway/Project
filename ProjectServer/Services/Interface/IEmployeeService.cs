using ProjectServer.Entities;

namespace ProjectServer.Services.Interface
{
    public interface IEmployeeService
    {

        public Employee Get(Employee employee);

        public Employee Add(Employee employee);

    }
}
