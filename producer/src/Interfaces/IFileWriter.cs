namespace Producer
{
	interface IFileWriter
	{
		void InitializeDirectory(string directory);
		void Write(string file, float[] data);
	}
}