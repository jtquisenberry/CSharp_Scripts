using System;
using System.Collections.Generic;
using Xunit;


// https://www.interviewcake.com/question/csharp/reverse-words?section=array-and-string-manipulation&course=fc1
// Solution with Queue method.

namespace reverse_words_in_place_stack 
{
    public class Solution
    {
        public static void ReverseWords(char[] message)
        {
            // Decode the message by reversing the words
            
            
            List<char> current_word = new List<char>();
            Stack<char> all_words = new Stack<char>();
            
            
            for (int i = 0; i < message.Length; i++)
            {
                char character = message[i];
                
                if (character != ' ')
                {
                    current_word.Add(character);
                }
                
                if (character == ' ' || i == (message.Length - 1))
                {
                    for (int j = current_word.Count - 1; j > -1; j--)
                    {
                        char current_character = current_word[j];
                        all_words.Push(current_character);
                    }

                    current_word.Clear();

                    if (character == ' ')
                    {
                        all_words.Push(' ');
                    }


                }
            }

            for (int i = 0; i < message.Length; i++)
            {
                message[i] = all_words.ToArray()[i];
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