using System;

namespace Demo.Infrastructure
{
    public interface ISecureContextFactory<TEntity, TFilter>
        where TEntity : class
        where TFilter : class
    {
        ISecureContext<TEntity> Create(Func<TFilter> filter);
    }
}
