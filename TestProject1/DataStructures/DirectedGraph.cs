using System;
using System.Text;

namespace TestProject1.DataStructures
{
	public class DirectedGraph
	{
		private Edge[,] _adjacencyMatrix;

		public DirectedGraph(int size)
		{
			_adjacencyMatrix = new Edge[size, size];
		}

		public void AddEdge(int fromNode, int toNode, int cost)
		{
			_adjacencyMatrix[fromNode, toNode] = new Edge(fromNode, toNode, cost);
		}

		public override string ToString()
		{
			var print = new StringBuilder();
			foreach (var edge in _adjacencyMatrix)
			{
				print.AppendLine(edge == null ? "X" : $"{edge.FromIndex} -> {edge.ToIndex}: {edge.Cost}");
			}

			return print.ToString();
		}

		public int? GetCost(int fromNode, int toNode)
		{
			return _adjacencyMatrix[fromNode, toNode]?.Cost;
		}
		
		private class Edge
		{
			public readonly int FromIndex;
			public readonly int ToIndex;
			public readonly int Cost;

			public Edge(int fromIndex, int toIndex, int cost)
			{
				FromIndex = fromIndex;
				ToIndex = toIndex;
				Cost = cost;
			}
		}
	}

}