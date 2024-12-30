using System;
using System.IO;

        // Task: https://adventofcode.com/2021/day/1
        // Part 1
        // Note: Could read and save all input in the list first, 
        // then do the calculations, but that would be inefficient
        // because input could be huge and that could require gigs 
        // of ram 

namespace Day_1_Sonar_Sweep
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../input");
            
            bool first = true;
            int previous = 0;
            int increaseTimes = 0;

            while (!reader.EndOfStream){
                int current = int.Parse(reader.ReadLine());
                if (!first){
                    if (current > previous) increaseTimes++;
                } 
                else first = false;
                previous = current;
            }
            reader.Close();

            Console.WriteLine(increaseTimes);
        }
    }
}
