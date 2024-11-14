using System;
using System.Collections.Generic;

namespace cs;

public class Program
{
	public const UInt16 BoardSize = 5;
	
	static List<uint> nums = [];
	static readonly List <(UInt16, bool)[,]> boards = [];

    static void Main(string[] args)
    {
		StreamReader sr = new("../input");
		string ln1 = sr.ReadLine() ?? throw new Exception("Can't read a line.");
		nums = ln1.Split(',').ToList().ConvertAll<uint>((s) => { return uint.Parse(s); });

		UInt16 row = 0;
		(UInt16, bool)[,] board = new (UInt16, bool)[BoardSize, BoardSize];
		while (true) {
			string? s = sr.ReadLine();
			if (s == null) break;
			string[] ssub = s.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			if (row == BoardSize) {
				boards.Add(board);
				board = new (UInt16, bool)[BoardSize, BoardSize];
				row = 0;
			}
			if (s == "") continue;

			for (UInt16 i = 0; i < BoardSize; i++) {
				Console.WriteLine(ssub[i]);
				board[row,i] = (UInt16.Parse(ssub[i]), false);
			}
			row++;
		}

		sr.Close();

		for (int i = 0; i < nums.Count; i++) {
			uint num = nums[i];
			foreach (var b in boards) {
				for (int r = 0; r < BoardSize; r ++) {
					for (int c = 0; c < BoardSize; c++) {
						if (b[r, c].Item1 == num) b[r, c].Item2 = true;
					}
				}
			}

			foreach (var b in boards) {
				for (int r = 0; r < BoardSize; r++) {
					// if (b[r, 0].Item2)
				}
			}

		}


    }
}
