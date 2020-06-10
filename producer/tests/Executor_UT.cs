using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Producer;
using producer_tests.Mocks;
using System;

namespace Producer_Tests
{
    public class Executor_UT
    {
        private readonly int size = 1700;
        private readonly int items = 10;

        private AutofacServiceProvider injector;

        private AutofacServiceProvider GetInjector()
        {
            var serviceCollection = new ServiceCollection();
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceCollection);

            //Here goes the mocked versions of the real objects...
            containerBuilder.RegisterType<MockFileWriter>().As<IFileWriter>();

            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }


        [SetUp]
        public void Setup()
        {
            injector = GetInjector();
        }

        [Test]
        public void Execute_HappyPath()
        {
            // Arrange
            Executor ex = new Executor(injector.GetService<IFileWriter>());

            // Act
            var actual = ex.Execute(this.items, this.size);

            // Assert
            Assert.IsInstanceOf<Executor.Statistics>(actual);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.elapsedIndividualAverageTime);
            Assert.IsNotNull(actual.elapsedTotalTime);
            Assert.GreaterOrEqual(actual.elapsedIndividualAverageTime, 0);
            Assert.GreaterOrEqual(actual.elapsedTotalTime, 0);
        }
        
        [Test]
        public void GenerateData_IllegalIterations()
        {
            // Arrange
            Executor ex = new Executor(injector.GetService<IFileWriter>());

            // Act
            ActualValueDelegate<object> testDelegate = () => ex.Execute(0, this.size);

            // Assert
            Assert.That(testDelegate, Throws.TypeOf<ApplicationException>());
        }
    }
}