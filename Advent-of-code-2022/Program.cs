var input = File.ReadAllText("input.txt");

// part 1
var firstSeq = input.Chunk(4)
    .ToArray()
    .Select((str, index) => new { str, index })
    .First(x=>x.str.Distinct().Count() == 4);
Console.WriteLine(firstSeq.index * 4+1);
