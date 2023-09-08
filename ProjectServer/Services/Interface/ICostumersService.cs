using ProjectServer.Entities;

namespace ProjectServer.Services.Interface
{
    public interface ICostumersService
    {
        public Costumer[] GetAll();

        public Costumer Get(Guid costumerId);

        public Costumer Add(Costumer costumer);

        public bool Update(Costumer costumer);

        public bool Remove(Guid costumerId);

    }
}
