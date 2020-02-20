using SequenceAnalysis.Interfaces;
using System.Collections.Generic;

namespace SequenceAnalysis
{
    public class UppercaseWordsFinder : IUppercaseWordsFinder
    {
        public IEnumerable<string> Find(string input)
        {
            var words = input == null 
                ? new string[] {}
                : input.Split(' ');

            foreach (var word in words)
            {
                bool isUpper = false;

                foreach (var letter in word)
                {
                    if (!char.IsUpper(letter))
                    {
                        isUpper = false;
                        break;
                    }                        

                    isUpper = true;
                }

                if (isUpper) yield return word;
            }
        }
    }
}
