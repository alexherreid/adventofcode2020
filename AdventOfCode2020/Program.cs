using System;

namespace AdventOfCode2020
{
	static class Program
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
						DayPuzzleType? dpt = null;
						switch (dayNum)
						{
							case 1:
								dpt = DayPuzzleSelector(dayNum);
								switch (dpt)
								{
									case DayPuzzleType.Puzzle1:
										Day1.Day1_Puzzle1();
										break;
									case DayPuzzleType.Puzzle2:
										Day1.Day1_Puzzle2();
										break;
								}
								break;
							case 2:
								dpt = DayPuzzleSelector(dayNum);
								switch (dpt)
								{
									case DayPuzzleType.Puzzle1:
										Day2.Day2_Puzzle1();
										break;
									case DayPuzzleType.Puzzle2:
										Day2.Day2_Puzzle2();
										break;
								}
								break;
							case 3:
								dpt = DayPuzzleSelector(dayNum);
								switch (dpt)
								{
									case DayPuzzleType.Puzzle1:
										Day3.Day3_Puzzle1();
										break;
									case DayPuzzleType.Puzzle2:
										Day3.Day3_Puzzle2();
										break;
								}
								break;
							case 4:
								dpt = DayPuzzleSelector(dayNum);
								switch (dpt)
								{
									case DayPuzzleType.Puzzle1:
										Day4.Day4_Puzzle1();
										break;
									case DayPuzzleType.Puzzle2:
										Day4.Day4_Puzzle2();
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
	}
}