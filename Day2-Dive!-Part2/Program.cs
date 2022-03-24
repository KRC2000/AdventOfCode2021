using System;
using System.IO;

        // Task: https://adventofcode.com/2021/day/2#part2

namespace Day2_Dive__Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            int posX = 0;
            int depth = 0;
            int angle = 0;

            StreamReader reader = new StreamReader("input");

            while (!reader.EndOfStream)
            {
                string[] pair = reader.ReadLine().Split(" ");
                string instruction = pair[0];
                int value; int.TryParse(pair[1], out value);

                switch(instruction)
                {
                    case "up":
                        angle -= value;
                    break;
                    case "down":
                        angle += value;
                    break;
                    case "forward":
                        posX += value;
                        depth += value * angle;
                    break;
                }
            }
            reader.Close();

            Console.WriteLine(posX);
            Console.WriteLine(depth);
            Console.WriteLine(posX * depth);
        }
    }
}
