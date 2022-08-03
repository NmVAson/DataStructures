using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;
using TestProject1.DataStructures;

namespace TestProject1
{
	[TestFixture]
	public class DataStructuresTests
	{
		//https://docs.microsoft.com/en-us/dotnet/standard/collections/
		[Test]
		public void ShouldSearchTree()
		{
			var leftNode = new TreeNode(2);
			leftNode.Children.Add(new TreeNode(4));
			var rightNode = new TreeNode(3);
			var expectedSearchNode = new TreeNode(5);
			rightNode.Children.Add(expectedSearchNode);
			rightNode.Children.Add(new TreeNode(6));
			
			var root = new TreeNode(1);
			root.Children.Add(leftNode);
			root.Children.Add(rightNode);
			
			var generalTree = new Tree
			{
				Root = root
			};
			
			Assert.AreEqual(expectedSearchNode, generalTree.Find(5));
		}

		[Test]
		public void ShouldBuildDirectedGraph()
		{
			var graph = new DirectedGraph(3);
			graph.AddEdge(0,1, 10);
			graph.AddEdge(0,2, 0);
			graph.AddEdge(1,0, 1);
			graph.AddEdge(1,1, 0);
			graph.AddEdge(1,2, 1);
			graph.AddEdge(2,2, 2);

			Console.WriteLine(graph.ToString());
			Assert.AreEqual(10, graph.GetCost(0,1));
			Assert.IsNull(graph.GetCost(0,0));
		}

		[Test]
		public void ShouldBuildUndirectedGraph()
		{
			var graph = new UndirectedGraph();
			graph.AddConnection("IN", "KY", 0);
			graph.AddConnection("KY", "MD", 1);
			graph.AddConnection("IN", "MD", 2);
			
			Console.WriteLine(graph.ToString());
			Assert.AreEqual(2, graph.GetConnections("IN").Count);
			Assert.AreEqual(1, graph.GetConnections("KY").Count);
		}

		[Test]
		public void ShouldDetermineShortestPathForUndirectedGraph()
		{
			var graph = new UndirectedGraph();
			graph.AddConnection("0", "1", null);
			graph.AddConnection("1", "2", null);
			graph.AddConnection("1", "3", null);
			graph.AddConnection("3", "4", null);
			graph.AddConnection("4", "5", null);
			graph.AddConnection("5", "6", null);
			graph.AddConnection("6", "2", null);
			graph.AddConnection("2", "1", null);
			
			Assert.AreEqual(3, graph.CalculateShortestPath("0", "4"));
		}

		[Test]
		public void ShouldRemoveDupesFromHashSet()
		{
			var hashSet = new HashSet<int> { 0, 1, 2, 3, 2, 1 };
			
			Assert.AreEqual(4, hashSet.Count);

			var otherHashSet = new HashSet<int> { 5 };
			hashSet.UnionWith(otherHashSet);
			
			Assert.AreEqual(5, hashSet.Count);
			Assert.IsTrue(hashSet.Contains(5));
		}

		public class LinearDataStructures
		{
			private Array _array = Array.Empty<int>();
			private LinkedList<int> _linkedList = new();
			private Stack<int> _stack = new();
			private Queue<int> _queue = new();
			
		}

		public class NonLinearDataStructures
		{
			private Tree _tree = new();
			private DirectedGraph _directedGraph = new(0);
			private UndirectedGraph _undirectedGraph = new();
			private Dictionary<int, int> _hashTable = new();
			private HashSet<int> _hashSet = new();
		}
	}
}