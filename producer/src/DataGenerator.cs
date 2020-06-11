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
		/// <param name="itemPixels">Number of pixels per bitmap</param>
		/// <param name="pixelSize">Number of float values per pixel</param>
		/// <returns>An array of random doubles of the requested size.</returns>
		public float[] GenerateData(int itemPixels, int pixelSize)
		{
			if (itemPixels < 1)
			{
				throw new ArgumentException("itemPixels must be greater or equal to one");
			}
			if (pixelSize < 1)
			{
				throw new ArgumentException("pixelSize must be greater or equal to one");
			}

			// No need to set up a seed. The program purpose is to calculate a throughput, not to have good random numbers
			var random = new Random();
			var returnedValue = new float[itemPixels * pixelSize];
			var cursor = 0;
			for (int pixelCounter = 0; pixelCounter < itemPixels; pixelCounter++)
			{
				for(int pixelSizeCounter = 0; pixelSizeCounter < pixelSize; pixelSizeCounter++)
                {
					returnedValue[cursor++] = random.Next(0, 255) / 255f;
                }
			}
			return returnedValue;
		}
	}
}
