using NuGet.Frameworks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Producer;
using System;

namespace Producer_Tests
{
    public class Executor_UT
    {
        private readonly int size = 1700;
        private readonly int items = 10;

        [Test]
        public void Execute_HappyPath()
        {
            // Arrange
            Executor ex = new Executor();

            // Act
            var actual = ex.Execute(this.items, this.size);

            // Assert
            Assert.IsInstanceOf<Executor.Statistics>(actual);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.elapsedIndividualAverageTime);
            Assert.IsNotNull(actual.elapsedTotalTime);
            Assert.GreaterOrEqual(actual.elapsedIndividualAverageTime, 0);
            Assert.GreaterOrEqual(actual.elapsedTotalTime, 0);
        }
        
        [Test]
        public void GenerateData_IllegalIterations()
        {
            // Arrange
            Executor ex = new Executor();

            // Act
            ActualValueDelegate<object> testDelegate = () => ex.Execute(0, this.size);

            // Assert
            Assert.That(testDelegate, Throws.TypeOf<ApplicationException>());
        }
    }
}