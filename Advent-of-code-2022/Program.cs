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
    for(int i = firstElf[0]; i <= firstElf[1];i++)
    {
        if (secondElf[0] <= i && i <= secondElf[1])
        {
            pairs++;
            break;
        }
    }
}
Console.WriteLine("Number of pairs: " + pairs);