using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

var monkes = InputParser("input.txt");
long mod = 1;
foreach (Monke monke in monkes)
    mod *= monke.divider;
monkePlay(ref monkes, 20, 3,mod);


monkes.Sort(delegate(Monke x, Monke y) 
{
    if (x.numberOfInspects > y.numberOfInspects)
        return 0;
    else
        return 1;
});

monkes.Sort((Monke a,Monke b) => a.numberOfInspects.CompareTo(b.numberOfInspects));
var res = monkes.TakeLast(2).ToArray();
Console.WriteLine("Part 1: "+(res[0].numberOfInspects * res[1].numberOfInspects));

monkes = InputParser("input.txt");

monkePlay(ref monkes, 10000,1,mod);

monkes.Sort(delegate (Monke x, Monke y)
{
    if (x.numberOfInspects > y.numberOfInspects)
        return 0;
    else
        return 1;
});
monkes.Sort((Monke a, Monke b) => a.numberOfInspects.CompareTo(b.numberOfInspects));
res = monkes.TakeLast(2).ToArray();
Console.WriteLine("Part 2: " + (res[0].numberOfInspects * res[1].numberOfInspects));
List<Monke> InputParser(string path)
{
    var result = new List<Monke>();
    var input = File.ReadAllLines(path);
    for(int i = 0; i < input.Length;i++)
    {
        if (!input[i].StartsWith("Monkey"))
            continue;

        var regex = new Regex("\\d+");
        var items = regex.Matches(input[i+1]).Select(x=>long.Parse(x.Value)).ToList();
        var divider = int.Parse(regex.Match(input[i + 3]).Value);
        var True = int.Parse(regex.Match(input[i + 4]).Value);
        var False = int.Parse(regex.Match(input[i + 5]).Value);
        regex = new Regex("(new = old [+*] )(\\d+|old)");
        var op = regex.Match(input[i+2]).Value;
        var m = new Monke {
            items = items,
            operation = op,
            divider = divider,
            True = True,
            False = False
        };
        result.Add(m);
    }
    return result;
}
void monkePlay(ref List<Monke> monkeList, int ROUNDS, int div, long mod)
{
    for (int round = 0; round < ROUNDS; round++)
    {
        for (int index = 0; index < monkes.Count(); index++)
        {

            if (monkes[index].items.Count() == 0)
                continue;
            string op = monkes[index].operation.Split(" ")[3];
            foreach (var item in monkes[index].items)
            {
                long tmp;
                switch (op)
                {
                    case "+":
                        {
                            tmp = item + int.Parse(monkes[index].operation.Split(" ")[4]);
                            break;
                        }
                    case "*":
                        {
                            if (monkes[index].operation.Split(" ")[4] == "old")
                                tmp = item * item;
                            else
                                tmp = item * int.Parse(monkes[index].operation.Split(" ")[4]);
                            break;
                        }
                    default:
                        throw new Exception("Oh no");
                }

                tmp = tmp / div % mod;
                if (tmp % monkes[index].divider == 0)
                    monkes[monkes[index].True].items.Add(tmp);
                else
                    monkes[monkes[index].False].items.Add(tmp);
                monkes[index].numberOfInspects++;
            }
            monkes[index].items.Clear();
        }
    }
}



class Monke
{
    public List<long> items { get; set; }
    public string? operation { get; set; }
    public int divider { get; set; }
    public int True { get; set; }
    public int False { get; set; }
    public long numberOfInspects = 0;
    public Monke() 
    { 
        items = new List<long>();
    }
}