var input = File.ReadAllLines("..\\..\\..\\input.txt");

// Parsing Input

List<Stack<char>> stacks = new List<Stack<char>>();
for (int i = 0; i < 9; i++)
    stacks.Add(new Stack<char>());
for(int i = 7; i >= 0; i--)
{
    int indexOfStack = 0;
    var line = input[i].ToCharArray();
    for(int j = 1; j < line.Length; j += 4)
    {
        if (char.IsLetter(line[j]))
        {
            stacks[indexOfStack].Push(line[j]);
        }
        indexOfStack++;
    }
}

// Part 1
