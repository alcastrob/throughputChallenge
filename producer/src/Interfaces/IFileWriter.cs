using System.Collections.Generic;

namespace Producer
{
	interface IFileWriter
	{
		void InitializeDirectory(string directory);
		void Write(string file, float[] data);
		void Write(string file, List<float[]> data);
	}
}