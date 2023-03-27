const string INPUT_FOLDER = "input";
const string INPUT_FILE = "input.txt";
var path = Path.Combine(INPUT_FOLDER, INPUT_FILE);

IEnumerable<string> lines = File.ReadLines(path);
var linesArray = lines as string[] ?? lines.ToArray();

// Initialize stacks list
List<List<char>> stacks = new();
for (int i = 0; i < 9; i++)
{
   List<char> stack = new();
   stacks.Add(stack);
}

// Read stacks input
for (int i = 0; i < 9; i++)
{
   var column = i * 4 + 1;
   for (int j = 7; j >= 0; j--)
   {
      var character = linesArray[j][column];
      if (character != ' ')
      {
         stacks[i].Add(character);
      }
   }
}

// Read move input
for (int i = 10; i < linesArray.Length; i++)
{
   var move = linesArray[i].Split(' ');
   var amount = int.Parse(move[1]);
   var from = int.Parse(move[3]) - 1;
   var to = int.Parse(move[5]) - 1;

   for (int j = 0; j < amount; j++)
   {
      var item = stacks[from][stacks[from].Count - 1];
      stacks[from].RemoveAt(stacks[from].Count - 1);
      stacks[to].Add(item);
   }
}

//output result
string output = "";
foreach (var stack in stacks)
{
   output += stack[^1];
}
Console.WriteLine(output);
