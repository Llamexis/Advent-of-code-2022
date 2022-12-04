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
    var firstElf = line.Split(',')[0].Split('-');
    var secondElf = line.Split(',')[1].Split('-');
    if (Convert.ToInt32(firstElf[0]) <= Convert.ToInt32(secondElf[0]) 
        && Convert.ToInt32(firstElf[1]) >= Convert.ToInt32(secondElf[1]))
        pairs++;
    else if (Convert.ToInt32(secondElf[0]) <= Convert.ToInt32(firstElf[0])
        && Convert.ToInt32(secondElf[1]) >= Convert.ToInt32(firstElf[1]))
        pairs++;
}
Console.WriteLine("Number of pairs: "+pairs);