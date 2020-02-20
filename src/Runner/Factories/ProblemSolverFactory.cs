using ApplicationServices;
using ApplicationServices.Interfaces;
using SequenceAnalysis;
using SumOfMultiple;

namespace Runner.Factories
{
    public static class ProblemSolverFactory
    {
        public static IProblemSolver Create(string userAction)
        {
            if (userAction.Equals("1"))
            {
                return new SumOfMultipleService(
                    new NaturalNumberSumCalculator());
            }
            else if (userAction.Equals("2"))
            {
                return new SequenceAnalysisService(
                    new SequenceAnalyser(
                        new StringLinqSorter(), 
                        new UppercaseWordsFinder()));
            }

            return null;
        }
    }
}