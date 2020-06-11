using Producer;
using System;
using System.Collections.Generic;
using System.Text;

namespace producer_tests.Mocks
{
	class MockFileWriter : IFileWriter
	{
		public void InitializeDirectory(string directory)
		{
			//Nothing to do here
		}

		public void Write(string file, float[] data)
		{
			//Nothing to do here
		}

		public void Write(string file, List<float[]> data)
		{
			//Nothing to do here
		}
	}
}
