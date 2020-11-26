using Demo.Models.Common;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace Demo.Infrastructure
{
    public class OwnedContentContext : ISecureContext<Product>
    {
        private ISecureContext<Product> Context { get; }
        private Lazy<UserRef> LazyOwner { get; }
        private string OwnerKey => this.LazyOwner.Value.Value;

        public OwnedContentContext(ISecureContext<Product> context, Func<UserRef> filterFactory)
        {
            this.Context = context;
            this.LazyOwner = new Lazy<UserRef>(filterFactory);
        }

        public IQueryable<TEntity> QueryAll<TEntity>() where TEntity : class =>
            this.Context.QueryAll<Product>()
                .Where(product => product.OwnerKey == this.OwnerKey)
                .OfType<TEntity>();

        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class =>
            this.Context.Find<Product>(keyValues) is Product product && product.OwnerKey == this.OwnerKey
                ? product as TEntity
                : null;

        public EntityEntry<Product> Add(Product obj)
        {
            if (obj.OwnerKey == this.OwnerKey)
            {
                return this.Context.Add(obj);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("GAAAAAAAAAAAAAAAAAAAAAA!!!");
                return null;
            }
        }

        public EntityEntry<Product> Remove(Product obj)
        {
            if (obj.OwnerKey == this.OwnerKey)
            {
                return this.Context.Remove(obj);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("GAAAAAAAAAAAAAAAAAAAAAA!!!");
                return null;
            }
        }

        public int SaveChanges() =>
            this.Context.SaveChanges();
    }
}
