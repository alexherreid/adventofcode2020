using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public static class Day1
	{
		public static void Day1_Puzzle1()
		{
			Console.Clear();
			Console.WriteLine("Day 1 Challenge 1 Summary: Elves accounting expense report.");
			Console.WriteLine("Given a list of int's find the two values that add up to 2020 and then multiple them by each other.");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): List of int (\"expenses\") of length N");
			Console.WriteLine("***********************");
			Console.WriteLine();

			Console.WriteLine("Paste (or type) a list of int's with one per line. Any line that has other characters will be discarded. Processing stops when an empty line is detected.");
			Console.WriteLine("Expenses:");

			List<int> rawExpenses = new List<int>();
			string line;
			while ((line = Console.ReadLine()) != null)
			{
				if (string.IsNullOrEmpty(line))
				{
					break;
				}
				else
				{
					if (int.TryParse(line.Trim(), out int exp))
					{
						rawExpenses.Add(exp);
					}
				}
			}

			Console.WriteLine($"Inputs complete, found {rawExpenses.Count} expenses");
			if (rawExpenses.Count > 0)
			{
				//Find the two on the list that total 2020
				List<Tuple<int, int>> sumTo2020 = new List<Tuple<int, int>>();
				int[] expenses = rawExpenses.ToArray();

				//Loop through each item in the array
				for (int i = 0; i < expenses.Length; i++)
				{
					//and for each item in the array, go through the array to sum them up
					//skip the case where i == j as that is just summing the same item twice
					for (int j = 0; j < expenses.Length; j++)
					{
						if (i != j && (expenses[i] + expenses[j] == 2020))
						{
							//Don't add it if there's already the inverse of the list (from when we went through the list the other way)
							if (sumTo2020.Count(x => x.Item2 == expenses[i] && x.Item1 == expenses[j]) == 0)
							{
								sumTo2020.Add(new Tuple<int, int>(expenses[i], expenses[j]));
							}
						}
					}
				}

				//There will be two of everything at this point, since i, j and j, i will both be on the list
				sumTo2020 = sumTo2020.Distinct().ToList();

				int possibleSumTo2020 = sumTo2020.Count;
				Console.WriteLine($"Found {possibleSumTo2020} total possibilities");
				if (sumTo2020.Count > 0)
				{
					Console.WriteLine($"The multiplication of these comes out to: {sumTo2020.First().Item1 * sumTo2020.First().Item2}");
					if (sumTo2020.Count > 1)
					{
						Console.WriteLine("CAUTION: MULTIPLE MATCHES");
						foreach (Tuple<int, int> s2020 in sumTo2020)
						{
							Console.WriteLine($"The multiplication of one option comes out to: {s2020.Item1 * s2020.Item2}");
						}
					}
				}
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}

		public static void Day1_Puzzle2()
		{
			Console.Clear();
			Console.WriteLine("Day 1 Challenge 2 Summary: Elves accounting expense report.");
			Console.WriteLine("Given a list of int's find the three values that add up to 2020 and then multiple them by one another.");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): List of int (\"expenses\") of length N");
			Console.WriteLine("***********************");
			Console.WriteLine();

			Console.WriteLine("Paste (or type) a list of int's with one per line. Any line that has other characters will be discarded. Processing stops when an empty line is detected.");
			Console.WriteLine("Expenses:");

			List<int> rawExpenses = new List<int>();
			string line;
			while ((line = Console.ReadLine()) != null)
			{
				if (string.IsNullOrEmpty(line))
				{
					break;
				}
				else
				{
					if (int.TryParse(line.Trim(), out int exp))
					{
						rawExpenses.Add(exp);
					}
				}
			}

			Console.WriteLine($"Inputs complete, found {rawExpenses.Count} expenses");
			if (rawExpenses.Count > 0)
			{
				//Find the three on the list that total 2020
				List<Tuple<int, int, int>> sumTo2020 = new List<Tuple<int, int, int>>();
				int[] expenses = rawExpenses.ToArray();

				//Loop through each item in the array
				for (int i = 0; i < expenses.Length; i++)
				{
					//and for each item in the array, go through the array to sum them up
					//skip the case where i == j as that is just summing the same item twice
					for (int j = 0; j < expenses.Length; j++)
					{
						for (int k = 0; k < expenses.Length; k++)
						{
							if (expenses[i] + expenses[j] + expenses[k] == 2020)
							{
								sumTo2020.Add(new Tuple<int, int, int>(expenses[i], expenses[j], expenses[k]));
							}
						}
					}
				}

				int possibleSumTo2020 = sumTo2020.Count;
				Console.WriteLine($"Found {possibleSumTo2020} total possibilities (including dupes)");
				if (sumTo2020.Count > 0)
				{
					List<int> multiplicationResults = new List<int>();

					foreach (Tuple<int, int, int> options in sumTo2020)
					{
						multiplicationResults.Add(options.Item1 * options.Item2 * options.Item3);
					}

					//de-dupe
					multiplicationResults = multiplicationResults.Distinct().ToList();

					if (multiplicationResults.Count > 1)
					{
						Console.WriteLine("CAUTION: MULTIPLE MATCHES");
						foreach (int r in multiplicationResults)
						{
							Console.WriteLine($"The multiplication of one option comes out to: {r}");
						}
					}
					else
					{
						Console.WriteLine("Result is: " + multiplicationResults.First());
					}
				}
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}
	}
}