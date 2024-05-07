using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using WasteWiseEats_API.Data.BaseContext;
using WasteWiseEats_API.Domain.Entities.BaseEntities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly WasteWiseEatsContext _context;

        protected DbSet<TEntity> Entity => _context.Set<TEntity>();

        public Repository(WasteWiseEatsContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Entity.ToListAsync();
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null)
        {
            IQueryable<TEntity> query = Entity;

            if (includes != null)
                query = includes(query) as IQueryable<TEntity>;

            return await query.FirstOrDefaultAsync(where);
        }

        public async Task<IEnumerable<TEntity>> Query(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null)
        {
            IQueryable<TEntity> query = Entity;

            if (includes != null)
                query = includes(query) as IQueryable<TEntity>;

            return await query.Where(where).ToListAsync();
        }

        public async Task<PagedResult<TEntity>> QueryPaged(int page, int itemsPerPage, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null)
        {
            IQueryable<TEntity> query = Entity;

            if (includes != null)
                query = includes(query) as IQueryable<TEntity>;

            List<TEntity> entities =
                await query.Where(where)
                           .OrderByDescending(entity => entity.CreatedAt)
                           .Skip((page - 1) * itemsPerPage)
                           .Take(itemsPerPage)
                           .ToListAsync();

            int count = await Count(where);

            return new PagedResult<TEntity>
            {
                ItensPerPage = itemsPerPage,
                Page = page,
                TotalItens = count,
                MaxPages = (int)Math.Ceiling((double)count / itemsPerPage),
                Results = entities
            };
        }

        public async Task<bool> Exists(Expression<Func<TEntity, bool>> where)
        {
            return await Entity.AnyAsync(where);
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> where = null)
        {
            return await Entity.CountAsync(where);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            Entity.Add(entity);

            await SaveChangesWhenNotHasTransaction();

            return entity;
        }

        public async Task CreateRange(IEnumerable<TEntity> entities)
        {
            await Entity.AddRangeAsync(entities);

            await SaveChangesWhenNotHasTransaction();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            EntityEntry<TEntity> entry = _context.Entry(entity);

            Entity.Attach(entity);

            entry.State = EntityState.Modified;

            await SaveChangesWhenNotHasTransaction();

            return entity;
        }

        public async Task<TEntity> Upsert(TEntity entity)
        {
            bool isNewEntity = !Entity.Local.Any(e => e == entity);

            return isNewEntity
                ? await Create(entity)
                : await Update(entity);
        }

        public async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                EntityEntry<TEntity> entry = _context.Entry(entity);

                Entity.Attach(entity);

                entry.State = EntityState.Modified;
            }

            await SaveChangesWhenNotHasTransaction();
        }

        public async Task Delete(TEntity entity)
        {
            _context.Remove(entity);

            await SaveChangesWhenNotHasTransaction();
        }

        public async Task DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);

            await SaveChangesWhenNotHasTransaction();
        }

        private async Task SaveChangesWhenNotHasTransaction()
        {
            if (!_context.HasTransaction())
                await _context.SaveChangesAsync(true, default);
        }
    }
}
