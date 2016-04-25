using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTest
{
    /// <summary>
    /// Summary description for StreamingSubsetTest
    /// </summary>
    [TestClass]
    public class StreamingSubsetTest
    {
        public StreamingSubsetTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void random_subset_no_entries_gives_empty_output()
        {
            var randomSubset = new Algorithms.StreamingSubset<int>(10);

            var actual = randomSubset.GetSubset();
            int[] expected = { };

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void random_subset_less_than_capacity_gives_inputs_back()
        {
            var randomSubset = new Algorithms.StreamingSubset<int>(10);
            randomSubset.Give(5);
            randomSubset.Give(7);
            randomSubset.Give(9);

            var actual = randomSubset.GetSubset();
            int[] expected = { 5, 7, 9 };

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void random_subset_6_tries()
        {
            // Using seed 123 gives the following for the first 6 calls:
            // 0.984556915231308
            // 0.907815323168326
            // 0.743545518137303
            // 0.811641653446314
            // 0.738779145171297
            // 0.0483150165753043

            var randomSubset = new Algorithms.StreamingSubset<int>(1, 123);
            randomSubset.Give(1);   // Keep

            var actual = randomSubset.GetSubset();
            int[] expected = { 1 };

            actual.ShouldBeEquivalentTo(expected);

            randomSubset.Give(2);
            actual = randomSubset.GetSubset();
            expected[0] = 1;
            actual.ShouldBeEquivalentTo(expected);



        }
    }
}
