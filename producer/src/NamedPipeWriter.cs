using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace Producer
{
    internal class NamedPipeWriter : INamedPipeWriter
    {
        private NamedPipeServerStream serverPipe;
        public void Initialize(string pipeName)
        {
            serverPipe = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1);
            Console.WriteLine("Waiting the connection of the consumer");
            serverPipe.WaitForConnection();
            Console.WriteLine("Consumer connected");
        }

        public void Write(float[] data)
        {
            StreamData ss = new StreamData(serverPipe);
            ss.WriteBytes(data.SelectMany(value => BitConverter.GetBytes(value)).ToArray());
        }
    }
}
