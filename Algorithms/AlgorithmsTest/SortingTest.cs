using Raff.Algorithms;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTest
{
    [TestClass]
    public class SortingTest
    {
        [TestMethod]
        public void merge_sort_empty_input_empty_output()
        {
            int[] input = { };

            int[] actual = Sorting.MergeSort(input);
            int[] expected = { };

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void merge_sort_one_element_input_same_output()
        {
            int[] input = { 4 };

            int[] actual = Sorting.MergeSort(input);
            int[] expected = { 4 };

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void merge_sort_two_elements_sorted_same_output()
        {
            int[] input = { 4, 8 };

            int[] actual = Sorting.MergeSort(input);
            int[] expected = { 4, 8 };

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void merge_sort_two_elements_sorts_correctly()
        {
            int[] input = { 8, 4 };

            int[] actual = Sorting.MergeSort(input);
            int[] expected = { 4, 8 };

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void merge_sort_ten_element_list()
        {
            int[] input = { 2, 1, 5, 6, 7, 9, 2, 5, 7, 1 };

            int[] actual = Sorting.MergeSort(input);
            int[] expected = { 1, 1, 2, 2, 5, 5, 6, 7, 7, 9 };

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
