using System.Linq.Expressions;
using Application.Contacts.Repositories;
using Domain.Common;
using Infrastructure.Utilities.Date;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Context;

namespace Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly BaseDbContext _context;
    private readonly DbSet<T> _entities;
    private IHttpContextAccessor _contextAccessor;

    public BaseRepository(BaseDbContext context, IHttpContextAccessor contextAccessor)
    {
        _context = context;
        _contextAccessor = contextAccessor;
        _entities = context.Set<T>();
    }

    public void Create(T entity)
    {
        entity.CreatedAt = CalculateDate.GetCurrentDateTime();
        entity.CreatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System";
        _entities.Add(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = CalculateDate.GetCurrentDateTime();
        entity.UpdatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System";
        _entities.Update(entity);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }

    public void SoftDelete(T entity)
    {
        Update(entity);
    }

    public T Get(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true)
    {
        IQueryable<T> query = _entities;

        if (!enableTracking)
        {
            query = query.AsNoTracking();
        }

        if (include is not null)
        {
            query = include(query);
        }

        return query.FirstOrDefault(predicate);
    }

    public List<T> GetAll(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true)
    {
        IQueryable<T> query = _entities;

        if (!enableTracking)
        {
            query = query.AsNoTracking();
        }

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (include is not null)
        {
            query = include(query);
        }

        return orderBy != null ? orderBy(query).ToList() : query.ToList();
    }
}