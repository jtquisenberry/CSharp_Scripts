using System;
using Xunit;

// https://www.interviewcake.com/question/csharp/nth-fibonacci?section=dynamic-programming-recursion&course=fc1

namespace fibonacci_iteration
{

    public class Solution
    {
        public static int Fib(int n)
        {
            // Compute the nth Fibonacci number
            
            if (n < 0)
            {
                throw new ArgumentException("My argument exception");
            }
            
            if (n <= 1)
            {
                return n;
            }
            
            int previous_2 = 0;
            int previous_1 = 1;
            int current = 1;
            
            for (int i = 2; i <= n; i++)
            {
                current = previous_2 + previous_1;
                previous_2 = previous_1;
                previous_1 = current;
            }
            
            return current;
            
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