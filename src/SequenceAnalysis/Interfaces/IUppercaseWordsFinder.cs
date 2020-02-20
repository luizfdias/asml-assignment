using System.Collections.Generic;

namespace SequenceAnalysis.Interfaces
{
    public interface IUppercaseWordsFinder
    {
        IEnumerable<string> Find(string input);
    }
}
