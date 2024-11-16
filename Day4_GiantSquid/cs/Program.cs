using System;
using System.Collections.Generic;

namespace cs;

public class Program
{
	public const uint BoardSize = 5;
	
	static List<uint> nums = [];
	static readonly List <Board> boards = [];

    static void Main(string[] args)
    {
		StreamReader sr = new("../input");
		string ln1 = sr.ReadLine() ?? throw new Exception("Can't read a line.");
		nums = ln1.Split(',').ToList().ConvertAll<uint>((s) => { return uint.Parse(s); });

		Board board = new();
		uint row = 0;
		while (true) {
			string? s = sr.ReadLine();
			if (s == null) break;
			List<uint> rowNums = s.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
								  .ToList()
								  .ConvertAll<uint>((s) => uint.Parse(s));
			if (s == "") continue;

			board.SetRow(row, rowNums);

			row++;

			if (row == BoardSize) {
				boards.Add(board);
				board = new();
				row = 0;
			}
		}

		sr.Close();

		Board? bingoBoard = null;
		uint lastNum = 0;
		foreach (uint num in nums) {
			lastNum = num;
			foreach (Board b in boards) {
				if (b.Mark(num)) bingoBoard = b;
				if (bingoBoard != null) break;
			}
			if (bingoBoard != null) break;
		}

		if (bingoBoard == null) {
			Console.WriteLine("There is no winning board.");
			return;
		}

		foreach (Board b in boards)
			b.Print();

		uint sum = bingoBoard.GetUnmarkedSum();
		Console.WriteLine($"Final score: {sum * lastNum}");
    }
}
