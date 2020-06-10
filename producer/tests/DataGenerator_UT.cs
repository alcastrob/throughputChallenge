using NUnit.Framework;
using NUnit.Framework.Constraints;
using Producer;
using System;

namespace Producer_Tests
{
    public class DataGenerator_UT
    {
        private readonly int size = 1700;

        [Test]
        public void GenerateData_HappyPath()
        {
            // Arrange
            DataGenerator dg = new DataGenerator();

            // Act
            var actual = dg.GenerateData(this.size);

            // Assert
            Assert.AreEqual(this.size, actual.Length);
            Assert.IsInstanceOf<double[]>(actual);
            Assert.IsNotNull(actual);
        }
        
        [Test]
        public void GenerateData_IllegalSize()
        {
            // Arrange
            DataGenerator dg = new DataGenerator();

            // Act
            ActualValueDelegate<object> testDelegate = () => dg.GenerateData(0);

            // Assert
            Assert.That(testDelegate, Throws.TypeOf<ApplicationException>());
        }
    }
}