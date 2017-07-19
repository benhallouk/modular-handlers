namespace Example.Module
{
    using Core.Context;
    using Core.Handlers;
    using Core.Models;

    public class ExampleHandler : AbstractHandler
    {
        public ExampleHandler(IRequestContext contextObject) : base(contextObject)
        {
        }

        public override bool CanHandelRequest()
        {
            return ContextObject.Type == "Example";
        }

        public override IResponseModel ErrorResponse()
        {
            return new ResponseModel()
            {
                Errors = new[] { "Ops" }
            };
        }

        public override IResponseModel HandelRequest()
        {
            return new ResponseModel();
        }
    }
}