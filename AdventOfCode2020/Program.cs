using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	class Program
	{
		public enum DayPuzzleType
		{
			Puzzle1,
			Puzzle2
		}

		static void Main(string[] args)
		{
			//Christmas colors, of course
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.DarkRed;

			Console.WriteLine("Alex Herreid's solutions to the 2020 Advent of Code");
			Console.WriteLine("***********************");
			Console.WriteLine("Challenges received from https://adventofcode.com/2020/about");
			Console.WriteLine("***********************");
			Console.WriteLine("Challenge copyright original creator, solution copyright Alex Herreid");
			Console.WriteLine("***********************");
			Console.WriteLine("Based on the website description, the goal of the program is to practice coding and collect stars."
			+ " As they write: \"To save your vacation, you need to get all fifty stars by December 25th.\""
			+ " There are two puzzles per day, worth one star each. The full challenge text is not copied here, instead " +
			"there is just a brief summary on the top of each day of what the code is supposed to do.");

			bool quit = false;
			while (!quit)
			{
				Console.WriteLine("***********************");
				Console.WriteLine();
				Console.WriteLine("Main Menu: (Q to quit)");
				Console.WriteLine("Type in the day number to go to that challenge/solution combo.");
				Console.Write("Day Number: ");
				string input = Console.ReadLine()?.ToUpper();
				if (input == "Q")
				{
					quit = true;
				}
				else
				{
					bool validDay = true;
					if (int.TryParse(input, out int dayNum))
					{
						switch (dayNum)
						{
							case 1:
								DayPuzzleType? dpt = DayPuzzleSelector(dayNum);
								switch (dpt)
								{
									case DayPuzzleType.Puzzle1:
										Day1_Puzzle1();
										break;
									case DayPuzzleType.Puzzle2:

										break;
								}
								break;
							default:
								validDay = false;
								break;
						}
					}
					else
					{
						validDay = false;
					}

					if (!validDay)
					{
						Console.Clear();
						Console.WriteLine("Invalid selection, please try again");
						Console.WriteLine();
					}
				}
			}
		}

		static DayPuzzleType? DayPuzzleSelector(int dayNum)
		{
			DayPuzzleType? returnValue = null;
			Console.WriteLine("----");
			bool validPuzzle = false;
			while (!validPuzzle)
			{
				Console.WriteLine($"Okay, Day {dayNum} it is! Do you want the first or second puzzle of this day?");
				Console.Write("Type puzzle one (1) or two (2) or back (B):");
				string input = Console.ReadLine()?.ToUpper();

				if (int.TryParse(input, out int puzzNum))
				{
					switch (puzzNum)
					{
						case 1:
							returnValue = DayPuzzleType.Puzzle1;
							validPuzzle = true;
							break;
						case 2:
							returnValue = DayPuzzleType.Puzzle2;
							validPuzzle = true;
							break;
					}
				}
				else if (input == "B")
				{
					validPuzzle = true;
				}

				if (!validPuzzle)
				{
					Console.Clear();
					Console.WriteLine("Invalid selection, please try again");
					Console.WriteLine();
				}
			}

			return returnValue;
		}

		static void Day1_Puzzle1()
		{
			Console.Clear();
			Console.WriteLine("Day 1 Challenge Summary: Elves accounting expense report.");
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
	}
}
