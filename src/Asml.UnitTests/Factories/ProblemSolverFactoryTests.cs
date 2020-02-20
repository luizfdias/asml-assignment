using ApplicationServices;
using FluentAssertions;
using Runner.Factories;
using System;
using Xunit;

namespace Asml.UnitTests.Factories
{
    public class ProblemSolverFactoryTests
    {
        [Theory]
        [InlineData("1", typeof(SumOfMultipleService))]
        [InlineData("2", typeof(SequenceAnalysisService))]
        public void Create_GivenAnUserAction_ShouldCreateProblemSolverAsExpected(
            string userAction, Type typeExpected)
        {
            ProblemSolverFactory.Create(userAction).Should().BeOfType(typeExpected);
        }

        [Theory]
        [InlineData("9")]
        public void Create_GivenAnInvalidUserAction_ReturnShouldBeNull(
            string userAction)
        {
            ProblemSolverFactory.Create(userAction).Should().BeNull();
        }
    }
}
