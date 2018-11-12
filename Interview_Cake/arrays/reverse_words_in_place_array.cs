using System;
using Xunit;

// https://www.interviewcake.com/question/csharp/reverse-words?section=array-and-string-manipulation&course=fc1

// Reverse the whole array to get the words in the right order.
// Reverse each word to get the letters in the right order.

// Space = O(1)
// Time = O(n), Go through entire list twice.

namespace reverse_words_in_place_array
{
    public class Solution
    {
        
        public static void ReverseLetters(char[] message, int start, int end)
        {
            while (start < end)
            {
                char temp = message[start];
                message[start] = message[end];
                message[end] = temp;
                start += 1;
                end -= 1;
            }
        }
        
        
        public static void ReverseWords(char[] message)
        {
            // Decode the message by reversing the words
            
            int start = 0;
            int end = message.Length - 1;
            
            // Reverse entire array.
            ReverseLetters(message, start, end);
            
            for(int i = 0; i < message.Length; i++)
            {
                char character = message[i];
                if (character == ' ')
                {
                    end = i - 1;
                    ReverseLetters(message, start, end);
                    start = i + 1;
                }
                else if (i == message.Length - 1)
                {
                    end = i;
                    ReverseLetters(message, start, end);
                    start = i + 1;
                }
                
            }
            
            return;

        }

        // Tests

        [Fact]
        public void OneWordTest()
        {
            var expected = "vault".ToCharArray();
            var actual = "vault".ToCharArray();
            ReverseWords(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoWordsTest()
        {
            var expected = "cake thief".ToCharArray();
            var actual = "thief cake".ToCharArray();
            ReverseWords(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeWordsTest()
        {
            var expected = "get another one".ToCharArray();
            var actual = "one another get".ToCharArray();
            ReverseWords(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultipleWordsSameLengthTest()
        {
            var expected = "the cat ate the rat".ToCharArray();
            var actual = "rat the ate cat the".ToCharArray();
            ReverseWords(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultipleWordsDifferentLengthsTest()
        {
            var expected = "chocolate bundt cake is yummy".ToCharArray();
            var actual = "yummy is cake bundt chocolate".ToCharArray();
            ReverseWords(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EmptyStringTest()
        {
            var expected = "".ToCharArray();
            var actual = "".ToCharArray();
            ReverseWords(actual);
            Assert.Equal(expected, actual);
        }


    }
}