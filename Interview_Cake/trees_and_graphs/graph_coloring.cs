using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace graph_coloring
{
    public class Solution
    {
        public class GraphNode
        {
            public string Label { get; }
            public ISet<GraphNode> Neighbors { get; }
            public string Color { get; set; }
            public bool HasColor { get { return Color != null; } }

            public GraphNode(string label)
            {
                Label = label;
                Neighbors = new HashSet<GraphNode>();
            }

            public void AddNeighbor(GraphNode neighbor)
            {
                Neighbors.Add(neighbor);
            }
        }

        public static void ColorGraph(GraphNode[] graph, String[] colors)
        {
            // Create a valid coloring for the graph
            foreach(var node in graph)
            {
                if (node.Neighbors.Contains(node))
                {
                    throw new ArgumentException("");
                }
                
                HashSet<string> usedColors = new HashSet<string>();
                
                foreach(var neighbor in node.Neighbors)
                {
                    usedColors.Add(neighbor.Color);
                }
                
                foreach(var color in colors)
                {
                    if (!usedColors.Contains(color))
                    {
                        node.Color = color;
                        break;
                    }
                }

            }
            
            return;

        }


















        // Tests

        [Fact]
        public void LineGraphTest()
        {
            var nodeA = new GraphNode("A"); 
            var nodeB = new GraphNode("B"); 
            var nodeC = new GraphNode("C"); 
            var nodeD = new GraphNode("D");
            nodeA.AddNeighbor(nodeB);
            nodeB.AddNeighbor(nodeA);
            nodeB.AddNeighbor(nodeC);
            nodeC.AddNeighbor(nodeB);
            nodeC.AddNeighbor(nodeD);
            nodeD.AddNeighbor(nodeC);
            var graph = new GraphNode[] {nodeA, nodeB, nodeC, nodeD};
            ColorGraph(graph, GetColors());
            ValidateGraphColoring(graph);
        }

        [Fact]
        public void SeparateGraphTest()
        {
            var nodeA = new GraphNode("A"); 
            var nodeB = new GraphNode("B"); 
            var nodeC = new GraphNode("C"); 
            var nodeD = new GraphNode("D");
            nodeA.AddNeighbor(nodeB);
            nodeB.AddNeighbor(nodeA);
            nodeC.AddNeighbor(nodeD);
            nodeD.AddNeighbor(nodeC);
            var graph = new GraphNode[] {nodeA, nodeB, nodeC, nodeD};
            ColorGraph(graph, GetColors());
            ValidateGraphColoring(graph);
        }

        [Fact]
        public void TriangleGraphTest()
        {
            var nodeA = new GraphNode("A"); 
            var nodeB = new GraphNode("B"); 
            var nodeC = new GraphNode("C"); 
            nodeA.AddNeighbor(nodeB);
            nodeA.AddNeighbor(nodeC);
            nodeB.AddNeighbor(nodeA);
            nodeB.AddNeighbor(nodeC);
            nodeC.AddNeighbor(nodeA);
            nodeC.AddNeighbor(nodeB);
            var graph = new GraphNode[] {nodeA, nodeB, nodeC};
            ColorGraph(graph, GetColors());
            ValidateGraphColoring(graph);
        }

        [Fact]
        public void envelopeGraphTest()
        {
            var nodeA = new GraphNode("A"); 
            var nodeB = new GraphNode("B"); 
            var nodeC = new GraphNode("C"); 
            var nodeD = new GraphNode("D");
            var nodeE = new GraphNode("E");
            nodeA.AddNeighbor(nodeB);
            nodeA.AddNeighbor(nodeC);
            nodeB.AddNeighbor(nodeA);
            nodeB.AddNeighbor(nodeC);
            nodeB.AddNeighbor(nodeD);
            nodeB.AddNeighbor(nodeE);
            nodeC.AddNeighbor(nodeA);
            nodeC.AddNeighbor(nodeB);
            nodeC.AddNeighbor(nodeD);
            nodeC.AddNeighbor(nodeE);
            nodeD.AddNeighbor(nodeB);
            nodeD.AddNeighbor(nodeC);
            nodeD.AddNeighbor(nodeE);
            nodeE.AddNeighbor(nodeB);
            nodeE.AddNeighbor(nodeC);
            nodeE.AddNeighbor(nodeD);
            var graph = new GraphNode[] {nodeA, nodeB, nodeC, nodeD, nodeE};
            ColorGraph(graph, GetColors());
            ValidateGraphColoring(graph);
        }

        [Fact]
        public void LoopGraphTest()
        {
            var nodeA = new GraphNode("A"); 
            nodeA.AddNeighbor(nodeA);
            var graph = new GraphNode[] {nodeA};
            Assert.Throws<ArgumentException>(() => ColorGraph(graph, GetColors()));
        }

        static string[] GetColors()
        {
            return new string[] { "Red", "Green", "Blue", "Orange", "Yellow", "White" };
        }

        static void ValidateGraphColoring(GraphNode[] graph)
        {
            var nonColoredNode = graph.FirstOrDefault(n => !n.HasColor);
            if (nonColoredNode != null)
            {
                Fail($"Found non-colored node {nonColoredNode.Label}");
            }

            int maxDegree = 0;
            var usedColors = new HashSet<string>();

            foreach (var node in graph)
            {
                maxDegree = Math.Max(maxDegree, node.Neighbors.Count);
                usedColors.Add(node.Color);
            }

            var allowedColorCount = maxDegree + 1;

            if (usedColors.Count > allowedColorCount)
            {
                Fail("Too many colors:"
                    + $" {allowedColorCount} allowed, but {usedColors.Count} actually used");
            }

            foreach (var node in graph)
            {
                var neighbor = node.Neighbors.FirstOrDefault(n => n.Color == node.Color);
                if (neighbor != null)
                {
                    Fail($"Neighbor nodes {node.Label} and {neighbor.Label}"
                        + $" have the same color {node.Color}");
                }
            }
        }

        static void Fail(string message)
        {
            Assert.True(false, message);
        }


    }

}