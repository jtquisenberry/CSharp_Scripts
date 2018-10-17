using System;
using Xunit;

// https://www.interviewcake.com/question/csharp/stock-price?section=greedy&course=fc1

namespace best_profit
{

    public class Solution
    {
        public static int GetMaxProfit(int[] stockPrices)
        {
            // Calculate the max profit
            if (stockPrices.Length < 2)
            {
                throw new ArgumentException("ae");
            }
            
            int lowestPrice = stockPrices[0];
            int bestProfit = stockPrices[1] - stockPrices[0];
            
            for (int i = 1; i < stockPrices.Length; i++)
            {
                int currentProfit = stockPrices[i] - lowestPrice;
                bestProfit = Math.Max(bestProfit, currentProfit);
                lowestPrice= Math.Min(lowestPrice, stockPrices[i]);
                
            }
            
            return bestProfit;
            
            
            
        }


        // Tests

        [Fact]
        public void PriceGoesUpThenDownTest()
        {
            var actual = GetMaxProfit(new int[] { 1, 5, 3, 2 });
            var expected = 4;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PriceGoesDownThenUpTest()
        {
            var actual = GetMaxProfit(new int[] { 7, 2, 8, 9 });
            var expected = 7;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PriceGoesUpAllDayTest()
        {
            var actual = GetMaxProfit(new int[] { 1, 6, 7, 9 });
            var expected = 8;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PriceGoesDownAllDayTest()
        {
            var actual = GetMaxProfit(new int[] { 9, 7, 4, 1 });
            var expected = -2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PriceStaysTheSameAllDayTest()
        {
            var actual = GetMaxProfit(new int[] { 1, 1, 1, 1 });
            var expected = 0;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExceptionWithOnePriceTest()
        {
            Assert.Throws<ArgumentException>(() => GetMaxProfit(new int[] { 5 }));
        }

        [Fact]
        public void ExceptionWithEmptyPricesTest()
        {
            Assert.Throws<ArgumentException>(() => GetMaxProfit(new int[] { }));
        }

    }

}