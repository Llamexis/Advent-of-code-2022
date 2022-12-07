
using System.Xml.Linq;

var input = File.ReadAllLines("input.txt");
Node root = new Node();
root.children = new List<Node>();
root.type = "dir";
root.name = "/";
root.size = 0;
Stack<Node> cwd = new Stack<Node>();
cwd.Push(root);
ParseInput(ref root);

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