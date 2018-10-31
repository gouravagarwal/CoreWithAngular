using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWithAungular.Repository.DataRepository
{
    public interface IDataRepository<T> where T : class
    {
        /// <summary>
        /// Get all objects in the database
        /// </summary>
        /// <returns>all records in the database</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get an object from database by Id
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>object in the database</returns>
        Task<T> GetByIdAsync(long? id);

        /// <summary>
        /// Add the entity to the database
        /// </summary>
        /// <param name="entity">object to be added</param>
        void InsertAsync(T entity);

        /// <summary>
        /// Update the entity in the database
        /// </summary>
        /// <param name="entity">Object to be updated</param>
        void UpdateAsync(T entity);

        /// <summary>
        /// Delete the object from the database
        /// </summary>
        /// <param name="id">Id to be deleted</param>
        void DeleteAsync(long? id);
        
    }
}
