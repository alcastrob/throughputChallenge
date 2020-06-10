using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Producer
{
    class Program
    {
        const int ITEMS = 1 * 1000;
        const int ITEM_SIZE = 1700;

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
            return  new AutofacServiceProvider(container);
        }

        static void Main(string[] args)
        {
            AutofacServiceProvider injector = GetInjector();

            Console.WriteLine("Data producer");
            IExecutor ex = injector.GetService<IExecutor>();
            var statistics = ex.Execute(ITEMS, ITEM_SIZE);
            
            Console.WriteLine(string.Format("Total time (ms): {0}", statistics.elapsedTotalTime));
            Console.WriteLine(string.Format("Average time per item (ms): {0}", statistics.elapsedIndividualAverageTime));
            Console.WriteLine(string.Format("Total doubles generated: {0}", ITEMS * ITEM_SIZE));

            Console.WriteLine();
            Console.WriteLine("Press Enter to quit");
            Console.ReadLine();
        }
    }
}
