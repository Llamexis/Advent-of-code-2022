string[] input = File.ReadAllLines("input.txt");
/*string[] input =
{
    "30373",
    "25512",
    "65332",
    "33549",
    "35390"
};*/

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

List<int> scenicScores = new List<int>();
for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        int left = CountScenicScore(j, i, -1, 0, input[i][j]);
        int right = CountScenicScore(j, i, 1, 0, input[i][j]);
        int up = CountScenicScore(j, i, 0, -1, input[i][j]);
        int down = CountScenicScore(j, i, 0, 1, input[i][j]);
        scenicScores.Add(left * right * up * down);
    }
}
Console.WriteLine("Part 2: "+scenicScores.Max());
bool CountVisible(int x, int y, int xd, int yd, char startValue)
{
    if (x == 0 || x == input.Length - 1 || y == 0 || y == input.Length - 1)
        return true;
    if (startValue <= input[y + yd][x + xd])
        return false;

    return CountVisible(x + xd, y + yd, xd, yd, startValue);
}
int CountScenicScore(int x, int y, int xd, int yd, char startValue)
{
    if (x == 0 || x == input.Length - 1 || y == 0 || y == input.Length - 1)
        return 0;
    if (startValue <= input[y + yd][x + xd])
        return 1 ;

    return 1 + CountScenicScore(x + xd,y + yd,xd, yd, startValue);
}