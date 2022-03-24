using System;
using System.IO;
using System.Collections.Generic;

        // Task: https://adventofcode.com/2021/day/1#part2
        // Part 2
        // Note: Could read and save all input in the list first, 
        // then do the calculations, but that would be inefficient
        // because input could be huge and that could require gigs 
        // of ram 

namespace Day1_Sonar_Sweep_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input");
            
            int increaseAmount = 0;

            int prevWindowSum = int.MaxValue;
            int thisWindowSum = 0;

            int v0, v1, v2;

            int.TryParse(reader.ReadLine(), out v0);
            int.TryParse(reader.ReadLine(), out v1);
            int.TryParse(reader.ReadLine(), out v2);
            prevWindowSum = v0 + v1 + v2;

            while (!reader.EndOfStream)
            {
                ProcessNewWindow(ref thisWindowSum, ref prevWindowSum, ref v0, ref increaseAmount, reader);
                ProcessNewWindow(ref thisWindowSum, ref prevWindowSum, ref v1, ref increaseAmount, reader);
                ProcessNewWindow(ref thisWindowSum, ref prevWindowSum, ref v2, ref increaseAmount, reader);
            }

            Console.WriteLine(increaseAmount);
        }

        static void ProcessNewWindow(ref int thisWindowSum, ref int prevWindowSum, ref int prevWindowHomeValue, ref int increaseAmount, StreamReader reader)
        {
            thisWindowSum = prevWindowSum - prevWindowHomeValue;
            int.TryParse(reader.ReadLine(), out prevWindowHomeValue);
            thisWindowSum += prevWindowHomeValue;

            if (thisWindowSum > prevWindowSum) increaseAmount++;
            prevWindowSum = thisWindowSum;
        }
    }
}
