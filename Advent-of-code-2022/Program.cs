
//  Init
var input = File.ReadAllLines("input.txt");
Node root = new Node();
root.children = new List<Node>();
root.type = "dir";
root.name = "/";
root.size = 0;
Stack<Node> cwd = new Stack<Node>();
cwd.Push(root);
int sum = 0;

//  Parsing Input
ParseInput(ref root);

// Counting Sizes in Tree
CountSize(root, 100000, ref sum);

//  Result of Part 1
Console.WriteLine("Part 1: " + sum);




//  Declarations and Definitions
int CountSize(Node root, int searchSize, ref int sum)
{
    int size = 0;
    
    foreach(Node node in root.children)
    {
        if (node.type == "file")
            size += node.size;
        else if (node.type == "dir")
        {
            size += CountSize(node, searchSize, ref sum);
        }
    }

    root.size= size;
    if (size <= searchSize)
        sum += size;
    return size;
}

void ParseInput(ref Node root)
{ 
    for (int i = 1;i < input.Length; i++)
    {
        Node node;
        var command = input[i];
        if(command.StartsWith("$ ls"))
        {
            continue;
        }
        else if (command.StartsWith("$ cd"))
        {
            var folderName = command.Split(' ')[2];
            if (folderName == "..")
            {
                cwd.Pop();
                continue;
            }
            else if (folderName =="/")
            {
                cwd = new Stack<Node>();
                cwd.Push(root);
                continue;
            }
            var currentNode = cwd.Peek();
            cwd.Push(currentNode.children.FirstOrDefault(x => x.name == folderName));
        }
        else if (command.StartsWith("dir"))
        {
            node = new Node {
                children = new List<Node>(),
                type = "dir",
                name = command.Split(" ")[1],
                size = 0
            };
            cwd.Peek().children.Add(node);
        } 
        else
        {
            node = new Node
            {
                children = new List<Node>(),
                type = "file",
                name = command.Split(" ")[1],
                size = int.Parse(command.Split(" ")[0])
            };
            cwd.Peek().children.Add(node);
        }

    }
    cwd.Clear();
}

struct Node
{
    public List<Node> children;
    public string type { get; set; }
    public string name { get; set; }
    public int size { get; set; }
}