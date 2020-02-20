using System.Threading.Tasks;

namespace SequenceAnalysis.Interfaces
{
    public interface ISequenceAnalyser
    {
        Task<string> Analyse(string input);
    }
}
