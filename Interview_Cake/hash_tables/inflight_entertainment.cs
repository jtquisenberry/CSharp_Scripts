using System;
using System.Collections.Generic;
using Xunit;

// https://www.interviewcake.com/question/csharp/inflight-entertainment?course=fc1&section=hashing-and-hash-tables

namespace inflight_entertainment
{

    public class Solution
    {
        public static bool CanTwoMoviesFillFlight(int[] movieLengths, int flightLength)
        {
            // Determine if two movies add up to the flight length
            
            if (movieLengths.Length < 2)
            {
                //throw new ArgumentException("At least two movies are required");
                return false;
            }
            
            
            HashSet<int> seenMovies = new HashSet<int>();
            
            foreach(int movieLength in movieLengths)
            {
                
                int matchingLength = flightLength - movieLength;
                if (seenMovies.Contains(matchingLength))
                {
                    return true;
                }

                // Add to list of seen movies after looking for 
                // complementary movie.
                seenMovies.Add(movieLength);

            }

            return false;
        }



        // Tests

        [Fact]
        public void ShortFlightTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 2, 4 }, 1);
            Assert.False(result);
        }

        [Fact]
        public void LongFlightTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 2, 4 }, 6);
            Assert.True(result);
        }

        [Fact]
        public void OnlyOneMovieHalfFlightLenghtTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 3, 8 }, 6);
            Assert.False(result);
        }

        [Fact]
        public void TwoMoviesHalfFlightLengthTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 3, 8, 3 }, 6);
            Assert.True(result);
        }

        [Fact]
        public void LotsOfPossiblePairsTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 1, 2, 3, 4, 5, 6 }, 7);
            Assert.True(result);
        }

        [Fact]
        public void NotUsingFirstMovieTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 4, 3, 2 }, 5);
            Assert.True(result);
        }

        [Fact]
        public void OneMovieTest()
        {
            var result = CanTwoMoviesFillFlight(new int[] { 6 }, 6);
            Assert.False(result);
        }

        [Fact]
        public void NoMoviesTest() 
        {
            var result = CanTwoMoviesFillFlight(new int[] { }, 6);
            Assert.False(result);
        }
    
    }

}