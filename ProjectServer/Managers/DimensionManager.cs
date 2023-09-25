using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;

namespace ProjectServer.Managers
{
    /// <inheritdoc cref="IDimensionManager"/>
    public class DimensionManager : IDimensionManager
    {
        private readonly AppDbContext _appDb;

        public DimensionManager(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public async Task<Dimension> GetAsync(int dimensionId)
        {
            var model = await _appDb.Dimensions.FirstOrDefaultAsync(dimension => dimension.Id == dimensionId);
            return model;
        }

        public async Task<Dimension[]> GetAllAsync()
        {
            var model = await _appDb.Dimensions.ToArrayAsync();
            return model;
        }

        public async Task<Dimension> AddAsync(Dimension dimension)
        {

            var entity = await _appDb.Dimensions.AddAsync(dimension);
            _appDb.SaveChanges();

            return entity.Entity;
        }

        public async Task<bool> RemoveAsync(int dimensionId)
        {
            var model = await _appDb.Dimensions.FirstOrDefaultAsync(dimension => dimension.Id == dimensionId);

            if (model == null)
            {
                return false;
            }

            _appDb.Dimensions.Remove(model);
            _appDb.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateAsync(Dimension dimensionUpdate)
        {
            var dbDimension = await _appDb.Dimensions
                .FirstOrDefaultAsync(dimension => dimension.Id == dimensionUpdate.Id);

            if (dbDimension == null)
            {
                return false;
            }

            if (dbDimension.DimensionName != dimensionUpdate.DimensionName)
            {
                return false;
            }

            if (dbDimension.DimensionValue != dimensionUpdate.DimensionValue)
            {
                dbDimension.DimensionValue = dimensionUpdate.DimensionValue;
            }

            _appDb.SaveChanges();

            return true;
        }
    }
}
