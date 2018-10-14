using System;
using System.Collections.Generic;
using Xunit;

// https://www.interviewcake.com/question/csharp/merge-sorted-arrays?section=array-and-string-manipulation&course=fc1


namespace merge_sorted_lists
{
    public class Solution
    {
        public static int[] MergeArrays(int[] myArray, int[] alicesArray)
        {
            // Combine the sorted arrays into one large sorted array
            
            
            //List<int> mergedList = new List<int>();
            int[] mergedList = new int[myArray.Length + alicesArray.Length];
            int myIndex = 0;
            int alicesIndex = 0;
            
            
            for (int i = 0; i < (myArray.Length + alicesArray.Length); i++)
            {
                if ((myIndex < myArray.Length) && ((alicesIndex >= alicesArray.Length) || 
                myArray[myIndex] < alicesArray[alicesIndex]))
                {
                    //mergedList.Add(myArray[myIndex]);
                    mergedList[i] = myArray[myIndex];
                    myIndex ++;
                }
                else
                {
                    //mergedList.Add(alicesArray[alicesIndex]);
                    mergedList[i] = alicesArray[alicesIndex];
                    alicesIndex++;
                }
            }
            
            //return mergedList.ToArray();
            return mergedList;
            
            
            
            //return new int[] {};
        }



        // Tests

        [Fact]
        public void BothArraysAreEmptyTest()
        {
            var myArray = new int[] { };
            var alicesArray = new int[] { };
            var expected = new int[] { };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstArrayIsEmptyTest()
        {
            var myArray = new int[] { };
            var alicesArray = new int[] { 1, 2, 3 };
            var expected = new int[] { 1, 2, 3 };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SecondArrayIsEmptyTest()
        {
            var myArray = new int[] { 5, 6, 7 };
            var alicesArray = new int[] { };
            var expected = new int[] { 5, 6, 7 };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BothArraysHaveSomeNumbersTest()
        {
            var myArray = new int[] { 2, 4, 6 };
            var alicesArray = new int[] { 1, 3, 7 };
            var expected = new int[] { 1, 2, 3, 4, 6, 7 };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ArraysAreDifferentLengthsTest()
        {
            var myArray = new int[] { 2, 4, 6, 8 };
            var alicesArray = new int[] { 1, 7 };
            var expected = new int[] { 1, 2, 4, 6, 7, 8 };
            var actual = MergeArrays(myArray, alicesArray);
            Assert.Equal(expected, actual);
        }

        
    }
}