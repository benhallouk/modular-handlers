namespace Example.Tests
{
    using Core.Context;
    using Core.Handlers;
    using Dependencies;
    using Moq;
    using Ninject;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class Harness
    {
        [Test]
        public void Should_Handel_Request()
        {
            var context = new Mock<IRequestContext>();

            var handler1 = new Mock<AbstractHandler>(context.Object);
            handler1.Setup(x => x.CanHandelRequest()).Returns(true);
            handler1.Object.ProcessRequest();
            handler1.Verify(x => x.HandelRequest(), Times.Once);
        }

        [Test]
        public void Should_Load_Module()
        {
            IKernel kernel = new StandardKernel(new Module());
            kernel.Bind<IRequestContext>().To<RequestContext>();

            var modules = kernel.GetAll<AbstractHandler>().ToList();

            Assert.AreEqual(1, modules.Count);
        }


        [Test]
        public void Should_Load_Module_And_Handel_Request()
        {
            IKernel kernel = new StandardKernel(new Module());

            var context = new Mock<IRequestContext>();
            context.Setup(x => x.Type).Returns("Example");

            kernel.Bind<IRequestContext>().ToConstant(context.Object);

            var modules = kernel.GetAll<AbstractHandler>().ToList();

            Assert.AreEqual(true, modules.First().CanHandelRequest());
        }
    }
}