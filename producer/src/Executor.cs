using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Producer
{
	/// <summary>
	/// This class will request the generated data item and pass the to the python consumer
	/// </summary>
	internal class Executor : IExecutor
	{
		private readonly string directory = "./data/";
		private readonly int maxBufferSize = 10;
		private IFileWriter fileWriter;
		private IDataGenerator dataGenerator;
		private List<float[]> buffer;

		public Executor(IDataGenerator dataGenerator, IFileWriter writer)
		{
			this.fileWriter = writer;
			this.dataGenerator = dataGenerator;
			this.buffer = new List<float[]>();
			// Clean up the environment
			this.fileWriter.InitializeDirectory(directory);
		}

		/// <summary>
		/// The execution method.
		/// </summary>
		/// <param name="items">Number of bitmaps to generate</param>
		/// <param name="itemPixels">Number of pixels per bitmap</param>
		/// <param name="pixelSize">Number of float values per pixel</param>
		/// <returns>The execution times</returns>
		public Statistics Execute(int items, int itemPixels, int pixelSize)
		{
			if (items < 1)
			{
				throw new ApplicationException("Items must be at least one");
			}

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			int fileCounter = 0;
			for (int counter = 0; counter < items; counter++)
			{
				var data = dataGenerator.GenerateData(itemPixels, pixelSize);
				this.buffer.Add(data);
				if (buffer.Count == maxBufferSize || counter >= items)
                {
					fileWriter.Write(string.Format("{0}{1:00000000}", directory, fileCounter), this.buffer);
					fileCounter++;
					this.buffer.Clear();
                }
			}
			stopWatch.Stop();
			return new Statistics
			{
				elapsedTotalTime = stopWatch.ElapsedMilliseconds,
				elapsedIndividualAverageTime = ((double)stopWatch.ElapsedMilliseconds / items)
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
