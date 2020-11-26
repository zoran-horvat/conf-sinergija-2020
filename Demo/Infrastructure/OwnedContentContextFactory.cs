using Demo.Models.Common;
using Demo.Models.Content;
using System;

namespace Demo.Infrastructure
{
    public class OwnedContentContextFactory : ISecureContextFactory<Product, UserRef>
    {
        private ISecureContext<Product> WrappedContext { get; }

        public OwnedContentContextFactory(ISecureContext<Product> wrappedContext)
        {
            this.WrappedContext = wrappedContext;
        }

        public ISecureContext<Product> Create(Func<UserRef> filter) =>
            new OwnedContentContext(this.WrappedContext, filter);
    }
}
