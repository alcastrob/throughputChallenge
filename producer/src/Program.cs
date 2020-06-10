using System;
using System.Diagnostics;
using System.Threading;

namespace Producer
{
    class Program
    {
        const int ITEMS = 50 * 1000;
        const int ITEM_SIZE = 1700;

        static void Main(string[] args)
        {
            Console.WriteLine("Data producer");
            Executor ex = new Executor();
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
