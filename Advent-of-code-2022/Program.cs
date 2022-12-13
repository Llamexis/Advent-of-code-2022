using System.Collections.Immutable;
using System.Text.Json.Nodes;

int Compare(JsonNode a, JsonNode b)
{
    if (a is JsonValue && b is JsonValue)
        return (int)a - (int)b;
    var aa = a as JsonArray ?? new JsonArray((int)a);
    var bb = b as JsonArray ?? new JsonArray((int)b);
    return Enumerable.Zip(aa, bb)
        .Select(x => Compare(x.First, x.Second))
        .FirstOrDefault(c => c != 0, aa.Count - bb.Count );
}

var input = File.ReadAllText("input.txt");
var parse = from x in input.Split("\r\n")
            where !string.IsNullOrEmpty(x)
            select JsonNode.Parse(x);
var res1 = parse.Chunk(2)
    .Select((pair, idx) => Compare(pair[0], pair[1]) < 0 ? idx+1 : 0)
    .Sum();

var divider = (from x in "[[2]]\n[[6]]".Split('\n')
              select JsonNode.Parse(x)).ToList();

var tmp = parse.Concat(divider).ToList();
tmp.Sort(Compare);
var res2 = (tmp.IndexOf(divider[0]) + 1) * (tmp.IndexOf(divider[1]) + 1); 
Console.WriteLine("Part 1: "+res1);
Console.WriteLine("Part 2: "+res2);