using FluentAssertions;
using SumOfMultiple;
using System.Threading.Tasks;
using Xunit;

namespace Asml.UnitTests.SumOfMultiple
{
    public class NaturalNumberSumCalculatorTests
    {
        [Theory]
        [InlineData(3, 3, 3)]
        [InlineData(10, 3, 18)]
        [InlineData(12, 3, 30)]
        [InlineData(5, 5, 5)]
        [InlineData(16, 5, 30)]
        [InlineData(15, 5, 30)]
        [InlineData(0, 3, 0)]
        public async Task Calculate_GivenALimitAndTheMultiple_ShouldReturnResultAsExpected(
            long limit, int multiple, long expected)
        {
            var sut = new NaturalNumberSumCalculator();

            var result = await sut.Calculate(limit, multiple);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(15, 3, 5, 60)]
        [InlineData(18, 3, 5, 78)]
        public async Task Calculate_GivenALimitAndTwoMultiples_ShouldReturnResultAsExpected(
            long limit, int multiple1, int multiple2, long expected)
        {
            var sut = new NaturalNumberSumCalculator();

            var result = await sut.Calculate(limit, multiple1, multiple2);
            result.Should().Be(expected);
        }
    }
}
