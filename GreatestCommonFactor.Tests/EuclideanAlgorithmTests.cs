using GreatestCommonFactor.Lib;
using Xunit;

namespace GreatestCommonFactor.Tests
{
    public class EuclideanAlgorithmTests
    {
        [Theory]
        [InlineData(10, 110, 120, 130, 140)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 123, 144, 12, 10)]
        [InlineData(50, 100, 200, 150, 10350)]
        [InlineData(11, 77, 132)]
        [InlineData(23, 46, 69, 207, 230, 253, 276)]
        [InlineData(3, 168, 150, 27, 24, 21, 18, 15, 12, 9, 6, 3)]
        public void EuclideanAlgorithm_ExecuteTest(int expected, params int[] numbers)
        {
            var alg = new EuclideanAlgorithm(numbers);
            Assert.Equal(expected, alg.Execute());
        }
    }
}
