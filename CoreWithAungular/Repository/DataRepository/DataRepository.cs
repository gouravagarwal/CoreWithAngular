using CoreWithAungular.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWithAungular.Repository.DataRepository
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        #region Private variables and constructor

        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public DataRepository(ApplicationDbContext dbCcontext)
        {
            try
            {
                this.context = dbCcontext;
                this.dbSet = context.Set<T>();
            }
            catch (Exception ex) { throw ex; }

        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get all objects in the database
        /// </summary>
        /// <returns>all records in the database</returns>
        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return dbSet.AsQueryable();
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Get an object from database by Id
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>object in the database</returns>
        public virtual async Task<T> GetByIdAsync(long? id)
        {
            try
            {
                return await dbSet.FindAsync(id);
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Add the entity to the database
        /// </summary>
        /// <param name="entity">object to be added</param>
        public virtual async void InsertAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Update the entity in the database
        /// </summary>
        /// <param name="entity">Object to be updated</param>
        public virtual async void UpdateAsync(T entity)
        {
            try
            {
                dbSet.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Delete the object from the database
        /// </summary>
        /// <param name="id">Id to be deleted</param> 
        public virtual async void DeleteAsync(long? id)
        {
            try
            {
                dbSet.Remove(await dbSet.FindAsync(id));
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { throw ex; }

        }


        #endregion
    }
}
