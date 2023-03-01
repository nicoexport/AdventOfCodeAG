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

   var duplicates = firstHalf.Intersect(secondHalf);

   foreach (var duplicate in duplicates)
   {
      prioritySum += priorityString.IndexOf(duplicate) + 1;
   }
}

Console.WriteLine("Sum of priority of duplicates:");
Console.WriteLine(prioritySum);

int badgeSum = 0;
int chunkSize = 3;
var chunks = Enumerable.Range(0, linesArray.Length / chunkSize)
   .Select(i => linesArray.Skip(i * chunkSize).Take(chunkSize).ToArray())
   .ToArray();

foreach (var chunk in chunks)
{
   var str0 = chunk[0];
   var str1 = chunk[1];
   var str2 = chunk[2];

   IEnumerable<char> commonChars = str0.Intersect(str1).Intersect(str2);

   foreach (var character in commonChars)
   {
      badgeSum += priorityString.IndexOf(character) + 1;
   }
}

Console.WriteLine("Sum of priorities of badges:");
Console.WriteLine(badgeSum);


