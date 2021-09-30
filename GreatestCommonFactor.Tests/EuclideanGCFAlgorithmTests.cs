using GreatestCommonFactor.Lib;
using System;
using System.Collections.Generic;
using Xunit;

namespace GreatestCommonFactor.Tests
{
    public class EuclideanGCFAlgorithmTests
    {
        [Theory]
        [InlineData(45, 5, 5)]
        [InlineData(60, 60, 60)]
        [InlineData(111, 37, 37)]
        [InlineData(2342, 342, 2)]
        [InlineData(1000001, 34, 1)]
        [InlineData(5435345, 0, 5435345)]
        [InlineData(0, 12222, 12222)]
        [InlineData(0, 0, 0)]
        public void EuclideanGCFAlgorithm_EuclideanGCFTest(int a, int b, int expected)
        {
            Assert.Equal(expected, EuclideanGCFAlgorithm.GCF(a, b));
        }

        [Theory]
        [InlineData(45, 5, 5)]
        [InlineData(60, 60, 60)]
        [InlineData(111, 37, 37)]
        [InlineData(2342, 342, 2)]
        [InlineData(1000001, 34, 1)]
        [InlineData(5435345, 0, 5435345)]
        [InlineData(0, 12222, 12222)]
        [InlineData(0, 0, 0)]
        public void EuclideanGCFAlgorithm_SteinsGCFTest(int a, int b, int expected)
        {
            Assert.Equal(expected, EuclideanGCFAlgorithm.BinaryGCF(a, b));
        }

        [Theory]
        [InlineData(-45, 5)]
        [InlineData(60, -60)]
        [InlineData(-111, -37)]
        public void EuclideanGCFAlgorithm_ThrowsArgumentExceptionEuclideanGCFTest(int a, int b)
        {
            Assert.Throws<ArgumentException>(() => EuclideanGCFAlgorithm.GCF(a, b));
        }

        [Theory]
        [InlineData(-45, 5)]
        [InlineData(60, -60)]
        [InlineData(-111, -37)]
        public void EuclideanGCFAlgorithm_ThrowsArgumentExceptionSteinsGCFTest(int a, int b)
        {
            Assert.Throws<ArgumentException>(() => EuclideanGCFAlgorithm.BinaryGCF(a, b));
        }

        [Theory]
        [InlineData(10, 110, 120, 130, 140)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 123, 144, 12, 10)]
        [InlineData(50, 100, 200, 150, 10350)]
        [InlineData(11, 77, 132)]
        [InlineData(23, 46, 69, 207, 230, 253, 276)]
        [InlineData(3, 168, 150, 27, 24, 21, 18, 15, 12, 9, 6, 3)]
        public void EuclideanGCFAlgorithm_ParamsEuclideanGCFTest(int expected, params int[] numbers)
        {
            Assert.Equal(expected, EuclideanGCFAlgorithm.GCF(numbers));
        }

        [Fact]
        public void EuclideanGCFAlgorithm_EuclideanGFCWithOutTimeTest()
        {
            EuclideanGCFAlgorithm.GCF(100, 10, out TimeSpan time);
            Assert.True(time != TimeSpan.Zero);
        }

        [Fact]
        public void EuclideanGCFAlgorithm_StainsGFCWithOutTimeTest()
        {
            EuclideanGCFAlgorithm.BinaryGCF(100, 10, out TimeSpan time);
            Assert.True(time != TimeSpan.Zero);
        }

        [Fact]
        public void EuclideanGCFAlgorithm_ExecutionTimeGetTest()
        {
            IEnumerable<EuclideanAlgorithmExecutionResult> times = EuclideanGCFAlgorithm.GetAlgorithmsExecutionTimeResults(100, 10);
            foreach (var executionResult in times)
            {
                Assert.True(executionResult.ExecutionTime != TimeSpan.Zero);
                Assert.True(executionResult.AlgorithmName is not null);
            }
        }
    }
}
