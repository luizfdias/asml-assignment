using ApplicationServices.Interfaces;
using Runner.Interfaces;
using SequenceAnalysis.Interfaces;
using System;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public class SequenceAnalysisService : IProblemSolver
    {
        private readonly ISequenceAnalyser _sequenceAnalyser;
        private readonly IConsoleWrapper _console;

        public SequenceAnalysisService(
            ISequenceAnalyser sequenceAnalyser,
            IConsoleWrapper console)
        {
            _sequenceAnalyser = sequenceAnalyser ?? throw new ArgumentNullException(nameof(sequenceAnalyser));
            _console = console ?? throw new ArgumentNullException(nameof(console));
        }

        public Task<string> Start()
        {
            _console.WriteLine("Please enter some text to be analyzed: ");
            var text = _console.ReadLine();

            _console.WriteLine("Initializing analysis...");
            return _sequenceAnalyser.Analyse(text);
        }
    }
}
