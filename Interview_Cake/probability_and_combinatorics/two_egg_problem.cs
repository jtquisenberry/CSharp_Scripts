using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// https://www.interviewcake.com/question/csharp/two-egg-problem?section=combinatorics-probability-math&course=fc1

// Two-egg problem.
// Identify the highest floor of a building such that dropping an egg from the floor will not result in a break. 
// You have too eggs. 
// The idea is to skip floors. 
// We can do better than the square root of the number of floors. 

// Consider 100 floors. At Math.Sqrt(100) = 10, the first egg is dropped 10 times at worst. The second egg may
// be dropped 9 times for a worst case drop count of 19. 

// Reduce the number of floors skipped when dropping the first egg to accommodate for the fact that the second
// egg is dropped an additional time.


namespace mesh_network {
    public class Solution
    {
        
        public static double GetEggDropsGivenFloors(int floors = 0)
        {
            // Reduce the number of floors skipped with the first egg by one each time the first egg does 
            // not break. This is because we want the number of drops of both eggs to remain constant. 
            
            // Triangular series
            // n+(n−1)+(n−2)+…+1=floor

            // (n^2 + n) / 2 = floor
            // n^2 + n - 2*floor
            // = -1 +- 
            
            // Quadratic formula
            //answer = (-b +- Math.Sqrt(b^2-4ac)) / (2 * a);
            
            double answer1 = (-1 + Math.Sqrt(Math.Pow(1,2) - 4 * 1 * (-2 * floors))) / (2 * 1);
            double answer2 = (-1 - Math.Sqrt(Math.Pow(1,2) - 4 * 1 * (-2 * floors))) / (2 * 1);

            return answer1;
   
        }


        // Tests

        [Fact]
        public void Floor100()
        {
            double expected = 13.650971698084906;
            var actual = GetEggDropsGivenFloors(100);
            Assert.Equal(expected, actual);
        }

    }
}