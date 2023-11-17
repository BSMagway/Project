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
        private readonly ILogger<DimensionManager> _logger;

        public DimensionManager(AppDbContext appDb, ILogger<DimensionManager> logger)
        {
            _appDb = appDb;
            _logger = logger;
        }

        public async Task<Dimension> GetAsync(int? dimensionId)
        {
            try
            {
                var model = await _appDb.Dimensions.FirstOrDefaultAsync(dimension => dimension.Id == dimensionId);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Dimension[]> GetAllAsync()
        {
            try
            {
                var model = await _appDb.Dimensions.ToArrayAsync();
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Dimension> AddAsync(Dimension dimension)
        {
            try
            {
                var entity = await _appDb.Dimensions.AddAsync(dimension);
                _appDb.SaveChanges();

                return entity.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync(int? dimensionId)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Dimension dimensionUpdate)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
