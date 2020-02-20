using FluentAssertions;
using NSubstitute;
using SequenceAnalysis;
using SequenceAnalysis.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Asml.UnitTests.SequenceAnalysis
{
    public class SequenceAnalyserTests
    {
        private readonly SequenceAnalyser _sut;
        private readonly ISorter<string> _sorter;
        private readonly IUppercaseWordsFinder _finder;

        public SequenceAnalyserTests()
        {
            _sorter = Substitute.For<ISorter<string>>();
            _finder = Substitute.For<IUppercaseWordsFinder>();

            _sut = new SequenceAnalyser(_sorter, _finder);
        }

        [Fact]
        public async Task Analyse_WhenInputIsProvided_ShouldReturnResultAsExpected()
        {
            string input = "TEST abc GO";

            _finder.Find(input).Returns(new List<string> { "TEST", "GO" });
            _sorter.Sort("TESTGO").Returns("EGOSTT");

            var result = await _sut.Analyse(input);

            result.Should().Be("EGOSTT");
        }
    }
}
