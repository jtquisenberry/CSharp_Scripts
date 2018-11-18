using System;
using Xunit;

// https://www.interviewcake.com/question/python/coin?section=dynamic-programming-recursion&course=fc1
// Iterative method
// Time O(n*m): n = amount, m = number of denominations.
// Space O(n):

namespace making_change_iterative
{
    public class Solution 
    {
        public static int ChangePossibilities(int amount, int[] denominations)
        {
            // Calculate the number of ways to make change

            int[] waysToMakeAmounts = new int[amount + 1];

            waysToMakeAmounts[0] = 1;
            

            foreach (int coin in denominations)
            {
                for (int interimAmount = 0; interimAmount < amount + 1; interimAmount++)
                {
                    if (coin <= interimAmount)
                    {
                        waysToMakeAmounts[interimAmount] += waysToMakeAmounts[interimAmount - coin];
                    }
                    
                }
                
                // Console.WriteLine("[" + String.Join(",", waysToMakeAmounts) + "]");

            }

            return waysToMakeAmounts[amount];
            
        }





        // Tests

        [Fact]
        public void SampleInputTest()
        {
            var actual = ChangePossibilities(4, new int[] { 1, 2, 3 });
            var expected = 4;
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void OneWayToMakeZeroCentsTest()
        {
            var actual = ChangePossibilities(0, new int[] { 1, 2 });
            var expected = 1;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NoWaysIfNoCoinsTest()
        {
            var actual = ChangePossibilities(1, new int[] { });
            var expected = 0;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BigCoinValueTest()
        {
            var actual = ChangePossibilities(5, new int[] { 25, 50 });
            var expected = 0;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BigTargetAmountTest()
        {
            var actual = ChangePossibilities(50, new int[] { 5, 10 });
            var expected = 6;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ChangeForOneDollarTest()
        {
            var actual = ChangePossibilities(100, new int[] { 1, 5, 10, 25, 50 });
            var expected = 292;
            Assert.Equal(expected, actual);
        }

    }
}