namespace Producer
{
  internal interface IExecutor
  {
    Executor.Statistics Execute(int items, int itemPixels, int pixelSize);
  }
}