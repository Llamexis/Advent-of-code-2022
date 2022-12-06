var input = File.ReadAllText("input.txt");

// part 1
//Lucky solution
//because doesn't check every posible sequence
int index = 0;
while (index < input.Length)
{
    var seq = input.Substring(index, 4);
    if (seq.ToCharArray().Distinct().Count() == 4)
        break;
    index++;
}
Console.WriteLine("Part 1: " + (index+4));

// part 2
index = 0;
while (index < input.Length )
{
    var seq = input.Substring(index, 14);
    if(seq.ToCharArray().Distinct().Count() == 14)
        break;
    index++;
}
Console.WriteLine("Part 2: " + (index + 14));
