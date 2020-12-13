using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public static class Day6
	{
		public static void Day6_Puzzle1()
		{
			Console.Clear();
			Console.WriteLine("Day 6 Challenge 1 Summary: Custom Customs declaration form.");
			Console.WriteLine("Given a list of empty line separated customs response groups, determine how many questions had a yes within the group.");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): List of questions that got a \"yes\" answer from at least one person in the group");
			Console.WriteLine("***********************");
			Console.WriteLine();

			Console.WriteLine("Paste (or type) a list of answer by group (even across line). Processing stops when TWO empty lines are detected.");
			Console.WriteLine("B Passes:");

			List<string> customsLines = new List<string>();
			string line;
			int blankLineCount = 0;
			while ((line = Console.ReadLine()) != null)
			{
				if (string.IsNullOrEmpty(line))
				{
					blankLineCount++;
					if (blankLineCount >= 2)
					{
						break;
					}
				}
				else
				{
					blankLineCount = 0;
				}

				//Add the line anyway (we need the breaks during processing)
				customsLines.Add(line.Trim());
			}

			Console.WriteLine($"Found {customsLines.Count} valid inputs customs lines");

			List<int> uniqueAnswersInGroup = new List<int>();
			string customsLine = string.Empty;
			foreach (string cLine in customsLines)
			{
				if (string.IsNullOrEmpty(cLine))
				{
					if (!string.IsNullOrEmpty(customsLine))
					{
						//process this customs form that is loaded, then clear it 
						char[] chars = customsLine.ToCharArray();
						uniqueAnswersInGroup.Add(chars.Where(x => x != ' ').Distinct().Count());//skip blank characters
						
						//clear before continue
						customsLine = string.Empty;
					}
				}
				else
				{
					customsLine = customsLine + " " + cLine;
				}
			}

			//Sum the items in the list
			int totalCounts = 0;
			foreach (int count in uniqueAnswersInGroup)
			{
				totalCounts += count;
			}

			Console.WriteLine();
			Console.WriteLine($"Total number of unique answers of yes across groups is {totalCounts}");

			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}

	}
}