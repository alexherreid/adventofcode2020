using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public static class Day4
	{
		public static void Day4_Puzzle1()
		{
			Console.Clear();
			Console.WriteLine("Day 4 Challenge 1 Summary: Passport Processing document validity.");
			Console.WriteLine("Given passport credentials (which could be across lines) determine how many are valid passports. Can be missing at max the cid field, all others required.");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): Rows of passport details where each detail is a key:value pair, even across lines, but a blank line indicates break in passports.");
			Console.WriteLine("***********************");
			Console.WriteLine();

			Console.WriteLine("Paste (or type) the passport credential list. Processing stops when an TWO empty line in a row are detected.");
			Console.WriteLine("Passports:");

			List<string> passportLines = new List<string>();
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
				passportLines.Add(line.Trim());
			}

			Console.WriteLine($"Found {passportLines.Count} valid passport input lines before the break trigger was found");

			int validPassportCount = 0;
			string targetPassportLine = string.Empty;
			bool byr = false;
			bool iyr = false;
			bool eyr = false;
			bool hgt = false;
			bool hcl = false;
			bool ecl = false;
			bool pid = false;
			bool cid = false;
			foreach (string ppLine in passportLines)
			{
				if (string.IsNullOrEmpty(ppLine))
				{
					if (!string.IsNullOrEmpty(targetPassportLine))
					{
						//process this passport that is loaded, then clear it 
						
						string[] fields = targetPassportLine.Split(' ');
						if (fields.Count(x => x.StartsWith("byr")) > 0)
						{
							byr = true;
						}
						if (fields.Count(x => x.StartsWith("iyr")) > 0)
						{
							iyr = true;
						}
						if (fields.Count(x => x.StartsWith("eyr")) > 0)
						{
							eyr = true;
						}
						if (fields.Count(x => x.StartsWith("hgt")) > 0)
						{
							hgt = true;
						}
						if (fields.Count(x => x.StartsWith("hcl")) > 0)
						{
							hcl = true;
						}
						if (fields.Count(x => x.StartsWith("ecl")) > 0)
						{
							ecl = true;
						}
						if (fields.Count(x => x.StartsWith("pid")) > 0)
						{
							pid = true;
						}
						if (fields.Count(x => x.StartsWith("cid")) > 0)
						{
							cid = true;
						}

						//don't require cid to be valid
						if (byr && iyr && eyr && hgt && hcl && ecl && pid)
						{
							validPassportCount++;
						}

						//clear before continue
						targetPassportLine = string.Empty;
					}

					byr = false;
					iyr = false;
					eyr = false;
					hgt = false;
					hcl = false;
					ecl = false;
					pid = false;
					cid = false;
				}
				else
				{
					targetPassportLine = targetPassportLine + " " + ppLine;
				}
			}

			Console.WriteLine();
			Console.WriteLine($"Found {validPassportCount} valid passports in passport lines");

			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}

	}
}