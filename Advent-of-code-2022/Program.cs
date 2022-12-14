using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

var input = File.ReadAllLines("input.txt");
var lines = new List<List<(int x, int y)>>();
foreach(var line in input)
{
    var tmp = line.Split("->").ToList().Select(x=> {
        var t = x.Split(',');
        return (int.Parse(t[0]), int.Parse(t[1]));
    }).ToList();
    lines.Add(tmp);
}
int maxY = lines.Max(a => a.Max(x => x.y));
var grid = Fill(input, lines,false);

var numOfSand = HateSandItsCoughAndRoughAndIrritating(grid,false);
Console.WriteLine("Part 1: " + numOfSand);
grid = Fill(input, lines,true);
numOfSand = HateSandItsCoughAndRoughAndIrritating(grid,true);
for (int i = 0; i < grid.GetLength(0); i++)
{
    for (int j = 450; j < grid.GetLength(1) - 400; j++)
    {
        Console.Write(grid[i, j]);
    }
    Console.WriteLine();
}
Console.WriteLine($"Part 2: {numOfSand}");

char[,] Fill(string[] input, List<List<(int x, int y)>> lines,bool IsFloor)
{
    int maxY = lines.Max(a => a.Max(x => x.y));
    var grid = new char[maxY + 3, 1000];

    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
            grid[i, j] = '.';
    }
    foreach (var line in lines)
    {

        for (int i = 0; i < line.Count - 1; i++)
        {
            var cord1 = line[i];
            var cord2 = line[i + 1];
            grid[cord1.y, cord1.x] = '#';
            while (cord1 != cord2)
            {
                if (cord1.x > cord2.x)
                    cord1 = (cord1.x - 1, cord1.y);
                else if (cord1.x < cord2.x)
                    cord1 = (cord1.x + 1, cord1.y);
                else if (cord1.y < cord2.y)
                    cord1 = (cord1.x, cord1.y + 1);
                else if (cord1.y > cord2.y)
                    cord1 = (cord1.x, cord1.y - 1);
                grid[cord1.y, cord1.x] = '#';
            }
        }
    }
    grid[0, 500] = '+';
    if(IsFloor)
    {
        for(int x = 0; x < grid.GetLength(1);x++)
            grid[maxY+2, x] = '#';
    }
    return grid;
}
int HateSandItsCoughAndRoughAndIrritating(char[,] grid,bool IsFloor)
{
    bool IsVoid = false;
    int numOfSand = 0;
    while (!IsVoid)
    {
        int posX = 500;
        int posY = 0;
        while (true)
        {
            if (posY > maxY && !IsFloor)
            {
                IsVoid = true;
                break;
            }
            if (grid[posY + 1, posX] != '.')
            {

                if (grid[posY + 1, posX - 1] == '.')
                {
                    posY++;
                    posX--;
                }
                else if (grid[posY + 1, posX + 1] == '.')
                {
                    posX++;
                    posY++;
                }
                else
                {
                    grid[posY, posX] = 'o';
                    numOfSand++;
                    if (posX == 500 && posY == 0)
                        return numOfSand;
                    posX = 500;
                    posY = 0;
                    break;
                }
            }
            else
                posY++;
        }
    }
    return numOfSand;
}