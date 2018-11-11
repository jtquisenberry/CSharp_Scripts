using System;
using Xunit;

// https://www.interviewcake.com/question/python/find-rotation-point?course=fc1&section=sorting-searching-logarithms


namespace find_rotation_point
{
    public class Solution
    {

        public static int FindRotationPoint(String[] words)
        {
            // Find the rotation point in the array
 
            string first_word = words[0];
            
            int floor_index = 0;
            int ceiling_index = words.Length - 1;
            
            while (floor_index +1 < ceiling_index)
            {
                var midpoint = floor_index + (ceiling_index - floor_index) / 2;
                
                
                if (String.Compare(words[midpoint], first_word) >= 0)
                {
                    // At the rotation point, the word is the lowest word in the list.
                    // If the current word is greater or equal to the first word, then
                    // it is not the lowest word. Continue looking in the right half.
                    
                    floor_index = midpoint;
                }
                else
                {
                    // Look in the left side of the midpoint.
                    ceiling_index = midpoint;
                }
            }
            
            return ceiling_index;
        }



        // Tests

        [Fact]
        public void SmallArrayTest()
        {
            var actual = FindRotationPoint(new string[] { "cape", "cake" });
            var expected = 1;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MediumArrayTest()
        {
            var actual = FindRotationPoint(new string[] { "grape", "orange", "plum", "radish",
                "apple" });
            var expected = 4;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LargeArrayTest()
        {
            var actual = FindRotationPoint(
                new string[] { "ptolemaic", "retrograde", "supplant", "undulate", "xenoepist",
                "asymptote", "babka", "banoffee", "engender", "karpatka", "othellolagkage" });
            var expected = 5;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PossiblyMissingEdgeCaseTest()
        {
            // Are we missing any edge cases?
        }


    }
}