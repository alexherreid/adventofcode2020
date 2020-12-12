using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public static class Day2
	{
		public static void Day2_Puzzle1()
		{
			Console.Clear();
			Console.WriteLine("Day 2 Challenge 1 Summary: Password Philosophy toboggan to airport.");
			Console.WriteLine("Given a list of passwords and their policies (in terms of number of repeat characters allowed) determine how many are valid passwords.");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): List of passwords and policies in format N-M a: input where N and M are min and max count of chars, a is char and input is the password");
			Console.WriteLine("***********************");
			Console.WriteLine();

			Console.WriteLine("Paste (or type) a list of policies and passwords. Processing stops when an empty line is detected.");
			Console.WriteLine("Entries:");

			List<Tuple<int, int, char, string>> minMaxCharPassword = new List<Tuple<int, int, char, string>>();
			string line;
			while ((line = Console.ReadLine()) != null)
			{
				if (string.IsNullOrEmpty(line))
				{
					break;
				}
				else
				{
					int dashSpot = line.IndexOf('-');
					int min = int.Parse(line.Substring(0, dashSpot));
					int charSpot = line.IndexOf(':');
					char target = Convert.ToChar(line.Substring(charSpot - 1, 1));
					int max = int.Parse(line.Substring(dashSpot + 1, 2));
					string password = line.Substring(charSpot + 1);

					minMaxCharPassword.Add(new Tuple<int, int, char, string>(min, max, target, password));
				}
			}

			Console.WriteLine($"Found {minMaxCharPassword.Count} valid inputs");

			int validPasswords = 0;
			List<string> validPasswordsList = new List<string>();
			foreach (Tuple<int, int, char, string> processing in minMaxCharPassword)
			{
				char[] chars = processing.Item4.ToCharArray();
				int charCount = chars.Count(x => x == processing.Item3);
				if (charCount >= processing.Item1 && charCount <= processing.Item2)
				{
					validPasswords++;
					validPasswordsList.Add(processing.Item4);
				}
			}

			Console.WriteLine();
			Console.Write($"Found {validPasswords} valid passwords in provided set of rules. They are: ");
			foreach (string pw in validPasswordsList)
			{
				Console.Write($"{pw}, ");
			}
			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}

		public static void Day2_Puzzle2()
		{
			Console.Clear();
			Console.WriteLine("Day 2 Challenge 2 Summary: Password Philosophy toboggan to airport.");
			Console.WriteLine("Given a list of passwords and their policies (in terms of number of repeat characters allowed) determine how many are valid passwords.");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): List of passwords and policies in format N-M a: input where N and M are the exact position of the char, a is char and input is the password. Must be exactly one occurrence.");
			Console.WriteLine("***********************");
			Console.WriteLine();

			Console.WriteLine("Paste (or type) a list of policies and passwords. Processing stops when an empty line is detected.");
			Console.WriteLine("Entries:");

			List<Tuple<int, int, char, string>> pos12CharPassword = new List<Tuple<int, int, char, string>>();
			string line;
			while ((line = Console.ReadLine()) != null)
			{
				if (string.IsNullOrEmpty(line))
				{
					break;
				}
				else
				{
					int dashSpot = line.IndexOf('-');
					int pos1 = int.Parse(line.Substring(0, dashSpot));
					int charSpot = line.IndexOf(':');
					char target = Convert.ToChar(line.Substring(charSpot - 1, 1));
					int pos2 = int.Parse(line.Substring(dashSpot + 1, 2));
					string password = line.Substring(charSpot + 1);

					pos12CharPassword.Add(new Tuple<int, int, char, string>(pos1, pos2, target, password));
				}
			}

			Console.WriteLine($"Found {pos12CharPassword.Count} valid inputs");

			int validPasswords = 0;
			List<string> validPasswordsList = new List<string>();
			foreach (Tuple<int, int, char, string> processing in pos12CharPassword)
			{
				char[] chars = processing.Item4.Trim().ToCharArray();

				//Position 1 and 2 are NOT index, they're position numbers. Char must appear in exactly ONE of these positions.
				if ((chars[processing.Item1 - 1] == processing.Item3 && chars[processing.Item2 - 1] != processing.Item3) || 
					(chars[processing.Item1 - 1] != processing.Item3 && chars[processing.Item2 - 1] == processing.Item3))
				{
					validPasswords++;
					validPasswordsList.Add(processing.Item4);
				}
			}

			Console.WriteLine();
			Console.Write($"Found {validPasswords} valid passwords in provided set of rules. They are: ");
			foreach (string pw in validPasswordsList)
			{
				Console.Write($"{pw}, ");
			}
			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}
	}
}