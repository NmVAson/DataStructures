using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject1.DataStructures
{
	public class UndirectedGraph
	{
		private readonly Dictionary<string, List<Edge>> _adjacencyList = new();
		private readonly List<(string, string)> _tuples = new();

		public void AddConnection(string fromNode, string toNode, int? cost)
		{
			_tuples.Add((fromNode, toNode));
			
			var isExistingNode = _adjacencyList.TryGetValue(fromNode, out var existingEdges);
			var edge = new Edge(toNode, cost);

			if (isExistingNode)
			{
				existingEdges.Add(edge);
			}
			else
			{
				_adjacencyList.Add(fromNode, new List<Edge> { edge });
			}
		}

		public override string ToString()
		{
			var list = _tuples.GroupBy(t => t.Item1).Select(group => new { group.Key, Value = group.Select(item => item.Item2).ToList()});
			var s = new StringBuilder();
			
			foreach (var node in list)
			{
				s.AppendLine($"{node.Key}: {string.Join(",", node.Value)}");
			}

			return s.ToString();
		}

		public ICollection<Edge> GetConnections(string node)
		{
			_adjacencyList.TryGetValue(node, out var edges);

			return edges;
		}

		public int CalculateShortestPath(string fromNode, string toNode)
		{
			var paths = GetPaths(fromNode, toNode);

			return paths.Select(p => p.Count).Min();
		}

		private List<List<(string, string)>> GetPaths(string fromNode, string destinationNode)
		{
			var currentNode = fromNode;
			var nodes = _tuples.FindAll(i => i.Item1.Equals(currentNode));
			var paths = new List<List<(string, string)>>();
			foreach (var node in nodes)
			{
				var list = new List<(string, string)>() { node };
				var childNodes = _tuples.FindAll(i => i.Item1.Equals(node.Item2));
				foreach (var child in childNodes)
				{
					list.Append(child);
				}
				paths.Add(list);
			}
			return paths;
		}
	}

	public class Edge
	{
		private readonly string _adjacentNode;
		private readonly  int? _cost;

		public Edge(string adjacentNode, int? cost)
		{
			_cost = cost;
			_adjacentNode = adjacentNode;
		}

		public string GetDestinationNode()
		{
			return _adjacentNode;
		}

		public override string ToString()
		{
			return $"{_adjacentNode}(${_cost})";
		}
	}
}