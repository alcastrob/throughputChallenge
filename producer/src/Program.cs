using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using CommandLine;
using System.Text;

namespace Producer
{
	class Program
	{
		class Options
		{
			[Option('b', "bitmaps", Required = true, HelpText = "Number of bitmaps to generate (i.e. 265)")]
			public int bitmaps { get; set; }
			[Option('p', "totalPixels", Required = true, HelpText = "Number of pixels that every bitmap will contain (i.e. 1700)")]
			public int pixels { get; set; }
			[Option('d', "pixelDepth", Required = true, HelpText = "Number of float values contained on every pixel (i.e. 5)")]
			public int depth { get; set; }
			[Option('s', "saveDirectory", Required = true, HelpText = "The directory where all the bitmaps will be saved (i.e. ./data)")]
			public string path { get; set; }

		}

		/// <summary>
		/// This method will prepare all required config for the autofac dependency injection system, including
		/// the mapping of the interfaces and their corresponding types.
		/// </summary>
		private static AutofacServiceProvider GetInjector()
		{
			var serviceCollection = new ServiceCollection();
			var containerBuilder = new ContainerBuilder();

			containerBuilder.Populate(serviceCollection);
			containerBuilder.RegisterType<FileWriter>().As<IFileWriter>();
			containerBuilder.RegisterType<Executor>().As<IExecutor>();
			containerBuilder.RegisterType<DataGenerator>().As<IDataGenerator>();

			var container = containerBuilder.Build();
			return new AutofacServiceProvider(container);
		}

		static void Main(string[] args)
		{
			AutofacServiceProvider injector = GetInjector();

			Console.WriteLine("Data producer");
			IExecutor ex = injector.GetService<IExecutor>();

			Parser.Default.ParseArguments<Options>(args)
				   .WithParsed<Options>(o =>
				   {
					   ex.CleanEnvironment(o.path);
					   Console.WriteLine(string.Format("Start producing {0} bitmps of {1} pixels of {2} float/depth at {3}",
						   o.bitmaps, o.pixels, o.depth, o.path));

                       var statistics = ex.Execute(o.bitmaps, o.pixels, o.depth, o.path.Trim());

                       Console.WriteLine(string.Format("Total time (ms): {0}", statistics.elapsedTotalTime));
                       Console.WriteLine(string.Format("Average time per item (ms): {0}", statistics.elapsedIndividualAverageTime));
                       Console.WriteLine(string.Format("Total floats generated: {0}", o.bitmaps * o.pixels * o.depth));
                   });
		}
	}
}
