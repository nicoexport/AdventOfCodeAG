const string INPUT_FOLDER = "input";
const string INPUT_FILE = "input.txt";
string path = Path.Combine(INPUT_FOLDER, INPUT_FILE);

IEnumerable<string> lines = File.ReadLines(path);
var linesArray = lines as string[] ?? lines.ToArray();

int fullyContainedAssignments = 0;
int partiallyContainedAssignments = 0; 

foreach (var line in linesArray)
{
   var pair = line.Split(',');

   Console.WriteLine(pair[0]);
   Console.WriteLine(pair[1]);
   var first = pair[0].Split('-');
   var second = pair[1].Split('-');

   var firstLower = (int.Parse(first[0]));
   var firstUpper = (int.Parse(first[1]));
   var secondLower = (int.Parse(second[0]));
   var secondUpper = (int.Parse(second[1]));
   
   if (firstLower >= secondLower && firstUpper <= secondUpper ||
        firstLower <= secondLower && firstUpper >= secondUpper)
   {
      fullyContainedAssignments += 1;
   }

   if (secondLower <= firstLower && firstLower <= secondUpper || secondLower <= firstUpper && firstUpper <= secondUpper
       || firstLower <= secondLower && secondLower <= firstUpper || firstLower <= secondUpper && secondUpper <= firstUpper)
   {
      partiallyContainedAssignments += 1;
   }
}

Console.WriteLine(fullyContainedAssignments);
Console.WriteLine(partiallyContainedAssignments);
