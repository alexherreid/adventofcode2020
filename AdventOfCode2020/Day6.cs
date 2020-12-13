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

		public static void Day6_Puzzle2()
		{
			Console.Clear();
			Console.WriteLine("Day 6 Challenge 2 Summary: Custom Customs declaration form.");
			Console.WriteLine("Given a list of empty line separated customs response groups, determine how many questions had a yes within the group. EVERYONE in the group had to say yes for it to count in the total output.");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): List of questions that got a \"yes\" answer from all people in the group");
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
			List<string> answerPerPersonInGroup = new List<string>();
			int personAllAnswerCount = 0;
			foreach (string cLine in customsLines)
			{
				if (string.IsNullOrEmpty(cLine))
				{
					if (answerPerPersonInGroup.Count > 0)
					{
						//process this customs form that is loaded, then clear it 
						//find the longest. We know the answer has to be on everyone in the group, so the longest is safe to use as key
						char[] longestAnswerSet = answerPerPersonInGroup.OrderBy(x => x.Length).First().ToCharArray();

						string allAnswersInGroup = string.Empty;
						foreach (string personAnswer in answerPerPersonInGroup)
						{
							allAnswersInGroup = allAnswersInGroup + personAnswer;
						}

						//Now we need to know how many times each character is in the allAnswersInGroup
						foreach (char ch in longestAnswerSet)
						{
							if (allAnswersInGroup.Count(x => x == ch) == answerPerPersonInGroup.Count)
							{
								personAllAnswerCount++;
							}
						}

						uniqueAnswersInGroup.Add(personAllAnswerCount);

						//clear before continue
						personAllAnswerCount = 0;
						allAnswersInGroup = string.Empty;
						answerPerPersonInGroup = new List<string>();
					}
				}
				else
				{
					answerPerPersonInGroup.Add(cLine);
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