using SequenceAnalysis.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SequenceAnalysis
{
    public class SequenceAnalyser : ISequenceAnalyser
    {
        private readonly ISorter<string> _sorter;
        private readonly IUppercaseWordsFinder _uppercaseWordsFinder;

        public SequenceAnalyser(
            ISorter<string> sorter,
            IUppercaseWordsFinder uppercaseWordsFinder)
        {
            _sorter = sorter ?? throw new ArgumentNullException(nameof(sorter));        
            _uppercaseWordsFinder = uppercaseWordsFinder ?? throw new ArgumentNullException(nameof(uppercaseWordsFinder));
        }

        public Task<string> Analyse(string input)
        {
            var uppercaseWords = _uppercaseWordsFinder.Find(input);

            return Task.FromResult(
                _sorter.Sort(uppercaseWords.Aggregate((x, y) => x + y)));
        }
    }
}
