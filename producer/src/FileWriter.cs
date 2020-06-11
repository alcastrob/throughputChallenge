using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Producer
{
	class FileWriter : IFileWriter
	{
		public void InitializeDirectory(string directory)
		{
			if (Directory.Exists(directory))
			{
				DirectoryInfo di = new DirectoryInfo(directory);

				foreach (FileInfo file in di.GetFiles())
				{
					file.Delete();
				}
			} else
			{
				Directory.CreateDirectory(directory);
			}
		}

		public void Write(string file, float[] data)
		{
			File.WriteAllBytes(file, data.SelectMany(value => BitConverter.GetBytes(value)).ToArray());
		}

		public void Write(string file, List<float[]> data)
        {
			List<float> returnedValue = new List<float>();
			data.ForEach(bitmap => {
				returnedValue.AddRange(bitmap);
			});
			Write(file, returnedValue.ToArray());
        }
	}
}
