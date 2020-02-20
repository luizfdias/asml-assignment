using System;

namespace SequenceAnalysis.Interfaces
{
    public interface ISorter<T> where T : IComparable<T>, IComparable
    {
        T Sort(T input);
    }
}
