using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD_RecursiveDataStructures_K07
{


	public class Experiment
    {
		private Stopwatch stopWatch = new Stopwatch();
		private DataSet dataSet = new DataSet();
		private int[] randomNumbers;
		private int[] pickedNumbers;
		private int[] ascendingNumbers;
		private int[] descendingNumbers;
		private int[] vShapeNumbers;
		private dynamic structure;
        
		public void LoadData(int n)
		{
			stopWatch.Start();
			randomNumbers = dataSet.GenerateRandom(n);
			pickedNumbers = dataSet.PickRandom(randomNumbers, n);
			ascendingNumbers = dataSet.Order(randomNumbers, true);
			descendingNumbers = dataSet.Order(randomNumbers, false);
			vShapeNumbers = dataSet.VShape(randomNumbers);
			stopWatch.Stop();

			Console.WriteLine($"Time taken to generate dataset: {stopWatch.Elapsed}");
		}

		public void Perform<T>() where T : new()
		{
			structure = new T();
			Console.WriteLine($"{structure} - randomNumbers");
			ExperimentAdd(randomNumbers);
			ExperimentRead();
			ExperimentReadAll();
			ExperimentRemove();

			structure = new T();
			Console.WriteLine($"{structure} - ascendingNumbers");
			ExperimentAdd(ascendingNumbers);
			ExperimentRead();
			ExperimentReadAll();
			ExperimentRemove();

			structure = new T();
			Console.WriteLine($"{structure} - descendingNumbers");
			ExperimentAdd(descendingNumbers);
			ExperimentRead();
			ExperimentReadAll();
			ExperimentRemove();

			structure = new T();
			Console.WriteLine($"{structure} - vShapeNumbers");
			ExperimentAdd(vShapeNumbers);
			ExperimentRead();
			ExperimentReadAll();
			ExperimentRemove();
		}

		private void ExperimentAdd(int[] numbers)
		{
			stopWatch.Restart();
			foreach (int num in numbers)
			{
				structure.Add(num, 0);
			}
			stopWatch.Stop();
			Console.WriteLine($"Time taken to add: {stopWatch.Elapsed}");
		}

		private void ExperimentRead()
		{
			int placeholder = 0;
			stopWatch.Restart();
			foreach (int num in pickedNumbers)
			{
				placeholder = structure[num];
			}
			stopWatch.Stop();
			Console.WriteLine($"Time taken to read: {stopWatch.Elapsed}");
		}

		private void ExperimentReadAll()
		{
			int placeholder = 0;
			stopWatch.Restart();

			if (structure is SortedSinglyLinkedList)
			{
				SortedSinglyLinkedList list = structure;
				list.Foreach((key, value) => { placeholder = key; });
			}

			if (structure is BinarySearchTree)
			{
				BinarySearchTree list = structure;
				list.Foreach((key, value) => { placeholder = key; });
			}

			stopWatch.Stop();
			Console.WriteLine($"Time taken to read all: {stopWatch.Elapsed}");
		}

		private void ExperimentRemove()
		{
			stopWatch.Restart();
			foreach (int num in pickedNumbers)
			{
				structure.Remove(num);
			}
			stopWatch.Stop();
			Console.WriteLine($"Time taken to remove: {stopWatch.Elapsed}");
		}


	}
}