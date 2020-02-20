using SequenceAnalysis.Interfaces;
using System.Linq;

namespace SequenceAnalysis
{
    public class StringLinqSorter : ISorter<string>
    {        
        public string Sort(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return new string(input.OrderBy(x => x).ToArray());
        }
    }
}
