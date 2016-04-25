using System;

namespace Raff.Algorithms
{
    public interface Sorter<T> where T : IComparable<T>
    {
        T[] Sort();
    }
}
