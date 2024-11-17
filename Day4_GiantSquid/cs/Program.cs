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

		bool firstBingo = false;
		uint lastBingoScore = 0;
		foreach (uint num in nums) {
			foreach (Board b in boards) {
				if (b.Bingo || !b.Mark(num)) continue;
				if (firstBingo == false) { 
					Console.WriteLine($"First bingo score: {b.GetUnmarkedSum() * num}");
					firstBingo = true;
				}
				lastBingoScore = b.GetUnmarkedSum() * num;
			}
		}

		Console.WriteLine($"Last bingo score: {lastBingoScore}");
    }
}
