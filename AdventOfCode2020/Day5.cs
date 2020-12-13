using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public static class Day5
	{
		public static void Day5_Puzzle1()
		{
			Console.Clear();
			Console.WriteLine("Day 5 Challenge 1 Summary: Binary Boarding boarding passes.");
			Console.WriteLine("Given a list of encoded boarding passes, eliminate occupied seats to try to determine which seat is yours.");
			Console.WriteLine("***********************");
			Console.WriteLine("Input(s): List of occupied seats in 10 character chunks.");
			Console.WriteLine("***********************");
			Console.WriteLine();

			Console.WriteLine("Paste (or type) a list of encoded boarding passes. Processing stops when an empty line is detected.");
			Console.WriteLine("B Passes:");

			List<string> boardingPassesRead = new List<string>();
			string line;
			while ((line = Console.ReadLine()) != null)
			{
				if (string.IsNullOrEmpty(line))
				{
					break;
				}
				else
				{
					boardingPassesRead.Add(line.Trim());
				}
			}

			Console.WriteLine($"Found {boardingPassesRead.Count} valid inputs pass lines");

			int maxSeatId = 0;
			foreach (string bpline in boardingPassesRead)
			{
				//For example, consider just the first seven characters of FBFBBFFRLR:
				//Start by considering the whole range, rows 0 through 127.
				//	F means to take the lower half, keeping rows 0 through 63.
				//	B means to take the upper half, keeping rows 32 through 63.
				//	F means to take the lower half, keeping rows 32 through 47.
				//	B means to take the upper half, keeping rows 40 through 47.
				//	B keeps rows 44 through 47.
				//	F keeps rows 44 through 45.
				//	The final F keeps the lower of the two, row 44.
				int indexRowMin = 0;
				int indexRowMax = 127;
				int indexRow = 0;
				if (bpline.Substring(0, 1) == "F")
				{
					indexRowMax = 63;//min stays
				}
				else
				{
					indexRowMin = 64;//max stays
				}
				//Character 2
				if (bpline.Substring(1, 1) == "F")
				{
					//char 2 is "worth" 32 rows
					indexRowMax -= 32;
				}
				else
				{
					indexRowMin += 32;
				}
				//Character 3
				if (bpline.Substring(2, 1) == "F")
				{
					//char 3 is "worth" 16 rows
					indexRowMax -= 16;
				}
				else
				{
					indexRowMin += 16;
				}
				//Character 4
				if (bpline.Substring(3, 1) == "F")
				{
					//char 4 is "worth" 8 rows
					indexRowMax -= 8;
				}
				else
				{
					indexRowMin += 8;
				}
				//Character 5
				if (bpline.Substring(4, 1) == "F")
				{
					//char is "worth" 4 rows
					indexRowMax -= 4;
				}
				else
				{
					indexRowMin += 4;
				}
				//Character 6
				if (bpline.Substring(5, 1) == "F")
				{
					//char is "worth" 2 rows
					indexRowMax -= 2;
				}
				else
				{
					indexRowMin += 2;
				}
				//Character 7
				if (bpline.Substring(6, 1) == "F")
				{
					//char is either the lower or the higher
					indexRow = indexRowMin;
				}
				else
				{
					indexRow = indexRowMax;
				}

				//Now we have a row. Need seat
				//For example, consider just the last 3 characters of FBFBBFFRLR:
				//Start by considering the whole range, columns 0 through 7.
				//	R means to take the upper half, keeping columns 4 through 7.
				//	L means to take the lower half, keeping columns 4 through 5.
				//	The final R keeps the upper of the two, column 5.
				int indexSeatMin = 0;
				int indexSeatMax = 7;
				int indexSeat = 0;

				//Character 1
				if (bpline.Substring(7, 1) == "R")
				{
					indexSeatMin = 4;//min stays
				}
				else
				{
					indexSeatMax = 3;//max stays
				}

				//Character 2
				if (bpline.Substring(8, 1) == "R")
				{
					//char is "worth" 2 seats
					indexSeatMin += 2;
				}
				else
				{
					indexSeatMax -= 2;
				}

				//Character 3
				if (bpline.Substring(9, 1) == "R")
				{
					//char is either the lower or the higher
					indexSeat = indexSeatMax;
				}
				else
				{
					indexSeat = indexSeatMin;
				}

				//Every seat also has a unique seat ID: multiply the row by 8, then add the column.
				//In this example, the seat has ID 44 * 8 + 5 = 357.
				int seatId = (indexRow * 8) + indexSeat;
				if (seatId > maxSeatId)
				{
					maxSeatId = seatId;
				}
			}

			Console.WriteLine();
			Console.WriteLine($"The max seat id found was {maxSeatId}");

			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}

	}
}