using System;
using System.IO;

// Task: https://adventofcode.com/2021/day/1
// Part 1
// Note: Could read and save all input in the list first, 
// then do the calculations, but that would be inefficient
// because input could be huge and that could require gigs 
// of ram 
namespace Day_1_Sonar_Sweep;

class Program {
	static void Main(string[] args) {
		StreamReader reader = new StreamReader("../input");

		int previous = int.MaxValue;
		int count = 0;

		while (!reader.EndOfStream) {
			int current = int.Parse(reader.ReadLine());
			if (current > previous) count++;
			previous = current;
		}

		Console.WriteLine("Part 1. Count is: {0}", count);

		// Part 2

		reader.DiscardBufferedData();
		reader.BaseStream.Seek(0, SeekOrigin.Begin);

		count = 0;
		int num1 = int.Parse(reader.ReadLine());
		int num2 = int.Parse(reader.ReadLine());
		int num3 = int.Parse(reader.ReadLine());
		int prevSum = num1 + num2 + num3;
		while (!reader.EndOfStream) {
			num1 = num2;
			num2 = num3;
			num3 = int.Parse(reader.ReadLine());
			int sum = num1 + num2 + num3;
			if (sum > prevSum) count++;
			prevSum = sum;
		}

		Console.WriteLine("Part 2. Count is: {0}", count);

		reader.Close();
	}
}
