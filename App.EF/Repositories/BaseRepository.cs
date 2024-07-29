using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.General;
using App.Core.Models.General;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace App.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<BaseGetDataWithPagnation<TResult>> GetAllAsync<TResult>(
            Expression<Func<T, TResult>> selection,
            List<Expression<Func<T, bool>>>? criteria = null,
            PaginationRequest? paginationRequest = null,
            List<Expression<Func<T, object>>>? includes = null)
        {
            Pagination pagination = new();
            paginationRequest = paginationRequest ?? new PaginationRequest();

            var result = pagination;

            IQueryable<T> query = _context.Set<T>().AsQueryable();

            if (criteria != null)
                foreach (var item in criteria)
                    query = query.Where(item);

            if (includes != null)
            {
                foreach (var item in includes)
                    query = query.Include(item).AsNoTracking();
            }

            result.totalItems = await query.CountAsync();

            var skip = GetSkipForPagination(paginationRequest, result);

            query = query.Skip((int)skip).Take((int)paginationRequest.pageSize);

            var fullData = await query.Select(selection).ToListAsync();

            return new BaseGetDataWithPagnation<TResult>()
            {
                Data = fullData,
                Pagination = result
            };
        }

        private static long GetSkipForPagination(PaginationRequest? paginationRequest, Pagination result)
        {
            paginationRequest.pageSize = paginationRequest.pageSize <= 0 || paginationRequest.pageSize > (int)EnumMaxLength.pageMaxSize ? (int)EnumMaxLength.pageMaxSize : paginationRequest.pageSize;

            result.countItemsInPage = paginationRequest.pageSize;

            var pageCount = (double)(result.totalItems / result.countItemsInPage);

            result.totalPages = (long)Math.Ceiling(pageCount);

            paginationRequest.page = paginationRequest.page > result.totalPages || paginationRequest.page <= 0 ? 1 : paginationRequest.page;

            var skip = (paginationRequest.page - 1) * paginationRequest.pageSize;


            result.selfPage = paginationRequest.page;

            result.firstPage = 1;

            result.nextPage = (result.selfPage < result.totalPages ? (result.selfPage + 1) : result.totalPages);

            result.prevPage = (result.selfPage > result.firstPage ? (result.selfPage - 1) : result.firstPage);

            result.lastPage = result.totalPages;
            return skip;
        }

        public T FirstOrDefault(Expression<Func<T, bool>>? criteria, List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var item in includes)
                    query = query.Include(item);

            return query.FirstOrDefault(criteria);
        }

        public T FirstOrDefault(List<Expression<Func<T, bool>>>? criteria, List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var item in includes)
                    query = query.Include(item);

            foreach (var item in criteria)
                query = query.Where(item);

            return query.FirstOrDefault();
        }

        public async Task<TResult> FirstOrDefaultAsync<TResult>(
            Expression<Func<T, bool>>? criteria = null,
            Expression<Func<T, TResult>>? select = null,
            List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var item in includes)
                    query = query.Include(item);



            return await query.Where(criteria).Select(select).FirstOrDefaultAsync();
        }

        public async Task<TResult> FirstOrDefaultAsync<TResult>(
            List<Expression<Func<T, bool>>>? criterias = null,
            Expression<Func<T, TResult>>? select = null,
            List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var item in includes)
                    query = query.Include(item);


            if (criterias != null)
                foreach (var item in criterias)
                    query = query.Where(item);

            return await query.Select(select).FirstOrDefaultAsync();
        }

        public async Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>>? criteria = null,
            List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var item in includes)
                    query = query.Include(item);


            return await query.FirstOrDefaultAsync(criteria);
        }

        public IEnumerable<T> FindAll(
            Expression<Func<T, bool>> criteria,
            List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take)
        {
            return _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<T> FindAll(
            Expression<Func<T, bool>> criteria,
            int? skip,
            int? take,
            Expression<Func<T, object>>? orderBy = null)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(
            Expression<Func<T, bool>> criteria,
            List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(
            Expression<Func<T, bool>> criteria,
            int? take,
            int? skip,
            Expression<Func<T, object>>? orderBy = null)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            return await query.ToListAsync();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AttachRange(entities);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().CountAsync(criteria);
        }

        public bool Any(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Any(criteria);
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}