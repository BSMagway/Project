using ProjectServer.Entities;

namespace ProjectServer.Services.Interface
{
    public interface IMoistureSoilTestService
    {
        public MoistureSoilTest Get(Guid moistureSoilTestId);

        public MoistureSoilTest Add(MoistureSoilTest moistureSoilTest);

        public bool Update(MoistureSoilTest moistureSoilTest);

        public bool Remove(Guid moistureSoilTestId);
    }
}
