using SumOfMultiple.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumOfMultiple
{
    public class NaturalNumberSumCalculator : INaturalNumberSumCalculator
    {
        public Task<long> Calculate(long limit, params int[] divisors)
        {
            var result = new List<long>();

            foreach (var divisor in divisors)
            {
                var multiplesCount = limit / divisor;

                var multiplesSequence = Enumerable.Range(1, (int)multiplesCount);

                foreach (var sequenceItem in multiplesSequence)
                {
                    result.Add(divisor * sequenceItem);
                }                
            }

            return Task.FromResult(result.Distinct().Sum());
        }
    }
}
