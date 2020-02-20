using FluentAssertions;
using SequenceAnalysis;
using Xunit;

namespace Asml.UnitTests.SequenceAnalysis
{
    public class StringLinqSorterTests
    {
        [Theory]
        [InlineData("ISSTRING", "GIINRSST")]
        [InlineData("CBA", "ABC")]
        [InlineData("CBA132", "123ABC")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void Sort_ShouldSortStringAsExpected(string input, string expected)
        {
            var sut = new StringLinqSorter();

            sut.Sort(input).Should().Be(expected);
        }
    }
}
