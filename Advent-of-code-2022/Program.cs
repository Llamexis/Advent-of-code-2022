var input = File.ReadAllLines("..\\..\\..\\input.txt");

string[] test =
{
    "2-4,6-8",
    "2-3,4-5",
    "5-7,7-9",
    "2-8,3-7",
    "6-6,4-6",
    "2-6,4-8"
};

// Part 1
int pairs = 0;
foreach(var line in input)
{
    int[] firstElf = { Convert.ToInt32(line.Split(',')[0].Split('-')[0]),
                     Convert.ToInt32(line.Split(',')[0].Split('-')[1])
    };
    int[] secondElf = { Convert.ToInt32(line.Split(',')[1].Split('-')[0]),
                      Convert.ToInt32(line.Split(',')[1].Split('-')[1])
    }; 
    if (firstElf[0] <= secondElf[0] && firstElf[1] >= secondElf[1])
        pairs++;
    else if (secondElf[0] <= firstElf[0] && secondElf[1] >= firstElf[1])
        pairs++;
}
Console.WriteLine("Number of pairs: "+pairs);

// part 2
pairs = 0;
foreach (var line in input)
{
    int[] firstElf = { Convert.ToInt32(line.Split(',')[0].Split('-')[0]),
                     Convert.ToInt32(line.Split(',')[0].Split('-')[1])
    };
    int[] secondElf = { Convert.ToInt32(line.Split(',')[1].Split('-')[0]),
                      Convert.ToInt32(line.Split(',')[1].Split('-')[1])
    };
    var maxRange = Math.Max(firstElf[1], secondElf[1]) - Math.Min(firstElf[0], secondElf[0]);
    var firstRange = firstElf[1] - firstElf[0];
    var secondRange = secondElf[1] - secondElf[0];
    if (maxRange <= firstRange + secondRange) 
        pairs++;
}
Console.WriteLine("Number of pairs: " + pairs);