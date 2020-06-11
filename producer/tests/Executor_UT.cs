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
		private readonly int bitmaps = 10;
		private readonly int pixels = 1700;
		private readonly int pixelSize = 5;

		private AutofacServiceProvider injector;

		private AutofacServiceProvider GetInjector()
		{
			var serviceCollection = new ServiceCollection();
			var containerBuilder = new ContainerBuilder();

			containerBuilder.Populate(serviceCollection);

			containerBuilder.RegisterType<Executor>().As<IExecutor>();
			containerBuilder.RegisterType<DataGenerator>().As<IDataGenerator>();
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
			IExecutor ex = injector.GetService<IExecutor>();
				//new Executor(injector.GetService injector.GetService<IFileWriter>());

			// Act
			var actual = ex.Execute(this.bitmaps, this.pixels, this.pixelSize);

			// Assert
			Assert.IsInstanceOf<Executor.Statistics>(actual);
			Assert.IsNotNull(actual);
			Assert.IsNotNull(actual.elapsedIndividualAverageTime);
			Assert.IsNotNull(actual.elapsedTotalTime);
			Assert.GreaterOrEqual(actual.elapsedIndividualAverageTime, 0);
			Assert.GreaterOrEqual(actual.elapsedTotalTime, 0);
		}
		
		[Test]
		public void GenerateData_IllegalItems()
		{
			// Arrange
			IExecutor ex = injector.GetService<IExecutor>();

			// Act
			ActualValueDelegate<object> testDelegate = () => ex.Execute(0, this.pixels, this.pixelSize);

			// Assert
			Assert.That(testDelegate, Throws.TypeOf<ApplicationException>());
		}
	}
}