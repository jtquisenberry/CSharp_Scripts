using System;
using Xunit;

// https://www.interviewcake.com/question/python/simulate-7-sided-die?section=combinatorics-probability-math&course=fc1


namespace simulate_rand7_with_rand5
{
    public class Solution
    {
        static Random _rand = new Random();

        static int Rand5()
        {
            return _rand.Next(5) + 1;
        }

        public static int Rand7()
        {
            // Implement Rand7() using Rand5()
            

            int whichCombination = int.MaxValue;
            
            while (whichCombination > 21)
            {
                
                int roll1 = Rand5();
                int roll2 = Rand5(); 
                
                // Think of the roll of two dice as a two-digit number
                // with a number base equal to the number of sides of a die.
                // When rolling five-sided dice, think of base 5, where two digits
                // encode 25 possible values with the highest value as 44 which equals 
                // 24 in base 10.
                
                // Change that rolls so that the lowest value is 0. 
                // A roll of 1,1 encodes 00. 
                // The problem requires the lowest value to be 1, so add one.
                
                whichCombination = (roll1 - 1) * 5 + (roll2 - 1) + 1;
                
                // When divided by 7, the remainder ranges from 0 to 6. Add one to change the
                // range to 1..7
                
                
                return whichCombination % 7 + 1;
                
            }
            
            return -1;
            
        }

        [Fact]
        public void EndNodeNotPresentTest()
        {
            int actual = Rand7();
            //int expected = 0;
            Console.WriteLine(actual);
          

        }
    }
}