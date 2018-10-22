using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

//https://www.interviewcake.com/question/csharp/bracket-validator?course=fc1&section=queues-stacks

namespace bracket_validator
{
    public class Solution
    {
        public static bool IsValid(string code)
        {
            // Determine if the input code is valid
            
            Dictionary<char,char> closers = new Dictionary<char, char>(){[')']='(', [']'] = '[', ['}'] ='{'};
            Stack<char> openers = new Stack<char>();
            
            foreach (char character in code)
            {
                
                if (closers.Keys.Contains(character))
                {
                    // closers
                    
                    if (openers.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        
                        if (openers.First() == closers[character])
                        {
                            // found a match
                            openers.Pop();
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
                else
                {
                    // openers
                    openers.Push(character);
                }
                
            }
            
            if (openers.Count > 0)
            {
                return false;
            }
            
            

            return true;
        }




        // Tests

        [Fact]
        public void ValidShortCodeTest()
        {
            var result = IsValid("()");
            Assert.True(result);
        }

        [Fact]
        public void ValidLongerCodeTest()
        {
            var result = IsValid("([]{[]})[]{{}()}");
            Assert.True(result);
        }

        [Fact]
        public void InterleavedOpenersAndClosersTest()
        {
            var result = IsValid("([)]");
            Assert.False(result);
        }

        [Fact]
        public void MismatchedOpenerAndCloserTest()
        {
            var result = IsValid("([][]}");
            Assert.False(result);
        }

        [Fact]
        public void MissingCloserTest()
        {
            var result = IsValid("[[]()");
            Assert.False(result);
        }

        [Fact]
        public void ExtraCloserTest()
        {
            var result = IsValid("[[]]())");
            Assert.False(result);
        }

        [Fact]
        public void EmptyStringTest()
        {
            var result = IsValid("");
            Assert.True(result);
        }

    }
}