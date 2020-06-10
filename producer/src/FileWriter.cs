using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Producer
{
    class FileWriter : IFileWriter
    {
        public void InitializeDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }
            Directory.CreateDirectory(directory);
        }

        public void Write(string file, double[] data)
        {
            //File.WriteAllLines(file, data.Select(data => data.ToString()));
            File.WriteAllBytes(file, data.SelectMany(value => BitConverter.GetBytes(value)).ToArray());
        }
    }
}
