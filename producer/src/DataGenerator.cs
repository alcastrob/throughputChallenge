using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("producer_tests")]
namespace Producer
{
    /// <summary>
    /// This class will generate the data item, that is an array of double values.
    /// </summary>
    internal class DataGenerator : IDataGenerator
    {
        /// <summary>
        /// This method will return an array of as many double values as requested in the parameter.
        /// </summary>
        /// <param name="itemSize">The size of the expected item array. Must be greather that zero.</param>
        /// <returns>An array of random doubles of the requested size.</returns>
        public double[] GenerateData(int itemSize)
        {
            if (itemSize < 1)
            {
                throw new ApplicationException("The item size must be greater or equal to one");
            }

            // No need to set up a seed. The program purpose is to calculate a througput, not to have good random numbers
            var random = new Random();
            var returnedValue = new double[itemSize];
            for (int counter = 0; counter < itemSize; counter++)
            {
                returnedValue[counter] = random.NextDouble();
            }
            return returnedValue;
        }
    }
}
