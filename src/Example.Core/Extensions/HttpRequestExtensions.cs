namespace Example.Core.Extensions
{
    using Context;
    using System.Web;

    public static class HttpRequestExtensions
    {
        public static IRequestContext GetContext(this HttpRequest request)
        {
            return new RequestContext();
        }
    }
}
