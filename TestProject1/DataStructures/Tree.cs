using System.Collections.Generic;
using System.Linq;

namespace TestProject1.DataStructures
{
    public class Tree
    {
        public TreeNode Root { get; set; }

        private IEnumerable<TreeNode> Children()
        {
            var nodes = new Stack<TreeNode>();
            nodes.Push(Root);
            while (nodes.Any())
            {
                var node = nodes.Pop();
                yield return node;
                foreach (var nodeChild in node.Children) nodes.Push(nodeChild);
            }
        }

        public TreeNode Find(int value)
        {
            return Children().First(node => node.Value == value);
        }
    }

    public class TreeNode
    {
        public readonly int Value;
        private TreeNode Parent { get; set; }
        public readonly List<TreeNode> Children = new();

        public TreeNode(int value)
        {
            Value = value;
        }
    }
}