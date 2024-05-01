using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_RecursiveDataStructures_K07
{
	public class SortedSinglyLinkedList
	{
		// int <- klucz
		// int 
		// Node node = null;// = new Node();
		// 
		private class Node
		{
			public int key;
			public int value;
			public Node? next;
		}

		private Node head = new Node { key = int.MinValue, next = null };

		public bool Add(int key, int value)
		{
			Node? current = head;
			while (current.next != null && current.next.key < key)
			{
				current = current.next;
			}
			if (current.next != null && current.next.key == key)
				return false;
			Node added = new Node { key = key, value = value, next = current.next };
			current.next = added;
			return true;
		}
		public bool Remove(int key)
		{
			Node? current = head;
			while (current.next != null && current.next.key < key)
			{
				current = current.next;
			}
			if (current.next == null || current.next.key > key)
				return false;
			current.next = current.next.next;
			return true;
		}

		public int this[int key]
		{
			get
			{
				Node? current = head;
				while (current.next != null && current.next.key < key)
				{
					current = current.next;
				}
				if (current.next == null || current.next.key > key)
					throw new KeyNotFoundException();
				return current.next.value;
			}
			set
			{
				Node? current = head;
				while (current.next != null && current.next.key < key)
				{
					current = current.next;
				}
				if (current.next == null || current.next.key > key)
					throw new KeyNotFoundException();
				current.next.value = value;
			}
		}

		public void Foreach(Action<int, int> action)
		{
			Node? current = head;
			while (current.next != null)
			{
				action(current.next.key, current.next.value);
				current = current.next;
			}
		}
	}
}