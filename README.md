# Modular Handlers

This code contains a chain of responsability pattern that enable you to have separated modules that can collaborate handel requests

## Core

This is where the pattern live, it contains all the nessessary components for the pattern to work

- `RequestContext`: the actual data that specify the attributes of the request that may come from the query string, headers or any other external data storage

- `ContextProvider`: this is the context resolver ex `HttpContextProvider` is a context resolve that uses queryString to retrive the context

- `AbstractHandler`: this is the base handler that uses the template pattern to force consistancy in dealing with requests using the abstract `CanHandelRequest` and `HandelRequest` methods


- `ResponseModel`: is the schema of the returned data which contains the actual `ResponseBody` this is used to ensure that all the handlers communicate using the same contract

## Template method pattern

The `AbstractHandler` uses template method pattern to ensure consistancy of dealing with requests see the code below

```csharp
public abstract bool CanHandelRequest();
public abstract IResponseModel HandelRequest();

public abstract IResponseModel ErrorResponse();
public IResponseModel ProcessRequest()
{
    return CanHandelRequest() ? HandelRequest() : ErrorResponse();
}
```

## DI

The modules are registred using the DI module as soon as they folow this convension in thier assemmbly `*.Module.dll`

```csharp
Kernel.Bind(x =>
    x.FromAssembliesMatching("*.Module.dll")
        .SelectAllClasses()
        .InheritedFrom<AbstractHandler>()
        .BindAllBaseClasses());
```


## Example Handler

```csharp
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
```

## The pattern in action


```csharp
IKernel kernel = new StandardKernel(new Module());

var context = new Mock<IRequestContext>();
context.Setup(x => x.Type).Returns("Example");

kernel.Bind<IRequestContext>().ToConstant(context.Object);

var handlers = kernel.GetAll<AbstractHandler>().ToList();

foreach (var handler in handlers)
{
    if (handler.CanHandelRequest())
    {
        handler.ProcessRequest();
    }                    
}
```