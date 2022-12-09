var input = File.ReadAllLines("input.txt");
string[] inputTest =
{
    "R 4",
    "U 4",
    "L 3",
    "D 1",
    "R 4",
    "D 1",
    "L 5",
    "R 2"
};

var add = ((int, int) a, (int, int) b) => (a.Item1 + b.Item1, a.Item2 + b.Item2); 
var dist = ((int, int) a, (int, int) b) => (a.Item1 - b.Item1, a.Item2 - b.Item2); 


(int x,int y)[] knots = new (int,int)[2];
knots.Initialize();

List<(int, int)> posT = new List<(int, int)>();
posT.Add(knots[0]);

foreach(var com in inputTest)
{
    for(int i =0; i < int.Parse(com.Split(" ")[1]);i++)
    {
        (int, int) dir = com.First() switch
        {
            'U' => (0, 1),
            'D' => (0, -1),
            'R' => (1, 0),
            _ => (-1, 0)

        };
        knots[0] = add(knots[1],dir);
        var dis = dist(knots[0], knots[1]);
        if(Math.Abs(dis.Item1)>1 || Math.Abs(dis.Item2) > 1)
        {
            knots[1] = add(knots[0], (Math.Sign(dis.Item1),Math.Sign(dis.Item2)));
        }
        posT.Add(knots[1]);
    }
}





Console.WriteLine("Part 1: "+posT.Distinct().Count());
