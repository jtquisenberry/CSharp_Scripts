using System;
using Xunit;


// https://www.interviewcake.com/question/csharp/find-duplicate-optimize-for-space?course=fc1&section=sorting-searching-logarithms
// The array contains 1..n. More than one number may be duplicated.
// There may be gaps.


// Space = O(1)
// Time = O(n lg n)

namespace find_repeated_space_edition
{
    public class Solution
    {
        public static int FindRepeat(int[] theArray)
        {
            // Find a number that appears more than once
            
            // One is the lowest value because the problem states that the numbers
            // range from 1 to n.
            int floor = 1;
            
            // The problem states that the length of the array is n + 1, where n is
            // the highest number.
            int ceiling = theArray.Length - 1;
            
            while (floor < ceiling)
            {
                int midpoint = floor + (ceiling - floor) / 2;
                int lower_floor = floor;    
                int lower_ceiling = midpoint;
                int upper_floor = midpoint + 1;
                int upper_ceiling = ceiling;
                
                int max_distinct_values_in_lower = lower_ceiling - lower_floor + 1;
                int values_in_lower = 0;
                
                foreach(int number in theArray)
                {
                    if (number >= lower_floor && number <= lower_ceiling)
                    {
                        values_in_lower += 1;
                    }
                }
                
                if (values_in_lower > max_distinct_values_in_lower)
                {
                    // There must be a repeated number in the lower range.
                    // Reset floor and ceiling to bound the lower range.
                    floor = lower_floor;
                    ceiling = lower_ceiling;
                }
                else
                {
                    // Reset floor and ceiling to bound the upper range.
                    floor = upper_floor;
                    ceiling = upper_ceiling; 
                }
            }
            
            // floor and ceiling have converged.
            // Either one contains a repeated number.
            return floor;

        }




        // Tests

        [Fact]
        public void JustTheRepeatedNumberTest()
        {
            var numbers = new int[] { 1, 1 };
            var expected = 1;
            var actual = FindRepeat(numbers);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShortArrayTest()
        {
            var numbers = new int[] { 1, 2, 3, 2 };
            var expected = 2;
            var actual = FindRepeat(numbers);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MediumArrayTest()
        {
            var numbers = new int[] { 1, 2, 5, 5, 5, 5 };
            var expected = 5;
            var actual = FindRepeat(numbers);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LongArrayTest()
        {
            var numbers = new int[] { 4, 1, 4, 8, 3, 2, 7, 6, 5 };
            var expected = 4;
            var actual = FindRepeat(numbers);
            Assert.Equal(expected, actual);
        }


    }

}