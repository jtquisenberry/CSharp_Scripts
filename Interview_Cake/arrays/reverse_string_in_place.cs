using System;
using Xunit;

namespace reverse_string_in_place
{
    public class UnitTest1
    {

        public static void Reverse(char[] arrayOfChars) 
        {
            // Reverse input array of characters in place
            int leftIndex = 0;
            int rightIndex = arrayOfChars.Length - 1;

            while (leftIndex < rightIndex)
            {
                // Swap Characters
                char temp = arrayOfChars[leftIndex];
                arrayOfChars[leftIndex] = arrayOfChars[rightIndex];
                arrayOfChars[rightIndex] = temp;
                
                leftIndex += 1;
                rightIndex -= 1;
            }
        }


        // Tests

        [Fact]
        public void EmptyStringTest()
        {
            var expected = "".ToCharArray();
            var actual = "".ToCharArray();
            Reverse(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SingleCharacterStringTest()
        {
            var expected = "A".ToCharArray();
            var actual = "A".ToCharArray();
            Reverse(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LongerStringTest()
        {
            var expected = "EDCBA".ToCharArray();
            var actual = "ABCDE".ToCharArray();
            Reverse(actual);
            Assert.Equal(expected, actual);
        }
    }
}
