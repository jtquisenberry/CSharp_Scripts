using System;
using Xunit;

// https://www.interviewcake.com/question/python/simulate-5-sided-die?course=fc1&section=combinatorics-probability-math

namespace simulate_rand5_with_rand7
{
    public class Solution
    {
        static Random _rand = new Random();

        static int Rand7()
        {
            return _rand.Next(7) + 1;
        }

        public static int Rand5()
        {
            // Implement Rand5() using Rand7()
            
            
            int result = int.MaxValue;
            
            while (result > 5)
            {
                result = Rand7();
            }

            return result;
        }

        [Fact]
        public static void RollDice()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{Rand5()} ");
            }
            Console.WriteLine();
        }
    }

}