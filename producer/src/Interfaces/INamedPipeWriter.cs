namespace Producer
{
    internal interface INamedPipeWriter
    {
        void Initialize(string pipeName);
        void Write(float[] data);
    }
}