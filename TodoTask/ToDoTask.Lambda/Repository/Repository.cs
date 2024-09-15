
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using ToDoTask.Lambda.Entity;

namespace ToDoTask.Lambda.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntitBase, new()
    {
        #region property

        private readonly DynamoDBContext _dynamoDBContext;

        #endregion property

        #region C'tor
        public Repository()
        {
            _dynamoDBContext = new DynamoDBContext(new AmazonDynamoDBClient());
        }

        #endregion


        #region Methods

        public async Task DeleteAsync(TEntity entity)
        {
            await _dynamoDBContext.DeleteAsync(entity.Id);
        }

        public async Task<TEntity> GetById(string Id)
        {
            var search = _dynamoDBContext.FromQueryAsync<TEntity>(new QueryOperationConfig
            {
                Filter = new QueryFilter("id", QueryOperator.Equal, Id)
            });
            var searchResponse = await search.GetRemainingAsync();
            return searchResponse.FirstOrDefault();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dynamoDBContext.SaveAsync(entity);
        }

        public async Task<ICollection<TEntity>> ListAsync()
        {
            var searc = _dynamoDBContext.ScanAsync<TEntity>([]);
            var result = await searc.GetRemainingAsync();
            return result;
        }

        #endregion
    }
}
