using NUnit.Framework;
using NUnit.Framework.Constraints;
using Producer;
using System;

namespace Producer_Tests
{
	public class DataGenerator_UT
	{
		private readonly int pixels = 1700;
		private readonly int pixelSize = 4;

		[Test]
		public void GenerateData_HappyPath()
		{
			// Arrange
			DataGenerator dg = new DataGenerator();

			// Act
			var actual = dg.GenerateData(this.pixels, this.pixelSize);

			// Assert
			Assert.AreEqual(this.pixels * this.pixelSize, actual.Length);
			Assert.IsInstanceOf<float[]>(actual);
			Assert.IsNotNull(actual);
		}
		
		[Test]
		public void GenerateData_IllegalPixelNumber()
		{
			// Arrange
			DataGenerator dg = new DataGenerator();

			// Act
			ActualValueDelegate<object> testDelegate = () => dg.GenerateData(0, this.pixelSize);

			// Assert
			Assert.That(testDelegate, Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public void GenerateData_IllegalPixelSize()
		{
			// Arrange
			DataGenerator dg = new DataGenerator();

			// Act
			ActualValueDelegate<object> testDelegate = () => dg.GenerateData(this.pixels, 0);

			// Assert
			Assert.That(testDelegate, Throws.TypeOf<ArgumentException>());
		}
	}
}