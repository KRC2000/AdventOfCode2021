
using cs;

class Board {
	static uint BSize => Program.BoardSize;

	public bool Bingo { get; private set; } = false;
	readonly uint[,] board = new uint[BSize,BSize];
	readonly bool[,] marks = new bool[BSize,BSize];
	readonly uint[] marksCount = new uint[BSize * 2];

	public void SetRow(uint row, IEnumerable<uint> nums) {
		for (int i = 0; i < BSize; i++)
			board[row, i] = nums.ToArray()[i];
	}

	public bool Mark(uint num) {
		for (int row = 0; row < BSize; row++) {
			for (int col = 0; col < BSize; col++) {
				if (board[row, col] != num) continue;
				marks[row, col] = true;
				marksCount[row]++;
				marksCount[BSize + col]++;
				if (marksCount.Contains(BSize)) {
					Bingo = true;
					return Bingo;
				}
			}
		}
		return false;
	}

	public uint GetUnmarkedSum() {
		uint sum = 0;
		for (int row = 0; row < BSize; row++) {
			for (int col = 0; col < BSize; col++) {
				if (!marks[row, col]) sum += board[row, col];
			}
		}
		return sum;
	}

	public void Print() {
		for (int row = 0; row < BSize; row++) {
			for (int col = 0; col < BSize; col++) {
				Console.BackgroundColor = marks[row, col] ? ConsoleColor.Red : ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write($"{board[row, col]:00}");
				Console.ResetColor();
				if (Bingo) Console.BackgroundColor = ConsoleColor.White;
				if (col < BSize - 1) Console.Write("  ");
				Console.ResetColor();
			}
			Console.Write('\n');
		}
		Console.Write('\n');
	}
}