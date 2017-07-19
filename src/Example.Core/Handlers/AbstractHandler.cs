namespace Example.Core.Handlers
{
    using Context;
    using Models;

    public abstract class AbstractHandler
    {
        public IRequestContext ContextObject { get; }

        protected AbstractHandler(IRequestContext contextObject)
        {
            ContextObject = contextObject;
        }

        public abstract bool CanHandelRequest();
        public abstract IResponseModel HandelRequest();

        public abstract IResponseModel ErrorResponse();
        public IResponseModel ProcessRequest()
        {
            return CanHandelRequest() ? HandelRequest() : ErrorResponse();
        }
    }
}