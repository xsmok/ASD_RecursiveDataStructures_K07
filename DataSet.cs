using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASD_RecursiveDataStructures_K07
{
	public class DataSet
	{
		private Random random = new Random();

		public int[] GenerateRandom(int n)
		{
			HashSet<int> uniqueNumbers = new HashSet<int>();
			while (uniqueNumbers.Count < n)
			{
				int randomNumber = random.Next(int.MinValue, int.MaxValue);
				if (!uniqueNumbers.Contains(randomNumber))
				{
					uniqueNumbers.Add(randomNumber);
				}
			}

			return uniqueNumbers.ToArray();
		}


		public int[] Order(int[] numbers, bool ascending = true)
		{
			if (ascending)
			{
				return numbers.OrderBy(n => n).ToArray();
			}

			return numbers.OrderByDescending(n => n).ToArray();
		}

		public int[] VShape(int[] numbers)
		{
			int halfLength = numbers.Length / 2;
			int[] firstHalf = new int[halfLength];
			int[] secondHalf = new int[numbers.Length - halfLength];
			Array.Copy(numbers, 0, firstHalf, 0, halfLength);
			Array.Copy(numbers, halfLength, secondHalf, 0, numbers.Length - halfLength);

			firstHalf = Order(firstHalf, true);
			secondHalf = Order(secondHalf, false);

			int[] result = new int[numbers.Length];
			Array.Copy(firstHalf, result, halfLength);
			Array.Copy(secondHalf, 0, result, halfLength, secondHalf.Length);

			return result;
		}


		public int[] PickRandom(int[] numbers, int n)
		{
			HashSet<int> pickedNumbers = new HashSet<int>();
			while (pickedNumbers.Count < n)
			{
				int index = random.Next(0, numbers.Length);
				if (!pickedNumbers.Contains(numbers[index])) {
					pickedNumbers.Add(numbers[index]);
				}
			}
			return pickedNumbers.ToArray();
		}
	}
}