using GreatestCommonFactor.Lib;
using System;
using Xunit;

namespace GreatestCommonFactor.Tests
{
    public class GCFAlgorithmsTests
    {
        [Fact]
        public void GCFAlorithm_ThrowsArgumentExceptionWhenNumbersLengthEqualsToZero()
        {
            Assert.Throws<ArgumentException>(() => new EuclideanAlgorithm());
        }
        [Fact]
        public void GCFAlorithm_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new EuclideanAlgorithm(null));
        }
        [Fact]
        public void GCFAlorithm_ThrowsArgumentExceptionWhenNumbersContainsNegativeNumbers()
        {
            Assert.Throws<ArgumentException>(() => new EuclideanAlgorithm(1, 2, 3, -5, -6, 5));
        }
        [Fact]
        public void GCFAlorithm_EqualsWhenToClassesRefersToOneObject()
        {
            EuclideanAlgorithm algorithm = new EuclideanAlgorithm(1, 2, 3, 4);
            Assert.True(algorithm.Equals(algorithm));
        }
        [Fact]
        public void GCFAlorithm_EqualsWhenToClassesRefersToDiffenrentObject()
        {
            EuclideanAlgorithm algorithm1 = new EuclideanAlgorithm(1, 2, 3, 4);
            EuclideanAlgorithm algorithm2 = new EuclideanAlgorithm(1, 2, 3, 4);
            Assert.True(algorithm1.Equals(algorithm2));
        }
    }
}
