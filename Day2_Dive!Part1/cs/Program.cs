using System;
using System.IO;
        
        // Task: https://adventofcode.com/2021/day/2
        // Part 1 

namespace Day2_Dive_
{
    class Program
    {
        static void Main(string[] args)
        {
            int posX = 0;
            int posY = 0;

            StreamReader reader = new StreamReader("input");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] pair = line.Split(" ");

                string instruction = pair[0];
                int amount;
                int.TryParse(pair[1], out amount);

                switch(instruction)
                {
                    case "up":
                        posY -= amount;
                    break;
                    case "down":
                        posY += amount;
                    break;
                    case "forward":
                        posX += amount;
                    break;
                }
            }
            reader.Close();

            Console.WriteLine(posX);
            Console.WriteLine(posY);
            Console.WriteLine(posX * posY);
        }
    }
}
