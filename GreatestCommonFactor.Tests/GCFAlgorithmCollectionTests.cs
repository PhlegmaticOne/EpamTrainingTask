using GreatestCommonFactor.Lib;
using System;
using System.Collections.Generic;
using Xunit;

namespace GreatestCommonFactor.Tests
{
    public class GCFAlgorithmCollectionTests
    {
        [Fact]
        public void GCFAlgorithmCollection_ConstructorThrowsArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => new GCFAlgorithmCollection(null));
        }
        [Fact]
        public void GCFAlgorithmCollection_ConstructorThrowsArgumentExceptionWhenIncomeCollectionHasNoElementsTest()
        {
            Assert.Throws<ArgumentException>(() => new GCFAlgorithmCollection(new List<GCFAlgorithm>()));
        }
        [Fact]
        public void GCFAlgorithmCollection_AddAlgorithmsTest()
        {
            var collection = new GCFAlgorithmCollection();
            collection.Add(new EuclideanAlgorithm(1, 2, 3))
                      .Add(new SteinsAlgorithm(3, 2, 1))
                      .Add(new EuclideanAlgorithm(123, 2))
                      .Add(new SteinsAlgorithm(3))
                      .Add(new SteinsAlgorithm(322, 2323, 23));
            Assert.Equal(5, collection.Count);
        }
        [Fact]
        public void GCFAlgorithmCollection_AddNullsTest()
        {
            var collection = new GCFAlgorithmCollection();
            collection.Add(null).Add(null).Add(null);
            Assert.Equal(0, collection.Count);
        }
    }
}
