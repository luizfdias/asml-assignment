using ApplicationServices.Interfaces;
using SequenceAnalysis;
using System;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public class SequenceAnalysisService : IProblemSolver
    {
        private readonly SequenceAnalyser _sequenceAnalyser;

        public SequenceAnalysisService(SequenceAnalyser sequenceAnalyser)
        {
            _sequenceAnalyser = sequenceAnalyser ?? throw new ArgumentNullException(nameof(sequenceAnalyser));
        }

        public Task<string> Start()
        {
            Console.WriteLine("Please enter some text to be analyzed: ");
            var text = Console.ReadLine();

            Console.WriteLine("Initializing analysis...");
            return _sequenceAnalyser.Analyse(text);
        }
    }
}
