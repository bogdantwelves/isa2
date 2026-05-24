using System;
using Abc.Data.Common;
using Microsoft.EntityFrameworkCore;
namespace Abc.Infra;

public class EfBaseRepo<TContext, TEntity>(TContext c) : IRepo<TEntity>
    where TContext : DbContext
    where TEntity : BaseEntity
{
    protected readonly TContext db = c;
    public async Task<int> CountAsync(Query q) => await db.Set<TEntity>().CountAsync();
    public async Task<TEntity> CreateAsync(TEntity e)
    {
        await db.AddAsync(e);
        await db.SaveChangesAsync();
        return e;

    }
    public Task DeleteAsync(Guid id)
    {
        return deleteAsync(id);
    }
    private async Task deleteAsync(Guid id)
    {
        var entity = await GetAsync(id);
        if(entity is null) return;
        db.Remove(entity);
        await db.SaveChangesAsync();
    }
    public async Task<TEntity> GetAsync(Guid id)
    {
        return await db.Set< TEntity >().FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<IEnumerable<TEntity>> GetAsync(Query q) => await getAsync(q);
    private async Task<IEnumerable<TEntity>> getAsync(Query q)
    {
        var s = (q.Page - 1) * q.PageSize;
        var t = q.PageSize;
        var dir = q.Dir;
        var n = q.Sort;
        var r = (dir == "desc")
        ? db.Set<TEntity>().Skip(s).Take(t).OrderByDescending(x => x.ValidTo).AsNoTracking()
        : db.Set<TEntity>().Skip(s).Take(t).OrderBy(x => x.ValidTo).AsNoTracking();
        return await r.ToListAsync();
    }
    public async Task<TEntity> UpdateAsync(TEntity e)
    {
        db.Update(e);
        await db.SaveChangesAsync();
        return e;
    }
}

