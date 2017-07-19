namespace Example.Dependencies
{
    using Core.Handlers;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class Module : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
                x.FromAssembliesMatching("*.Module.dll")
                    .SelectAllClasses()
                    .InheritedFrom<AbstractHandler>()
                    .BindAllBaseClasses());
        }
    }
}
