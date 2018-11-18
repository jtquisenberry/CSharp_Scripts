using System;
using Xunit;

// https://www.interviewcake.com/question/python/cake-thief?course=fc1&section=dynamic-programming-recursion

// There are unlimited cakes. Each cake is a tuple of (weight, value)
// There is a knapsack of finite capacity. Find the greatest aggregate value of cakes
// that fit in the knapsack.//
// Time: O(n * k) n is number of types of cake and k is the capacity of the knapsack
// Space O(k)

namespace unbounded_knapsack_cake_thief
{
    public class Solution {

        public class CakeType
        {
            public readonly int Weight;
            public readonly int Value;

            public CakeType(int weight, int value)
            {
                Weight = weight;
                Value  = value;
            }
        }

        public static long MaxDuffelBagValue(CakeType[] cakeTypes, int weightCapacity)
        {
            // Calculate the maximum value that we can carry
            
            int[] maxValuesAtCapacities = new int[weightCapacity + 1];
            
            for (int capacity = 0; capacity < weightCapacity + 1; capacity ++)
            {
                
                int maxWeightAtCapacity = 0;

                foreach(var cake in cakeTypes)
                {
                    int weight = cake.Weight;
                    int value = cake.Value;
                    
                    if (weight <= capacity)
                    {

                        if (weight == 0 && value > 0)
                        {
                            throw new Exception("Infinity");
                        }
                        
                        int maxValueWithCake = value + maxValuesAtCapacities[capacity - weight];
                        maxWeightAtCapacity = Math.Max(maxValueWithCake, maxWeightAtCapacity);
                    
                    }
                }

                maxValuesAtCapacities[capacity] = maxWeightAtCapacity;

            }
            
            return maxValuesAtCapacities[weightCapacity];
            
        }


















        // Tests

        [Fact]
        public void OneCakeTest()
        {
            CakeType[] cakeTypes = new[] { new CakeType(2, 1) };
            var weightCapacity = 9;
            var expected = 4L;
            var actual = MaxDuffelBagValue(cakeTypes, weightCapacity);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoCakesTest()
        {
            CakeType[] cakeTypes = new[] { new CakeType(4, 4), new CakeType(5, 5) };
            var weightCapacity = 9;
            var expected = 9L;
            var actual = MaxDuffelBagValue(cakeTypes, weightCapacity);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnlyTakeLessValuableCakeTest()
        {
            CakeType[] cakeTypes = new[] { new CakeType(4, 4), new CakeType(5, 5) };
            var weightCapacity = 12;
            var expected = 12L;
            var actual = MaxDuffelBagValue(cakeTypes, weightCapacity);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LotsOfCakesTest()
        {
            CakeType[] cakeTypes = new[]
            {
                new CakeType(2, 3), new CakeType(3, 6), new CakeType(5, 1),
                new CakeType(6, 1), new CakeType(7, 1), new CakeType(8, 1)
            };
            var weightCapacity = 7;
            var expected = 12L;
            var actual = MaxDuffelBagValue(cakeTypes, weightCapacity);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueToWeightRatioIsNotOptimalTest()
        {
            CakeType[] cakeTypes = new[] { new CakeType(51, 52), new CakeType(50, 50) };
            var weightCapacity = 100;
            var expected = 100L;
            var actual = MaxDuffelBagValue(cakeTypes, weightCapacity);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ZeroCapacityTest()
        {
            CakeType[] cakeTypes = new[] { new CakeType(1, 2) };
            var weightCapacity = 0;
            var expected = 0L;
            var actual = MaxDuffelBagValue(cakeTypes, weightCapacity);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CakeWithZeroValueAndWeightTest()
        {
            CakeType[] cakeTypes = new[] { new CakeType(0, 0), new CakeType(2, 1) };
            var weightCapacity = 7;
            var expected = 3L;
            var actual = MaxDuffelBagValue(cakeTypes, weightCapacity);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CakeWithNonZeroValueAndZeroWeightTest()
        {
            CakeType[] cakeTypes = new[] { new CakeType(0, 5) };
            var weightCapacity = 5;
            Assert.Throws<Exception>(() => MaxDuffelBagValue(cakeTypes, weightCapacity));
        }

    }
}