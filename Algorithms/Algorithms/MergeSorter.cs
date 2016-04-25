using System;
using System.Linq;

namespace Raff.Algorithms
{
    public class MergeSorter<T> : Sorter<T> where T : IComparable<T>
    {

        private T[] _providedList;

        public MergeSorter(T[] providedList)
        {
            _providedList = providedList;
        }

        public T[] Sort()
        {
            return Sort(_providedList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputList"></param>
        /// <returns></returns>
        private T[] Sort(T[] list)
        {
            // Edge cases 
            if (ListSmallEnoughToReturn(list))
                return list;

            var leftArray = GetLeftHalfOf(list);
            var rightArray = GetRightHalfOf(list);

            var leftArraySorted = Sort(leftArray);
            var rightArraySorted = Sort(rightArray);

            return MergeSortMerge(leftArraySorted, rightArraySorted);
        }

        private bool ListSmallEnoughToReturn(T[] list)
        {
            return list.Length < 2;
        }

        private T[] GetLeftHalfOf(T[] list)
        {
            var midpoint = list.Length / 2;
            return list.Take(midpoint).ToArray();
        }

        private T[] GetRightHalfOf(T[] list)
        {
            var midpoint = list.Length / 2;
            return list.Skip(midpoint).ToArray();
        }

        // Merge sort - the merge part
        // We assume here that the input arrays are sorted.
        // Undefined behavior if they are not!
        private static T[] MergeSortMerge(T[] leftArray, T[] rightArray)
        {
            // Edge case - either input is empty
            if (leftArray.Length == 0)
                return rightArray;
            if (rightArray.Length == 0)
                return leftArray;

            var result = new T[leftArray.Length + rightArray.Length];

            var leftCounter = 0;
            var rightCounter = 0;
            var resultCounter = 0;

            while (leftCounter < leftArray.Length && rightCounter < rightArray.Length)
            {
                var leftValue = leftArray[leftCounter];
                var rightValue = rightArray[rightCounter];

                if (leftValue.CompareTo(rightValue) < 0)
                {
                    result[resultCounter++] = leftValue;
                    leftCounter++;
                }
                else if (leftValue.CompareTo(rightValue) > 0)
                {
                    result[resultCounter++] = rightValue;
                    rightCounter++;
                }
                else
                {
                    result[resultCounter++] = leftValue;
                    result[resultCounter++] = rightValue;
                    leftCounter++;
                    rightCounter++;
                }
            }

            // Out of the while loop, we've hit the endpoint of one of our arrays
            if (leftCounter == leftArray.Length)
            {
                while (rightCounter < rightArray.Length)
                {
                    result[resultCounter++] = rightArray[rightCounter];
                    rightCounter++;
                }
            }
            else
            {
                while (leftCounter < leftArray.Length)
                {
                    result[resultCounter++] = leftArray[leftCounter];
                    leftCounter++;
                }
            }

            return result;
        }
    }
}
