using FluentAssertions;
using SequenceAnalysis;
using Xunit;

namespace Asml.UnitTests.SequenceAnalysis
{
    public class UppercaseWordsFinderTests
    {
        [Theory]
        [InlineData("This IS a STRING", 2)]
        [InlineData("", 0)]
        [InlineData("This  IS  a STRING   ", 2)]
        [InlineData(null, 0)]
        public void Find_ShouldFindUppercaseWordsAsExpected(string input, int countExpected)
        {
            var sut = new UppercaseWordsFinder();

            sut.Find(input).Should().HaveCount(countExpected);
        }
    }
}
