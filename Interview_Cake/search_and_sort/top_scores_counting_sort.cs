using System;
using Xunit;

// https://www.interviewcake.com/question/csharp/top-scores?course=fc1&section=sorting-searching-logarithms

namespace top_scores_counting_sort
{
    public class Solution
    {
        public static int[] SortScores(int[] unorderedScores, int highestPossibleScore)
        {
            // Sort the scores in O(n) time
            
            
            int[] scoreCounts = new int[highestPossibleScore + 1];
            foreach (int score in unorderedScores)
            {
                scoreCounts[score] ++;
            }
            

            int[] sortedScores = new int[unorderedScores.Length];
            int sortedIndex = 0;
            
            for (int score = highestPossibleScore; score > -1; score--)
            {
                int countOfScore = scoreCounts[score];
                for (int instance = 0; instance < countOfScore; instance++)
                {
                    sortedScores[sortedIndex] = score;
                    sortedIndex ++;
                }
                
            }

            return sortedScores;
        }



        // Tests

        [Fact]
        public void NoScoresTest()
        {
            var scores = new int[] { };
            var expected = new int[] { };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneScoreTest()
        {
            var scores = new int[] { 55 };
            var expected = new int[] { 55 };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoScoresTest()
        {
            var scores = new int[] { 30, 60 };
            var expected = new int[] { 60, 30 };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ManyScoresTest()
        {
            var scores = new int[] { 37, 89, 41, 65, 91, 53 };
            var expected = new int[] { 91, 89, 65, 53, 41, 37 };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RepeatedScoresTest()
        {
            var scores = new int[] { 20, 10, 30, 30, 10, 20 };
            var expected = new int[] { 30, 30, 20, 20, 10, 10 };
            var actual = SortScores(scores, 100);
            Assert.Equal(expected, actual);
        }

    }
}