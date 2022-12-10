var input = File.ReadAllText("input.txt")
    .Split(' ','\r','\n').
    Where(x=>x!="").ToArray();

int cycle = 0;
int register = 1;
int signalStrength = 0;
string prevInstruction = "";

foreach(var instruction in input)
{
    cycle++;
    if(cycle == 20 || cycle == 60 || cycle == 100 
        || cycle == 140 || cycle == 180 || cycle == 220)
    {
        signalStrength += cycle * register;
    }
    if(instruction == "addx" && prevInstruction != "addx")
    {
        prevInstruction = instruction;
    }
    else if (instruction == "noop")
    {
        prevInstruction = instruction;
    }
    else if(prevInstruction == "addx")
    {
        register += int.Parse(instruction);
        prevInstruction = instruction;
    }
    if (cycle == 240) break;
}
Console.WriteLine("Part 1: " + signalStrength);
