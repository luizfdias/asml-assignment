using System.Threading.Tasks;

namespace SumOfMultiple.Interfaces
{
    public interface INaturalNumberSumCalculator
    {
        Task<long> Calculate(long limit, params int[] divisors);
    }
}
