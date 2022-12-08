string[] input = File.ReadAllLines("input.txt");
/*string[] input =
{
    "30373",
    "25512",
    "65332",
    "33549",
    "35390"
};*/

bool[][] IsVisible= new bool[input.Length][];
for(int i = 0; i < input.Length;i++)
    IsVisible[i] = new bool[input.Length];

int visible = 0;
for(int i=0; i<input.Length; i++)
{
    for(int j=0; j < input[i].Length;j++)
    {
        bool left = CountVisible(j, i, -1, 0, input[i][j]);
        bool right= CountVisible(j, i, 1, 0, input[i][j]);
        bool up = CountVisible(j, i, 0, -1, input[i][j]);
        bool down= CountVisible(j, i, 0, 1, input[i][j]);
        if (up || down || left || right)
            visible++;
    }
}

Console.WriteLine("Part 1: "+visible);

bool CountVisible(int x, int y, int xd, int yd, char startValue)
{
    if(x == 0 || x == input.Length || x == input.Length-1
        || y == 0 || y == input.Length || y == input.Length-1)
        return true;
    if (startValue <= input[y + yd][x + xd])
        return false;
    
    return CountVisible(x + xd, y + yd, xd, yd, startValue);
}