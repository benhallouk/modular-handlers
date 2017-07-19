namespace Example.Core.Context.Providers
{
    public interface IContextProviderBase
    {
        IRequestContext ResolveContext();
    }
}
