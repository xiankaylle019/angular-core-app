using ClientAPI.Core;

namespace ClientAPI.DataAccessTier
{
    public abstract class DataRepositoryBase <TEntity> : DataRepositoryBase<TEntity, DataContext> where TEntity : class
    {
        
    }
}