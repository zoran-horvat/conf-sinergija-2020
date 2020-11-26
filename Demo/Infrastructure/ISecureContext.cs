using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Demo.Infrastructure
{
    public interface ISecureContext<TEntity> where TEntity : class
    {
        IQueryable<TResult> QueryAll<TResult>() where TResult : class;
        TResult Find<TResult>(params object[] keyValues) where TResult : class;
        EntityEntry<TEntity> Add(TEntity obj);
        EntityEntry<TEntity> Remove(TEntity obj);
        int SaveChanges();
    }
}
