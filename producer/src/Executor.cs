using System;
using System.Diagnostics;

namespace Producer
{
    /// <summary>
    /// This class will request the generated data item and pass the to the python consumer
    /// </summary>
    internal class Executor : IExecutor
    {
        private readonly string directory = "./data/";
        private IFileWriter fileWriter;
        private IDataGenerator dataGenerator;

        public Executor(IDataGenerator dataGenerator, IFileWriter writer)
        {
            this.fileWriter = writer;
            this.dataGenerator = dataGenerator;
            // Clean up the environment
            this.fileWriter.InitializeDirectory(directory);
        }

        /// <summary>
        /// The execution method.
        /// </summary>
        /// <param name="iterations">Number of elements to generate</param>
        /// <param name="itemSize">Size of doubles per element</param>
        /// <returns>The execution times</returns>
        public Statistics Execute(int iterations, int itemSize)
        {
            if (iterations < 1)
            {
                throw new ApplicationException("Iterations must be at least one");
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int counter = 0; counter < iterations; counter++)
            {
                var data = dataGenerator.GenerateData(itemSize);
                fileWriter.Write(string.Format("{0}.{1:00000000}", directory, counter), data);

            }
            stopWatch.Stop();
            return new Statistics
            {
                elapsedTotalTime = stopWatch.ElapsedMilliseconds,
                elapsedIndividualAverageTime = ((double)stopWatch.ElapsedMilliseconds / iterations)
            };
        }

        /// <summary>
        /// An internal structure to pass the multiple times outside the class properly identified.
        /// </summary>
        public struct Statistics
        {
            public double elapsedTotalTime;
            public double elapsedIndividualAverageTime;
        };
    }
}
