using System;
using System.Collections.Generic;
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
	}
}