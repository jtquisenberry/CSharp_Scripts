using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// https://www.interviewcake.com/question/csharp/mesh-message?section=trees-graphs&course=fc1

// Bredth first to find shortest path.

// Time = O(N + M). N = number of nodes. M = number of neighbors.
// Space = O(N)


namespace mesh_network {
    public class Solution
    {
        
        public static string[] ReconstructPath(Dictionary<string, string> howWeGotHere,
            string startNode, string endNode)
        {

            var reversedPath = new List<string>();
            
            var node = endNode;
            while (node != null)
            {
                reversedPath.Add(node);
                node = howWeGotHere[node];
            }
            
            reversedPath.Reverse();
            return reversedPath.ToArray();
            
            
        }

        
        
        
        public static string[] GetPath(Dictionary<String, String[]> graph, 
                                    string startNode, string endNode)
        {
            // Find the shortest route in the network between the two users
            
            if (!graph.ContainsKey(startNode))
            {
                throw new ArgumentException("startNode not in graph");
            }
            
            if (!graph.ContainsKey(endNode))
            {
                throw new ArgumentException("endNode not in graph");
            }
            
            
            var nodesToVisit = new Queue<string>();
            nodesToVisit.Enqueue(startNode);
            
            var howWeReachedNodes = new Dictionary<string, string>();
            howWeReachedNodes.Add(startNode, null);
            
            while (nodesToVisit.Count > 0)
            {
                
                var currentNode = nodesToVisit.Dequeue();
                
                if (currentNode == endNode)
                {
                    return ReconstructPath(howWeReachedNodes, startNode, endNode);
                }
                
                foreach(var neighbor in graph[currentNode])
                {
                    if (!howWeReachedNodes.ContainsKey(neighbor))
                    {
                        howWeReachedNodes.Add(neighbor, currentNode);
                        nodesToVisit.Enqueue(neighbor);
                    }
                    
                    
                    
                    
                    
                }
                
                
                
                
                
                
            }
            
            return null;
            

        }




        // Tests

        [Fact]
        public void TwoHopPath1Test()
        {
            var expected = new string[] { "a", "c", "e" };
            var actual = GetPath(GetNetwork(), "a", "e");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoHopPath2Test()
        {
            var expected = new string[] { "d", "a", "c" };
            var actual = GetPath(GetNetwork(), "d", "c");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneHopPath1Test()
        {
            var expected = new string[] { "a", "c" };
            var actual = GetPath(GetNetwork(), "a", "c");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneHopPath2Test()
        {
            var expected = new string[] { "f", "g" };
            var actual = GetPath(GetNetwork(), "f", "g");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneHopPath3Test()
        {
            var expected = new string[] { "g", "f" };
            var actual = GetPath(GetNetwork(), "g", "f");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ZeroHopPath()
        {
            var expected = new string[] { "a" };
            var actual = GetPath(GetNetwork(), "a", "a");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NoPathTest()
        {
            var actual = GetPath(GetNetwork(), "a", "f");
            Assert.Null(actual);
        }

        [Fact]
        public void StartNodeNotPresentTest()
        {
            Assert.Throws<ArgumentException>(() => GetPath(GetNetwork(), "h", "a"));
        }

        [Fact]
        public void EndNodeNotPresentTest()
        {
            Assert.Throws<ArgumentException>(() => GetPath(GetNetwork(), "a", "h"));
        }

        private static Dictionary<string, string[]> GetNetwork()
        {
            return new Dictionary<string, string[]>()
            {
                { "a", new string[] { "b", "c", "d"} },
                { "b", new string[] { "a", "d" } },
                { "c", new string[] { "a", "e" } },
                { "d", new string[] { "a", "b" } },
                { "e", new string[] { "c" } },
                { "f", new string[] { "g" } },
                { "g", new string[] { "f" } },
            };
        }

    }
}