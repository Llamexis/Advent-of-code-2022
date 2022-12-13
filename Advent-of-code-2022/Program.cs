﻿using System.Text.Json.Nodes;

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
Console.WriteLine("Part 1: "+res1);