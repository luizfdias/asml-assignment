using ApplicationServices;
using FluentAssertions;
using NSubstitute;
using Runner.Interfaces;
using SumOfMultiple;
using System.Threading.Tasks;
using Xunit;

namespace Asml.IntegrationTests.Services
{
    public class SumOfMultipleServiceTests
    {
        private readonly SumOfMultipleService _sut;
        private readonly IConsoleWrapper _console;

        public SumOfMultipleServiceTests()
        {
            _console = Substitute.For<IConsoleWrapper>();

            _sut = new SumOfMultipleService(
                    new NaturalNumberSumCalculator(),
                    _console);
        }

        [Fact]
        public async Task Start_GivenALimit_ShouldReturnResultAsExpected()
        {
            _console.ReadLine().Returns("18");

            var result = await _sut.Start();

            result.Should().Be("78");
        }

        [Fact]
        public async Task Start_WhenLimitIsNotValid_ShouldReturnEmptyResult()
        {
            _console.ReadLine().Returns("-10");

            var result = await _sut.Start();

            result.Should().BeEmpty();
        }
    }
}
