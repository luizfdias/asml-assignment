using ApplicationServices.Interfaces;
using Runner.Interfaces;
using SumOfMultiple.Interfaces;
using System;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public class SumOfMultipleService : IProblemSolver
    {
        private readonly INaturalNumberSumCalculator _naturalNumberSumCalculator;
        private readonly IConsoleWrapper _console;

        public SumOfMultipleService(
            INaturalNumberSumCalculator naturalNumberSumCalculator,
            IConsoleWrapper console)
        {
            _naturalNumberSumCalculator = naturalNumberSumCalculator ?? throw new ArgumentNullException(nameof(naturalNumberSumCalculator));
            _console = console ?? throw new ArgumentNullException(nameof(console));
        }

        public async Task<string> Start()
        {
            _console.WriteLine("Please enter a positive number to be analysed: ");
            var input = _console.ReadLine();

            var number = ParseInput(input);

            if (number == -1)
            {
                _console.WriteLine("Input is not a natural number. Try again!");
                return string.Empty;
            }

            _console.WriteLine("Initializing analysis...");
            var naturalSumResult = await _naturalNumberSumCalculator.Calculate(number, 3, 5);
            
            return naturalSumResult.ToString();
        }

        private static long ParseInput(string input)
        {
            if (long.TryParse(input, out var number) && number > 0) 
                return number;
            
            return -1;
        }
    }
}
