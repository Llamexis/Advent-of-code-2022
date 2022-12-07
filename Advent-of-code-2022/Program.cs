
//  Init
var input = File.ReadAllLines("input.txt");
Node root = new Node();
root.children = new List<Node>();
root.type = "dir";
root.name = "/";
root.size = 0;
Stack<Node> cwd = new Stack<Node>();
var list = new List<int>();
cwd.Push(root);
int sum = 0;
int limit;
//  Parsing Input
ParseInput(ref root);

// Counting Sizes in Tree
root.size = CountSize(root, 100000, ref sum);

limit = 30000000 - (70000000 - root.size);

//  Result of Part 1
Console.WriteLine("Part 1: " + sum);

toArray(root);


//  Result of Part 2
Console.WriteLine("Part 2: " + list.Min());


//  Declarations and Definitions

void toArray(Node root)
{
    for (int i = 0; i < root.children.Count; i++)
    {
        if (root.children[i].type == "dir" && limit <= root.children[i].size)
            list.Add(root.children[i].size);
        toArray(root.children[i]);
        
    }
}
int CountSize(Node root, int searchSize, ref int sum) // DFS
{
    int size = 0;
    for(int i=0; i < root.children.Count; i++)
    {
        Node node = root.children[i];
        if (node.type == "file")
            root.size += node.size;
        else if (node.type == "dir")
        {
            node.size = CountSize(node,searchSize,ref sum);
            root.size += node.size;
        }
        root.children[i] = node;
    }
    size = root.size;
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