using System;
using System.Collections.Generic;
using Xunit;

// https://www.interviewcake.com/question/csharp/nth-fibonacci?section=dynamic-programming-recursion&course=fc1


namespace fibonacci_recursion_memoization
{

    public class Solution
    {
        
        private static Dictionary<int,int> memo = new Dictionary<int,int>();
        
        
        public static int Fib(int n)
        {
            // Compute the nth Fibonacci number
            if (n < 0)
            {
                throw new ArgumentException();
            }
            
            if (n <= 1)
            {
                return n;
            }
            
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            
            int result = Fib(n-1) + Fib(n-2);
            memo.Add(n, result);
            return result;
        }


        // Tests

        [Fact]
        public void ZerothFibonacciTest()
        {
            var actual = Fib(0);
            var expected = 0;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstFibonacciTest()
        {
            var actual = Fib(1);
            var expected = 1;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SecondFibonacciTest()
        {
            var actual = Fib(2);
            var expected = 1;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThirdFibonacciTest()
        {
            var actual = Fib(3);
            var expected = 2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FifthFibonacciTest()
        {
            var actual = Fib(5);
            var expected = 5;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TenthFibonacciTest()
        {
            var actual = Fib(10);
            var expected = 55;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NegativeFibonacciTest()
        {
            Assert.Throws<ArgumentException>(() => Fib(-1));
        }

    }
}