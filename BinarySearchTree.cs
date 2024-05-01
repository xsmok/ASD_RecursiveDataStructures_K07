using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_RecursiveDataStructures_K07
{
	public class BinarySearchTree
	{
		private class Node
		{
			public int Key;
			public int Value;
			public Node? Less, Greater;

			public Node Clone()
			{
				return new Node { Key = Key, Value = Value, Less = Less, Greater = Greater };
			}

			public Node? this[int key]
			{
				get
				{
					if (key < Key)
					{
						return Less;
					}
					if (key > Key)
					{
						return Greater;
					}
					return null;
				}
				set
				{
					if (key < Key)
					{
						Less = value;
					}
					if (key > Key)
					{
						Greater = value;
					}
				}
			}
			public void ForeachRecursive(Action<int, int> action)
			{
				if (Less != null)
				{
					Less.ForeachRecursive(action);
				}
				action(Key, Value);
				if (Greater != null)
				{
					Greater.ForeachRecursive(action);
				}
			}
		}

		private Node root = new Node { Key = int.MinValue, Less = null, Greater = null };

		public bool Add(int key, int value)
		{
			Node current = root;
			while (current[key] != null)
			{
				current = current[key];
			}
			if (current.Key == key)
			{
				return false;
			}
			var added = new Node { Key = key, Value = value };
			current[key] = added;
			return true;
		}

		public bool Remove(int key)
		{
			Node current = root;
			while (current[key] != null && current[key].Key != key)
			{
				current = current[key];
			}
			if (current[key] == null)
			{
				return false;
			}
			//if current[key].Key == key
			if (current[key].Less == null || current[key].Greater == null)
			{
				current[key] = current[key].Less ?? current[key].Greater;
				return true;
			}
			// if current[key].Less != null && current[key].Greater != null
			Node max = current[key].Less;
			while (max.Greater != null)
			{
				max = max.Greater;
			}
			// w max już na pewno w tym miejscu jest element maksymalny z tego poddrzewa
			Remove(max.Key);
			current[key].Key = max.Key;
			current[key].Value = max.Value;
			return true;
		}

		public int this[int key]
		{
			get
			{
				Node current = root;
				while (current[key] != null)
				{
					current = current[key];
				}
				if (current.Key != key)
				{
					throw new KeyNotFoundException();
				}
				return current.Value;
			}
			set
			{
				Node current = root;
				while (current[key] != null)
				{
					current = current[key];
				}
				if (current.Key != key)
				{
					throw new KeyNotFoundException();
				}
				current.Value = value;
			}
		}

		public void ForeachRecursive(Action<int, int> action)
		{
			if (root[0] != null)
			{
				root[0].ForeachRecursive(action);
			}
		}

		public void Foreach(Action<int, int> action)
		{
			Stack<Node> stack = new Stack<Node>();
			if (root[0] != null)
			{
				stack.Push(root[0].Clone());
			}
			while (stack.Count > 0)
			{
				var current = stack.Pop();
				if (current.Less != null)
				{
					stack.Push(current);
					stack.Push(current.Less.Clone());
					current.Less = null;
					continue;
				}
				action(current.Key, current.Value);
				if (current.Greater != null)
				{
					stack.Push(current.Greater.Clone());
				}
			}
		}
	}
}