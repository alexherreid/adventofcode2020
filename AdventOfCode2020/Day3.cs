using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
	public class Day3
	{
		public static void Day3_Puzzle1()
		{
			Console.Clear();
			Console.WriteLine("Day 3 Challenge 1 Summary: Toboggan Trajectory");
			Console.WriteLine("Given a list of . and # representing a map for navigating through the woods, find number of trees in the way");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): Map with trees and open spots shown by . and #");
			Console.WriteLine("***********************");
			Console.WriteLine();

			Console.WriteLine("Paste (or type) a the map of open spots (.) and trees (#) which will assume the pattern continues to the right of pasted. " +
							  "Processing stops when an empty line is detected.");
			Console.WriteLine("Map Rows:");

			List<string> mapLine = new List<string>();
			string lineraw;
			while ((lineraw = Console.ReadLine()) != null)
			{
				if (string.IsNullOrEmpty(lineraw))
				{
					break;
				}
				else
				{
					mapLine.Add(lineraw.Trim());
				}
			}

			//start by counting all the trees you would encounter for the slope right 3, down 1 (instructions)
			//starting from 0,0 the top left
			//every row seems to contain 11 characters of the map
			//keep going down 1, right 3 and writing down what it is until you are past all rows on the input

			int operatingColumn = 0;//max is chars in a row
			int maxColumn = mapLine.First().Trim().Length;
			List<string> characters = new List<string>();
			foreach (string line in mapLine)
			{
				//we never have to change operatingRow since we're fed that. Just change column.
				if (operatingColumn >= maxColumn)
				{
					//wrap around. Subtract Index, so if this is 12 and maxColumnIndex is 10, we should go to wrap around of 1.
					operatingColumn -= maxColumn;
				}

				//Check what is in that spot
				characters.Add(line.Substring(operatingColumn, 1));

				//Move the cursor
				operatingColumn = operatingColumn + 3;
			}

			//Now we know all the stuff in those positions. Count tree/open.
			Console.WriteLine();
			Console.WriteLine($"The number of trees is {characters.Count(x => x == "#")} (btw, that means {characters.Count(x => x == ".")} open spots)");
			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}

		public static void Day3_Puzzle2()
		{
			Console.Clear();
			Console.WriteLine("Day 3 Challenge 2 Summary: Toboggan Trajectory");
			Console.WriteLine("Given a list of . and # representing a map for navigating through the woods, find number of trees in the way");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): Map with trees and open spots shown by . and #");
			Console.WriteLine("***********************");
			Console.WriteLine();

			Console.WriteLine("Paste (or type) a the map of open spots (.) and trees (#) which will assume the pattern continues to the right of pasted. " +
							  "Processing stops when an empty line is detected.");
			Console.WriteLine("This is the same as Puzzle 1 of this day, except it checks multiple right and down numbers at the same time");
			Console.WriteLine("Map Rows:");

			List<string> mapLine = new List<string>();
			string lineraw;
			while ((lineraw = Console.ReadLine()) != null)
			{
				if (string.IsNullOrEmpty(lineraw))
				{
					break;
				}
				else
				{
					mapLine.Add(lineraw.Trim());
				}
			}


			//C# Megathread Solution with the bit array
			const char tree = '#';
			var map = mapLine
				.Select(line => new BitArray(line.Select(ch => ch == tree).ToArray()))
				.ToImmutableList();

			Console.WriteLine(GetTreeCount(3, 1));

			Console.WriteLine(new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) }
				.Select(pair => GetTreeCount(pair.Item1, pair.Item2))
				.Select(Convert.ToInt64)
				.Aggregate((a, b) => a * b));

			int GetTreeCount(int dx, int dy)
			{
				var xc = map.First().Count;
				var yc = map.Count / dy + map.Count % dy - 1;

				var xs = Enumerable.Range(1, yc).Select(x => x * dx % xc);
				var ys = Enumerable.Range(1, yc).Select(y => y * dy);

				return xs.Zip(ys, (x, y) => map[y][x]).Count(v => v);
			}

			//OG Solution AH
			//These are the route down/right that we're going to check
			//Right 1, down 1.
			//Right 3, down 1. (This was Puzzle 1)
			//Right 5, down 1.
			//Right 7, down 1.
			//Right 1, down 2.

			List<int> treeCountsPerRun = new List<int>();
			bool doingRuns = true;
			while (doingRuns)
			{
				bool validParams = false;
				int rightInt = 0;
				int downInt = 0;
				while (!validParams)
				{
					Console.Write("How many to the right in this pass (x to mark no more passes)?  ");
					string right = Console.ReadLine()?.ToUpper();
					Console.Write("How many down? (1 or 2)  ");
					string down = Console.ReadLine();
					int.TryParse(right, out rightInt);
					int.TryParse(down, out downInt);
					if (rightInt <= 0 || (downInt != 1 && downInt != 2))
					{
						validParams = false;
						Console.WriteLine("Invalid options, please try again.");
						if (right == "X")
						{
							doingRuns = false;
							break;
						}
					}
					else
					{
						validParams = true;
					}
				}

				if (validParams)
				{
					int operatingColumn = 0;//max is chars in a row
					int maxColumn = mapLine.First().Trim().Length;
					List<string> characters = new List<string>();

					if (downInt == 2)
					{
						//we need to remove every other row before processing (effectively make it so we can use every row in our passes)
						mapLine = mapLine.Where((x, i) => i % 1 == 0).ToList();
					}

					foreach (string line in mapLine)
					{
						//we never have to change operatingRow since we're fed that. Just change column.
						if (operatingColumn >= maxColumn)
						{
							//wrap around. Subtract Index, so if this is 12 and maxColumnIndex is 10, we should go to wrap around of 1.
							operatingColumn -= maxColumn;
						}

						//Check what is in that spot
						characters.Add(line.Substring(operatingColumn, 1));

						//Move the cursor
						operatingColumn = operatingColumn + rightInt;
					}

					Console.WriteLine($"The number of trees is {characters.Count(x => x == "#")} (btw, that means {characters.Count(x => x == ".")} open spots)");
					treeCountsPerRun.Add(characters.Count(x => x == "#"));
				}

			}

			long multiplication = 1;
			foreach (int treeCt in treeCountsPerRun)
			{
				multiplication *= treeCt;
			}

			//Now we know all the stuff in those positions.
			Console.WriteLine();
			Console.WriteLine($"The number of trees in each run multiplied together is {multiplication}");
			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}
	}
}