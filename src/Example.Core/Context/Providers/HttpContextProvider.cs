namespace Example.Core.Context.Providers
{
    using Extensions;
    using System.Web;

    public class HttpContextProvider : IContextProviderBase
    {
        private readonly IRequestContext _context;
        public HttpContextProvider(HttpRequest request)
        {
            _context = request.GetContext();
        }

        public IRequestContext ResolveContext()
        {
            return _context;
        }
    }
}
