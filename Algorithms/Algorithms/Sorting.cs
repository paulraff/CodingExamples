using System.Linq;

namespace Raff.Algorithms
{
    public class Sorting
    {
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
                    result[resultCounter] = rightArray[rightCounter];
                    rightCounter++;
                }
            }
            else
            {
                while (leftCounter < leftArray.Length)
                {
                    result[resultCounter] = leftArray[leftCounter];
                    leftCounter++;
                }
            }

            return result;
        }
    }
}
