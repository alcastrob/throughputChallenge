namespace Producer
{
    internal interface IExecutor
    {
        Executor.Statistics Execute(int iterations, int itemSize);
    }
}