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

		public static void Day4_Puzzle2()
		{
			Console.Clear();
			Console.WriteLine("Day 4 Challenge 2 Summary: Passport Processing document validity.");
			Console.WriteLine("Given passport credentials (which could be across lines) determine how many are valid passports. Can be missing at max the cid field, all others required. There are specific requirements for each field (like year for birth year)");
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
						string byr_s = fields.SingleOrDefault(x => x.StartsWith("byr"));
						if (!string.IsNullOrEmpty(byr_s))
						{
							//VALIDATION four digits; at least 1920 and at most 2002.
							string yr = byr_s.Substring(byr_s.IndexOf(':') + 1);
							if (int.TryParse(yr, out int yearParse))
							{
								byr = yearParse >= 1920 && yearParse <= 2002;
							}
						}
						string iyr_s = fields.SingleOrDefault(x => x.StartsWith("iyr"));
						if (!string.IsNullOrEmpty(iyr_s))
						{
							//VALIDATION four digits; at least 2010 and at most 2020.
							string yr = iyr_s.Substring(iyr_s.IndexOf(':') + 1);
							if (int.TryParse(yr, out int yearParse))
							{
								iyr = yearParse >= 2010 && yearParse <= 2020;
							}
						}
						string eyr_s = fields.SingleOrDefault(x => x.StartsWith("eyr"));
						if (!string.IsNullOrEmpty(eyr_s))
						{
							//VALIDATION four digits; at least 2020 and at most 2030.
							string yr = eyr_s.Substring(eyr_s.IndexOf(':') + 1);
							if (int.TryParse(yr, out int yearParse))
							{
								eyr = yearParse >= 2020 && yearParse <= 2030;
							}
						}
						string hgt_s = fields.SingleOrDefault(x => x.StartsWith("hgt"));
						if (!string.IsNullOrEmpty(hgt_s))
						{
							//VALIDATION a number followed by either cm or in:
							//If cm, the number must be at least 150 and at most 193.
							//If in, the number must be at least 59 and at most 76.
							string measure = hgt_s.Substring(hgt_s.IndexOf(':') + 1);
							if (measure.Contains("cm"))
							{
								string sizeCm = measure.Replace('c', ' ').Replace('m', ' ').Trim();
								if (int.TryParse(sizeCm, out int sizeCmInt))
								{
									hgt = sizeCmInt >= 150 && sizeCmInt <= 193;
								}
							}
							else if (measure.Contains("in"))
							{
								string sizeIn = measure.Replace('i', ' ').Replace('n', ' ').Trim();
								if (int.TryParse(sizeIn, out int sizeInInt))
								{
									hgt = sizeInInt >= 59 && sizeInInt <= 76;
								}
							}
						}
						string hcl_s = fields.SingleOrDefault(x => x.StartsWith("hcl"));
						if (!string.IsNullOrEmpty(hcl_s))
						{
							//VALIDATION a # followed by exactly six characters 0-9 or a-f.
							string hairColor = hcl_s.Substring(hcl_s.IndexOf(':') + 1);
							int hcI = hairColor.IndexOf('#');
							if (hcI != -1)//invalid (no #)
							{
								string hairColorPound = hairColor.Substring(hcI + 1);
								hcl = hairColorPound.Length == 6;//exact length required
							}

						}
						string ecl_s = fields.SingleOrDefault(x => x.StartsWith("ecl"));
						if (!string.IsNullOrEmpty(ecl_s))
						{
							//VALIDATION exactly one of: amb blu brn gry grn hzl oth.
							string eyeColor = ecl_s.Substring(ecl_s.IndexOf(':') + 1);
							ecl = eyeColor == "amb" || eyeColor == "blu" || eyeColor == "brn" ||
									eyeColor == "gry" || eyeColor == "grn" || eyeColor == "hzl" ||
									eyeColor == "oth";
						}
						string pid_s = fields.SingleOrDefault(x => x.StartsWith("pid"));
						if (!string.IsNullOrEmpty(pid_s))
						{
							//VALIDATION a nine-digit number, including leading zeroes.
							string passId = pid_s.Substring(pid_s.IndexOf(':') + 1);
							pid = passId.Length == 9;
						}
						string cid_s = fields.SingleOrDefault(x => x.StartsWith("cid"));
						if (!string.IsNullOrEmpty(cid_s))
						{
							//VALIDATION ignored, missing or not.
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