namespace Advent_of_code_2022
{
    internal class Program
    {

        static string[] calories =
            {
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000"
            };
        static void Main(string[] args)
        {
            part2();
        }

        static void part1()
        {
            int max_calorie = int.MinValue;
            var lines = File.ReadAllLines("..\\..\\..\\input1.txt");
            int sum = 0;
            foreach(var line in lines)
            {
                if(line != string.Empty)
                {
                    sum += int.Parse(line);
                }
                else
                {
                    max_calorie = max_calorie < sum ? sum: max_calorie;
                    sum = 0;
                }
            }
            max_calorie = max_calorie < sum ? sum : max_calorie;
            Console.WriteLine($"Maximum Calories: {max_calorie}");
        }

        static void part2()
        {
            List<int> elfs = new List<int>();
            var lines = File.ReadAllLines("..\\..\\..\\input1.txt");
            int sum = 0; 
            foreach(var line in lines)
            {
                if (line != string.Empty)
                {
                    sum += int.Parse(line);
                }
                else
                {
                    elfs.Add(sum);
                    sum = 0;
                }
            }
            elfs.Sort();

            int sumOfTopThree = elfs.TakeLast(3).Sum();
            Console.WriteLine($"Calories of top three:{sumOfTopThree}");
        }
    }
}