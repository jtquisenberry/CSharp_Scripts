using System;
using System.Collections.Generic;
using Xunit;

// https://www.interviewcake.com/question/csharp/recursive-string-permutations?section=dynamic-programming-recursion&course=fc1

namespace recursive_string_permutations
{
    public class Solution
    {
        public static ISet<string> GetPermutations(String inputString) 
        {
            // Generate all permutations of the input string
            
            if (inputString.Length <= 1)
            {
                return new HashSet<string>() {inputString};
            }
            
            
            var lastChar = inputString.Substring(inputString.Length -1);
            var allOthers = inputString.Substring(0,inputString.Length -1);
            
            var permutationsPreviousRounds = GetPermutations(allOthers);
            HashSet<string> permutationsCurrent = new HashSet<string>();
            
            foreach(var permutation in permutationsPreviousRounds)
            {
                for (var i = 0; i < permutation.Length + 1; i++)
                {
                    var start = permutation.Substring(0,i);
                    var end = permutation.Substring(i);
                    var current = start + lastChar + end;
                    permutationsCurrent.Add(current);
                }
            }
            
            
            

            return permutationsCurrent;
        }




        // Tests

        [Fact]
        public void EmptyStringTest()
        {
            var expected = new HashSet<string>() { "" };
            var actual = GetPermutations("");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneCharacterStringTest()
        {
            var expected = new HashSet<string>() { "a" };
            var actual = GetPermutations("a");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoCharacterStringTest()
        {
            var expected = new HashSet<string>() { "ab", "ba" };
            var actual = GetPermutations("ab");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeCharacterStringTest()
        {
            var expected = new HashSet<string>() { "abc", "acb", "bac", "bca", "cab", "cba" };
            var actual = GetPermutations("abc");
            Assert.Equal(expected, actual);
        }

    }
}