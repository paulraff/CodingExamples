using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Class that implements streaming subset
    // It implements the following functions:
    //   Give - Gives it an element
    //   GetSubset - returns a random subset of the elements that were given already. 
    // It instantiates with an integer n, which is the size of the subset
    // If we don't have n elements given to it yet, then it will return what has been given so far.
    public class StreamingSubset<T>
    {
        private Random _rand;
        private List<T> _subset;
        private int _size;
        private int _seen;

        public StreamingSubset(int n, int? seed = null)
        {
            if (seed.HasValue)
            {
                _rand = new Random(seed.Value);
            }
            else
            {
                _rand = new Random();
            }
            _subset = new List<T>();
            _size = n;
            _seen = 0;
        }

        public void Give(T item)
        {
            _seen++;

            // Easy part - if our subset isn't big enough yet. 
            if (_subset.Count < _size)
            {
                _subset.Add(item);
                return;
            }

            // Else - we need to do some work
            // First, this object should have probability (n/_seen) to be included
            var flip = _rand.NextDouble();
            if (flip < ((double)_size) / ((double)_seen))
            {
                // Now we select a random element of the _subset to kick out
                var toKickOut = _rand.Next(_size);
                _subset[toKickOut] = item;
            }
        }

        public List<T> GetSubset()
        {
            return _subset;
        }
    }
}
