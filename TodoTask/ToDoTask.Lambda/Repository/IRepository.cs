namespace ToDoTask.Lambda.Repository
{
    public interface IRepository<TEntity>
    {

        #region Methods
        /// <summary>
        /// List all entities 
        /// </summary>
        /// <returns>Enumeration with all entities</returns>
        Task<ICollection<TEntity>> ListAsync();


        /// <summary>
        /// Insert a new entity in the repository in asyncronus way
        /// </summary>
        /// <param name="entity">entity to insert</param>
        /// <returns>task</returns>
        Task InsertAsync(TEntity entity);


        /// <summary>
        ///  remove entity from the repository in asyncronus way
        /// </summary>
        /// <param name="entity">Entidad to delete</param>
        /// <returns>task</returns>
        Task DeleteAsync<TEntity>(string id);

        /// <summary>
        /// list one entity that mach wiht the id in asyncronus way
        /// </summary>
        /// <param name="expression"> id for find</param>
        /// <returns>entity</returns>
        Task<TEntity> GetById(string Id);

        #endregion
    }
}
