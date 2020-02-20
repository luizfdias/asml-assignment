using Runner.Interfaces;
using System;

namespace Runner
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
