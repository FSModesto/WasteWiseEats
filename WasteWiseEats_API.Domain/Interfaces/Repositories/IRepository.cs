using System.Linq.Expressions;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Recupera pelo ID (sem includes)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> Get(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Retorna uma entidade baseado em um filtro. Pode conter includes
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<TEntity> Find(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null);

        /// <summary>
        /// Retorna várias entidades baseado em um filtro. Pode conter includes.
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Query(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null);

        Task<PagedResult<TEntity>> QueryPaged(int page, int itemsPerPage, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null);

        /// <summary>
        /// Retorna um boleano indicando se a entidade existe baseado em um filtro.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<bool> Exists(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Retorna a quantidade de itens
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<int> Count(Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// Cria uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Create(TEntity entity);

        /// <summary>
        /// Cria várias entidades de uma vez
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task CreateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Atualiza uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Update(TEntity entity);

        /// <summary>
        /// Atualiza várias entidades de uma vez
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Atualiza ou cria uma entidade. IMPORTANTE: Não é feita uma verificação na base de dados, mas sim, considera as entidades carregadas localmente. 
        /// Use apenas em casos em que se deve fazer um update, mas não necessariamente a entidade já exista.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Upsert(TEntity entity);

        /// <summary>
        /// Deleta uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Delete(TEntity entity);

        /// <summary>
        /// Deleta várias entidades de uma vez
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task DeleteRange(IEnumerable<TEntity> entities);
    }
}
