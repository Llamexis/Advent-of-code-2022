namespace Advent_of_code_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            part2();
        }

        // Rock = {A,X} == 1
        // Paper = {B,Y} == 2
        // Scissors = {C,Z} == 3
        // Win == 6
        // Draw == 3
        // lose == 0
        static void part1()
        {
            var lines = File.ReadAllLines("..\\..\\..\\input1.txt");
            int totalScore = 0;
            foreach (var line in lines)
            {
                var choices = line.Split(' ');
                if (choices[0] == "A")
                {
                    if (choices[1] == "X")
                    {
                        totalScore += 1 + 3;
                    }
                    else if (choices[1] == "Y")
                    {
                        totalScore += 2 + 6;
                    }
                    else
                    {
                        totalScore += 3 + 0;
                    }
                }
                else if (choices[0] == "B")
                {
                    if (choices[1] == "X")
                    {
                        totalScore += 1 + 0;
                    }
                    else if (choices[1] == "Y")
                    {
                        totalScore += 2 + 3;
                    }
                    else
                    {
                        totalScore += 3 + 6;
                    }
                }
                else if (choices[0] == "C")
                {
                    if (choices[1] == "X")
                    {
                        totalScore += 1 + 6;
                    }
                    else if (choices[1] == "Y")
                    {
                        totalScore += 2 + 0;
                    }
                    else
                    {
                        totalScore += 3 + 3;
                    }
                }
            }
            Console.WriteLine($"Total Score: {totalScore}");
        }

        // Lose == x
        // win == z
        // draw == y
        static void part2()
        {
            var lines = File.ReadAllLines("..\\..\\..\\input1.txt");
            int totalScore = 0;
            foreach (var line in lines)
            {
                var choices = line.Split(' ');
                if (choices[0] == "A")
                {
                    if (choices[1] == "X")
                    {
                        totalScore += 3 + 0;
                    }
                    else if (choices[1] == "Y")
                    {
                        totalScore += 1 + 3;
                    }
                    else
                    {
                        totalScore += 2 + 6;
                    }
                }
                else if (choices[0] == "B")
                {
                    if (choices[1] == "X")
                    {
                        totalScore += 1 + 0;
                    }
                    else if (choices[1] == "Y")
                    {
                        totalScore += 2 + 3;
                    }
                    else
                    {
                        totalScore += 3 + 6;
                    }
                }
                else if (choices[0] == "C")
                {
                    if (choices[1] == "X")
                    {
                        totalScore += 2 + 0;
                    }
                    else if (choices[1] == "Y")
                    {
                        totalScore += 3 + 3;
                    }
                    else
                    {
                        totalScore += 1 + 6;
                    }
                }
            }
            Console.WriteLine($"Total Score: {totalScore}");
        }
    }
}