using System;
using Xunit;

// https://www.interviewcake.com/question/csharp/temperature-tracker?course=fc1&section=general-programming
// Temperatures are integers in the range 0..110;

// Space = O(1)
// Time = O(1)

namespace temperature_tracker_greedy
{
    public class Solution
    {
        public class TempTracker
        {
            // Fill in the TempTracker class methods below
            
            int[] occurrences = new int[111];
            int maxOccurrences = 0;
            int? mode = null;
            
            int numberOfReadings = 0;
            int totalSum = 0;
            double? mean = null;
            
            int? maxTemp = null;
            int? minTemp =  null;
            

            // Records a new temperature
            public void Insert(int temperature)
            {
                // Mode
                occurrences[temperature] += 1;
                if (occurrences[temperature] > maxOccurrences)
                {
                    maxOccurrences = occurrences[temperature];
                    mode = temperature;
                }
                
                // Mean
                numberOfReadings += 1;
                totalSum += temperature;
                mean = 1.0 * totalSum / numberOfReadings;
                
                // Max
                if (maxTemp == null || temperature > maxTemp)
                {
                    maxTemp = temperature;
                }
                
                if (minTemp == null || temperature < minTemp)
                {
                    minTemp = temperature;
                }
                
            }

            // Returns the highest temp we've seen so far
            public int? GetMax()
            {
                return maxTemp;
            }

            // Returns the lowest temp we've seen so far
            public int? GetMin()
            {
                return minTemp;
            }

            // Returns the mean of all temps we've seen so far
            public double? GetMean()
            {
                return mean;
            }

            // Return a mode of all temps we've seen so far
            public int? GetMode()
            {
                return mode;
            }
        }

        // Tests

        [Fact]
        public void TemperatureTrackerTest()
        {
            var precision = 6;

            var t = new TempTracker();

            t.Insert(50);
            Assert.Equal(50, t.GetMax().Value);
            Assert.Equal(50, t.GetMin().Value);
            Assert.Equal(50.0, t.GetMean().Value, precision);
            Assert.Equal(50, t.GetMode().Value);

            t.Insert(80);
            Assert.Equal(80, t.GetMax().Value);
            Assert.Equal(50, t.GetMin().Value);
            Assert.Equal(65.0, t.GetMean().Value, precision);
            Assert.True(t.GetMode().Value == 50 || t.GetMode().Value == 80);

            t.Insert(80);
            Assert.Equal(80, t.GetMax().Value);
            Assert.Equal(50, t.GetMin().Value);
            Assert.Equal(70.0, t.GetMean().Value, precision);
            Assert.Equal(80, t.GetMode().Value);

            t.Insert(30);
            Assert.Equal(80, t.GetMax().Value);
            Assert.Equal(30, t.GetMin().Value);
            Assert.Equal(60.0, t.GetMean().Value, precision);
            Assert.Equal(80, t.GetMode().Value);
        }


    }
}