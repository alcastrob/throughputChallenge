using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Producer
{
    internal class StreamData
    {
        private Stream ioStream;
        private UnicodeEncoding streamEncoding;

        public StreamData(Stream ioStream)
        {
            this.ioStream = ioStream;
            streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            int len = 0;

            len = ioStream.ReadByte() * 256;
            len += ioStream.ReadByte();
            byte[] inBuffer = new byte[len];
            ioStream.Read(inBuffer, 0, len);

            return streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            byte[] outBuffer = streamEncoding.GetBytes(outString);
            WriteBytes(outBuffer);
            return outBuffer.Length + 2;
        }

        public void WriteBytes(byte[] data)
        {
            int len = data.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            ioStream.WriteByte((byte)(len / 256));
            ioStream.WriteByte((byte)(len & 255));
            ioStream.Write(data, 0, len);
            ioStream.Flush();
        }
    }
}
