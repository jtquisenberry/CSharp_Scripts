using System;
using Xunit;

// https://www.interviewcake.com/question/csharp/single-riffle-check?course=fc1&section=array-and-string-manipulation

namespace single_riffle_shuffle
{
    public class Solution
    {
        public static bool IsSingleRiffle(int[] half1, int[] half2, int[] shuffledDeck)
        {
            // Check if the shuffled deck is a single riffle of the halves
            
            int half1_index = 0;
            int half2_index = 0;
            
            foreach (int card in shuffledDeck)
            {
                if (half1_index < half1.Length && card == half1[half1_index])
                {
                    half1_index++;
                }
                else if (half2_index < half2.Length && card == half2[half2_index])
                {
                    half2_index++;
                }
                else
                {
                    return false;
                }
                
            }

            return true;
        }


        // Tests

        [Fact]
        public void BothHalvesAreTheSameLengthTest()
        {
            var half1 = new int[] { 1, 4, 5 };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 1, 2, 3, 4, 5, 6 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.True(result);
        }

        [Fact]
        public void HalvesAreDifferentLengthsTest()
        {
            var half1 = new int[] { 1, 5 };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 1, 2, 6, 3, 5 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.False(result);
        }

        [Fact]
        public void OneHalfIsEmptyTest()
        {
            var half1 = new int[] { };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 2, 3, 6 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.True(result);
        }

        [Fact]
        public void ShuffledDeckIsMissingCardsTest()
        {
            var half1 = new int[] { 1, 5 };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 1, 6, 3, 5 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.False(result);
        }

        [Fact]
        public void ShuffledDeckHasExtraCards()
        {
            var half1 = new int[] { 1, 5 };
            var half2 = new int[] { 2, 3, 6 };
            var shuffledDeck = new int[] { 1, 2, 3, 5, 6, 8 };
            var result = IsSingleRiffle(half1, half2, shuffledDeck);
            Assert.False(result);
        }


    }

}