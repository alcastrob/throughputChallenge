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
            //throw new NotImplementedException();
        }

        public void Write(string file, double[] data)
        {
            //throw new NotImplementedException();
        }
    }
}
