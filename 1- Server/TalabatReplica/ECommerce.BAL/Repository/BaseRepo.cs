using ECommerce.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.BAL.Repository
{
    public class BaseRepo<T> : IAsyncRepository<T> where T : class
    {
        #region Injecting DbContext
        private readonly ApplicationDbContext context;

        public BaseRepo( ApplicationDbContext context )
        {
            this.context = context;
        }
        #endregion

        #region public methods
        public async Task Add( T entity )
        {
            await context.AddAsync( entity );
            await context.SaveChangesAsync( );
        }
        public async Task<int> CountAll( ) => await context.Set<T>( ).CountAsync( );
        public async Task<int> CountWhere( Expression<Func<T , bool>> predicate ) => await context.Set<T>( ).CountAsync( predicate );
        public async Task<T> FirstOrDefault( Expression<Func<T , bool>> where ) => await context.Set<T>( ).FirstOrDefaultAsync( where );
        public async Task<IEnumerable<T>> GetAll( ) => await context.Set<T>( ).ToListAsync( );
        public async Task<T> GetById( int id ) => await context.Set<T>( ).FindAsync( id );
        public async Task<IEnumerable<T>> GetWhere( Expression<Func<T , bool>> predicate , params Expression<Func<T , object>>[ ] includeProperties )
        {
            var query = context.Set<T>( ).Where( predicate );
            var entities = includeProperties.Aggregate( query , ( current , includeProperty ) =>
                current.Include( includeProperty ) );
            return await entities.ToListAsync( );
        }
        public async Task Remove( T entity )
        {
            context.Set<T>( ).Remove( entity );
            await context.SaveChangesAsync( );
        }
        public async Task Update( T entity )
        {
            // In case AsNoTracking is used
            context.Entry( entity ).State = EntityState.Modified;
            await context.SaveChangesAsync( );
        }
        #endregion
    }
}
