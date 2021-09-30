using GreatestCommonFactor.Lib;
using System;
using System.Collections.Generic;
using Xunit;


namespace GreatestCommonFactor.Tests
{
    public class GCFTimeAlgorithTests
    {
        [Fact]
        public void GCFTimeAlgorithm_ConstructorThrowsArgumentNullException()
        {
            GCFAlgorithmCollection collection = null;
            Assert.Throws<ArgumentNullException>(() => new GCFTimeAlgorithm(collection));
        }
        [Fact]
        public void GCFTimeAlgorithm_ConstructorThrowsArgumentException()
        {
            GCFAlgorithmCollection collection = new GCFAlgorithmCollection();
            Assert.Throws<ArgumentException>(() => new GCFTimeAlgorithm(collection));
        }
        [Fact]
        public void GCFTimeAlgorithm_GetAlgorithmsExecutionTimeWithNotUniqueAlgorithmsTest()
        {
            GCFAlgorithmCollection collection = new GCFAlgorithmCollection(GetNotUniqueGCFAlgorithms());
            GCFTimeAlgorithm timeAlgorithm = new GCFTimeAlgorithm(collection);
            var result = timeAlgorithm.GetAlgorithmsExecutionTime();
            Assert.Equal(2, result.Count);
            foreach (var time in result.Values)
            {
                Assert.True(time != TimeSpan.Zero);
            }
        }
        [Fact]
        public void GCFTimeAlgorith_GetAlgorithmsExecutionTimeWithUniqueAlgorithmsTest()
        {
            GCFAlgorithmCollection collection = new GCFAlgorithmCollection(GetUniqueGCFAlgorithms());
            GCFTimeAlgorithm timeAlgorithm = new GCFTimeAlgorithm(collection);
            var result = timeAlgorithm.GetAlgorithmsExecutionTime();
            Assert.Equal(5, result.Count);
            foreach (var time in result.Values)
            {
                Assert.True(time != TimeSpan.Zero);
            }
        }
        [Fact]
        public void GCFTimeAlgorith_GetAlgorithmsExecutionTimeWithAddingAlgorithmsTest()
        {
            GCFAlgorithmCollection collection = new GCFAlgorithmCollection()
                                                    .Add(new EuclideanAlgorithm(4, 5, 6))
                                                    .Add(new SteinsAlgorithm(100, 232, 22))
                                                    .Add(new EuclideanAlgorithm(3432, 11, 223))
                                                    .Add(new SteinsAlgorithm(123, 22, 43));

            GCFTimeAlgorithm timeAlgorithm = new GCFTimeAlgorithm(collection);
            var result = timeAlgorithm.GetAlgorithmsExecutionTime();
            Assert.Equal(4, result.Count);
            foreach (var time in result.Values)
            {
                Assert.True(time != TimeSpan.Zero);
            }
        }

        private ICollection<GCFAlgorithm> GetUniqueGCFAlgorithms()
        {
            return new List<GCFAlgorithm>()
            {
                new EuclideanAlgorithm(2, 4, 6, 8),
                new SteinsAlgorithm(23, 33, 55, 2),
                new EuclideanAlgorithm(113, 1232, 25, 2),
                new SteinsAlgorithm(1, 2, 52, 213),
                new EuclideanAlgorithm(0, 0, 0, 0)
            };
        }

        private ICollection<GCFAlgorithm> GetNotUniqueGCFAlgorithms()
        {
            return new List<GCFAlgorithm>()
            {
                new EuclideanAlgorithm(23, 33, 55, 2),
                new SteinsAlgorithm(23, 33, 55, 2),
                new EuclideanAlgorithm(23, 33, 55, 2),
                new SteinsAlgorithm(23, 33, 55, 2),
                new EuclideanAlgorithm(23, 33, 55, 2)
            };
        }
    }
}
