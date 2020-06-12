namespace Producer
{
    internal interface IExecutor
    {
        void CleanEnvironment(string path);
        Executor.Statistics Execute(int items, int itemPixels, int pixelSize, string path);
    }
}