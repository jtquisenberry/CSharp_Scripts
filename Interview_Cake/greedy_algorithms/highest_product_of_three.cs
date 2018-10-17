using System;
using Xunit;

// https://www.interviewcake.com/question/csharp/highest-product-of-3?course=fc1&section=greedy

namespace highest_product_of_three
{
    public class Solution 
    {
        public static int HighestProductOf3(int[] arrayOfInts)
        {
            // Calculate the highest product of three numbers
            
            if (arrayOfInts.Length < 3)
            {
                throw new ArgumentException("At least three values are required.");
            }

            
            int highestOne = Math.Max(arrayOfInts[0], arrayOfInts[1]);
            int lowestOne = Math.Min(arrayOfInts[0], arrayOfInts[1]);
            
            int highestPair = arrayOfInts[0] * arrayOfInts[1];
            int lowestPair = arrayOfInts[0] * arrayOfInts[1];
            
            int bestTriple = arrayOfInts[0] * arrayOfInts[1] * arrayOfInts[2];
            
            for (int i = 2; i < arrayOfInts.Length; i++)
            {
                bestTriple = Math.Max(bestTriple, Math.Max(
                    arrayOfInts[i] * highestPair, arrayOfInts[i] * lowestPair));
                highestPair = Math.Max(highestPair, Math.Max(highestOne * arrayOfInts[i], 
                    lowestOne * arrayOfInts[i]));
                lowestPair = Math.Min(lowestPair, Math.Min(highestOne * arrayOfInts[i], 
                    lowestOne * arrayOfInts[i]));
                highestOne = Math.Max(highestOne, arrayOfInts[i]);
                lowestOne = Math.Min(lowestOne, arrayOfInts[i]);
                
            }
            
            return bestTriple;
            
        }

        // Tests

        [Fact]
        public void ShortArrayTest()
        {
            var actual = HighestProductOf3(new int[] { 1, 2, 3, 4 });
            var expected = 24;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LongerArrayTest()
        {
            var actual = HighestProductOf3(new int[] { 6, 1, 3, 5, 7, 8, 2 });
            var expected = 336;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ArrayHasOneNegativeTest()
        {
            var actual = HighestProductOf3(new int[] { -5, 4, 8, 2, 3 });
            var expected = 96;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ArrayHasTwoNegativesTest()
        {
            var actual = HighestProductOf3(new int[] { -10, 1, 3, 2, -10 });
            var expected = 300;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ArrayHasAllNegativesTest()
        {
            var actual = HighestProductOf3(new int[] { -5, -1, -3, -2 });
            var expected = -6;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExceptionWithEmptyArrayTest()
        {
            Assert.Throws<ArgumentException>(() => HighestProductOf3(new int[] { }));
        }

        [Fact]
        public void ExceptionWithOneNumberTest()
        {
            Assert.Throws<ArgumentException>(() => HighestProductOf3(new int[] { 1 }));
        }

        [Fact]
        public void ExceptionWithTwoNumbersTest()
        {
            Assert.Throws<ArgumentException>(() => HighestProductOf3(new int[] { 1, 1 }));
        }

    }
}