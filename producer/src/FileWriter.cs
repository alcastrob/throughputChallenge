using System;
using System.IO;
using System.Linq;

namespace Producer
{
	class FileWriter : IFileWriter
	{
		public void InitializeDirectory(string directory)
		{
			if (string.IsNullOrEmpty(directory))
            {
				throw new ArgumentNullException("directory");
            }
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
            //File.WriteAllLines(file, data.Select(data => data.ToString()));
            File.WriteAllBytes(file, data.SelectMany(value => BitConverter.GetBytes(value)).ToArray());
        }
	}
}
