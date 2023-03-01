const string INPUT_FOLDER = "input";
const string INPUT_FILE = "input.txt";
string path = Path.Combine(INPUT_FOLDER, INPUT_FILE);

IEnumerable<string> lines = File.ReadLines(path);
var linesArray = lines as string[] ?? lines.ToArray();

int prioritySum = 0;

const string priorityString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

foreach (var str in linesArray)
{
   int halfLength = str.Length / 2;

   string firstHalf = str[..halfLength];
   string secondHalf = str[halfLength..];

   IEnumerable<char> duplicates = firstHalf.Intersect(secondHalf);

   foreach (var duplicate in duplicates)
   {
      prioritySum += (priorityString.IndexOf(duplicate) + 1);
   }
}

Console.WriteLine(prioritySum);
Console.WriteLine(priorityString.IndexOf("Z"));
