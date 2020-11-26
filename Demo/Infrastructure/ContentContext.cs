using Demo.Models.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Demo.Infrastructure
{
    public class ContentContext : DbContext, ISecureContext<Product>
    {
        private DbSet<Product> Products => base.Set<Product>();

        public ContentContext(DbContextOptions<ContentContext> options) : base(options) { }

        public IQueryable<TEntity> QueryAll<TEntity>() where TEntity : class =>
            this.Products.OfType<TEntity>();

        public EntityEntry<Product> Add(Product obj) =>
            this.Products.Add(obj);

        public EntityEntry<Product> Remove(Product obj) =>
            this.Products.Remove(obj);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForProduct();
        }
    }
}
