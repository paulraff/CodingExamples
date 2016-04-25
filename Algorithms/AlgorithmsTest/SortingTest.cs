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
        public void merge_sort_three_element_list()
        {
            int[] input = { 5, 6, 7 };

            int[] actual = Sorting.MergeSort(input);
            int[] expected = { 5, 6, 7 };

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void merge_sort_ten_element_list()
        {
            int[] input = { 9, 8, 7, 6, 5, 5, 4, 3, 2, 1 };

            int[] actual = Sorting.MergeSort(input);
            int[] expected = { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9 };

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
