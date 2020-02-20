using ApplicationServices;
using FluentAssertions;
using NSubstitute;
using Runner.Interfaces;
using SequenceAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace Asml.IntegrationTests.Services
{
    public class SequenceAnalysisServiceTests
    {
        private readonly SequenceAnalysisService _sut;
        private readonly IConsoleWrapper _console;

        public SequenceAnalysisServiceTests()
        {
            _console = Substitute.For<IConsoleWrapper>();

            _sut = new SequenceAnalysisService(
                    new SequenceAnalyser(
                        new StringLinqSorter(),
                        new UppercaseWordsFinder()),
                    _console);
        }

        [Fact]
        public async Task Start_GivenAStringWithUppercaseWords_ShouldReturnResultAsExpected()
        {
            _console.ReadLine().Returns("This IS a STRING");

            var result = await _sut.Start();

            result.Should().Be("GIINRSST");
        }
    }
}
