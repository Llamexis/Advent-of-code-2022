namespace Advent_of_code_2022
{
    internal class Program
    {

        static string[] rucksacks =
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };
        static void Main(string[] args)
        {
            part1();
        }

        static void part1()
        {
            var lines = File.ReadAllLines("..\\..\\..\\input.txt");

            Console.WriteLine("Sum of priorities: " +
                lines.Select(x => x.ToCharArray().Chunk(x.Length / 2))
                .Select(x => x.First().Intersect(x.Last()).First())
                .Sum(x => {return x >  96 ? x - 96 : x - 38; })
                );
        }
    }
}