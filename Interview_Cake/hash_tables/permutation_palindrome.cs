using System;
using System.Collections.Generic;
using Xunit;

// https://www.interviewcake.com/question/csharp/permutation-palindrome?section=hashing-and-hash-tables&course=fc1

namespace permutation_palidromes
{
    public class Solution
    {
        public static bool HasPalindromePermutation(string theString)
        {
            // Check if any permutation of the input is a palindrome
            
            
            HashSet<char> seenCharacters = new HashSet<char>();
            
            
            
            foreach(char c in theString)
            {
                if (seenCharacters.Contains(c))
                {
                    seenCharacters.Remove(c);
                }
                else
                {
                    seenCharacters.Add(c);
                }
                
            }
            
            
            
            return seenCharacters.Count <= 1;
            
            
            

            //return false;
        }


















        // Tests

        [Fact]
        public void PermutationWithOddNumberOfCharsTest()
        {
            var result = HasPalindromePermutation("aabcbcd");
            Assert.True(result);
        }

        [Fact]
        public void PermutationWithEvenNumberOfCharsTest()
        {
            var result = HasPalindromePermutation("aabccbdd");
            Assert.True(result);
        }

        [Fact]
        public void NoPermutationWithOddNumberOfChars()
        {
            var result = HasPalindromePermutation("aabcd");
            Assert.False(result);
        }

        [Fact]
        public void NoPermutationWithEvenNumberOfCharsTest()
        {
            var result = HasPalindromePermutation("aabbcd");
            Assert.False(result);
        }

        [Fact]
        public void EmptyStringTest()
        {
            var result = HasPalindromePermutation("");
            Assert.True(result);
        }

        [Fact]
        public void OneCharacterStringTest()
        {
            var result = HasPalindromePermutation("a");
            Assert.True(result);
        }
        
    }
}