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
        public void merge_sort_generic_empty_input_empty_output()
        {
            string[] input = { };

            string[] actual = Sorting.MergeSort(input);
            string[] expected = { };

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
        public void merge_sort_generic_one_element_input_same_output()
        {
            string[] input = { "fa" };

            string[] actual = Sorting.MergeSort(input);
            string[] expected = { "fa" };

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
        public void merge_sort_generic_two_elements_sorted_same_output()
        {
            string[] input = { "fa", "la" };

            string[] actual = Sorting.MergeSort(input);
            string[] expected = { "fa", "la" };

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
        public void merge_sort_generic_two_elements_sorts_correctly()
        {
            string[] input = { "la", "fa" };

            string[] actual = Sorting.MergeSort(input);
            string[] expected = { "fa", "la" };

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
        public void merge_sort_generic_three_element_list()
        {
            string[] input = { "ba", "fa", "la"};

            string[] actual = Sorting.MergeSort(input);
            string[] expected = { "ba", "fa", "la" };

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

        [TestMethod]
        public void merge_sort_generic_ten_element_list()
        {
            string[] input = { "do", "re", "mi", "fa", "so", "la", "ti", "do", "boo", "yah" };

            string[] actual = Sorting.MergeSort(input);
            string[] expected = { "do", "do", "fa", "la", "mi", "re", "so", "ti", "boo", "yah"};

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
