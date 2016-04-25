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
        private static T[] MergeSortMerge<T>(T[] leftArray, T[] rightArray) where T: System.IComparable<T>
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

        // Merge sort - specific to integers
        public static int[] MergeSort(int[] inputList)
        {
            var inputListLength = inputList.Length;
            // Edge cases: 0 and 1 
            if (inputListLength < 2)
                return inputList;

            // Since length will be at least 2, then this will be at least 1
            var midpoint = inputListLength / 2;

            var leftArray  = inputList.Take(midpoint).ToArray();
            var rightArray = inputList.Skip(midpoint).ToArray();

            var leftArraySorted  = MergeSort(leftArray);
            var rightArraySorted = MergeSort(rightArray);

            return MergeSortMerge(leftArraySorted, rightArraySorted);
        }

        // Merge sort - the merge part
        // We assume here that the input arrays are sorted.
        // Undefined behavior if they are not!
        private static int[] MergeSortMerge(int[] leftArray, int[] rightArray)
        {
            // Edge case - either input is empty
            if (leftArray.Length == 0)
                return rightArray;
            if (rightArray.Length == 0)
                return leftArray;

            var result = new int[leftArray.Length + rightArray.Length];

            var leftCounter = 0;
            var rightCounter = 0;
            var resultCounter = 0;

            while (leftCounter < leftArray.Length && rightCounter < rightArray.Length)
            {
                var leftValue = leftArray[leftCounter];
                var rightValue = rightArray[rightCounter];

                if (leftValue < rightValue)
                {
                    result[resultCounter++] = leftValue;
                    leftCounter++;
                }
                else if (leftValue > rightValue)
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
