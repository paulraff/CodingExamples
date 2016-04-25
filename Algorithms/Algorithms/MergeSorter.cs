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
        private T[] MergeSortMerge(T[] leftHalf, T[] rightHalf)
        {
            // Edge case - either input is empty
            if (leftHalf.Length == 0)
                return rightHalf;
            if (rightHalf.Length == 0)
                return leftHalf;

            var mergedOutput = MergeUntilOneEmpty(leftHalf, rightHalf);

            // Out of the while loop, we've hit the endpoint of one of our arrays
            FinishMergeAfterOneEmpty(mergedOutput);

            return mergedOutput.merged;
        }

        private MergedArrayAndCounters MergeUntilOneEmpty(T[] leftHalf, T[] rightHalf)
        {
            var result = new T[leftHalf.Length + rightHalf.Length];

            var leftCounter = 0;
            var rightCounter = 0;
            var resultCounter = 0;

            while (leftCounter < leftHalf.Length && rightCounter < rightHalf.Length)
            {
                var leftValue = leftHalf[leftCounter];
                var rightValue = rightHalf[rightCounter];

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

            return new MergedArrayAndCounters()
            {
                left = leftHalf,
                right = rightHalf,
                merged = result,
                leftCounter = leftCounter,
                rightCounter = rightCounter,
                mergedCounter = resultCounter
            };

        }

        private void FinishMergeAfterOneEmpty(MergedArrayAndCounters mergedAndOneEmpty)
        {
            if (mergedAndOneEmpty.leftCounter == mergedAndOneEmpty.left.Length)
            {
                while (mergedAndOneEmpty.rightCounter < mergedAndOneEmpty.right.Length)
                {
                    mergedAndOneEmpty.merged[mergedAndOneEmpty.mergedCounter++] = mergedAndOneEmpty.right[mergedAndOneEmpty.rightCounter];
                    mergedAndOneEmpty.rightCounter++;
                }
            }
            else
            {
                while (mergedAndOneEmpty.leftCounter < mergedAndOneEmpty.left.Length)
                {
                    mergedAndOneEmpty.merged[mergedAndOneEmpty.mergedCounter++] = mergedAndOneEmpty.left[mergedAndOneEmpty.leftCounter];
                    mergedAndOneEmpty.leftCounter++;
                }
            }
        }

        internal class MergedArrayAndCounters
        {
            public T[] left { get; set; }
            public T[] right { get; set; }
            public T[] merged { get; set; }
            public int leftCounter { get; set; }
            public int rightCounter { get; set; }
            public int mergedCounter { get; set; }
        }

    }
}
