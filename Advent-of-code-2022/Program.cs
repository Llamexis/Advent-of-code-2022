using Microsoft.Win32;
using System.Runtime.CompilerServices;

Processor processor = new PartOneProcessor("input.txt");
processor.action();

Console.WriteLine("Part 1: " + processor.signalStrength);
processor = new PartTwoProcessor("input.txt");
Console.WriteLine("Part 2:");
processor.action();

abstract class Processor
{
    public int cycle = 0;
    public int register = 1;
    public int signalStrength = 0;
    public string prevInstruction = "";
    public string[] input;
    
    public Processor(string path)
    {
        input = File.ReadAllText(path)
            .Split(' ', '\r', '\n').
            Where(x => x != "").ToArray();
    }

    public abstract void action();
    
}
class PartOneProcessor : Processor
{
    public PartOneProcessor(string path) : base(path)
    {

    }
    public override void action()
    {
        foreach (var instruction in input)
        {
            cycle++;
            if (cycle == 20 || cycle == 60 || cycle == 100
                || cycle == 140 || cycle == 180 || cycle == 220)
            {
                signalStrength += cycle * register;
            }
            if (instruction == "addx" && prevInstruction != "addx")
            {
                prevInstruction = instruction;
            }
            else if (instruction == "noop")
            {
                prevInstruction = instruction;
            }
            else if (prevInstruction == "addx")
            {
                register += int.Parse(instruction);
                prevInstruction = instruction;
            }
            if (cycle == 240) break;
        }
    }
}
class PartTwoProcessor : Processor
{
    public PartTwoProcessor(string path) : base(path)
    {

    }
    public override void action()
    {
        int pixelPos = 0;
        foreach (var instruction in input)
        {
            cycle++;
            
            if (pixelPos >= register - 1 && pixelPos <= register + 1)
                Console.Write('#');
            else
                Console.Write('.');
            pixelPos++;
            if (pixelPos % 40 == 0)
            {
                Console.WriteLine();
                pixelPos = 0;
            }
            if (cycle == 20 || cycle == 60 || cycle == 100
                || cycle == 140 || cycle == 180 || cycle == 220)
            {
                signalStrength += cycle * register;
            }
            if (instruction == "addx" && prevInstruction != "addx")
            {
                prevInstruction = instruction;
            }
            else if (instruction == "noop")
            {
                prevInstruction = instruction;
            }
            else if (prevInstruction == "addx")
            {
                register += int.Parse(instruction);
                prevInstruction = instruction;
            }
            
        }
    }
}