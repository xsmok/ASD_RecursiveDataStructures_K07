using ASD_RecursiveDataStructures_K07;

Experiment experiment = new Experiment();

int[] testCases = new int[] {10000, 50000, 100000};

foreach (int n in testCases)
{
	for (int i = 1; i <= 5; i++)
	{
		Console.WriteLine($"[TEST] n:{n} - {i}");

		experiment.LoadData(n);

		experiment.Perform<SortedSinglyLinkedList>();

		experiment.Perform<BinarySearchTree>();
	}
}