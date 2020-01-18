using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingBasket.DAL.DBContext;
using ShoppingBasket.Repository.Common;
using System;
using System.Threading.Tasks;

namespace ShoppingBasket.Repository
{
    /// <summary>
    /// Base repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="ShoppingBasket.Repository.Common.IBaseRepository{TEntity}" />
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly DatabaseContext DbContext;

        /// <summary>
        /// The mapper
        /// </summary>
        protected readonly IMapper Mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public BaseRepository(DatabaseContext dbContext)
        {
            this.DbContext = dbContext;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The mapper.</param>
        public BaseRepository(DatabaseContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(TEntity entity)
        {
            EntityEntry entityEntry = DbContext.Entry(entity);
            if (entityEntry.State != EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                await DbContext.Set<TEntity>().AddAsync(entity);
            }

            return await DbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Guid id, TEntity entity)
        {
            EntityEntry entityEntry = DbContext.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                DbContext.Set<TEntity>().Attach(entity);
            }
            entityEntry.State = EntityState.Modified;

            return await DbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            EntityEntry entityEntry = DbContext.Entry(entity);
            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbContext.Set<TEntity>().Attach(entity);
                DbContext.Set<TEntity>().Remove(entity);
            }

            return await DbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }
    }
}
