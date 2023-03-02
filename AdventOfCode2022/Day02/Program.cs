const string INPUT_FOLDER = "input";
const string INPUT_FILE = "input02.txt";
var path = Path.Combine(INPUT_FOLDER, INPUT_FILE);

IEnumerable<string> lines = File.ReadLines(path);
IEnumerable<string> linesArray = lines as string[] ?? lines.ToArray();

var score = 0;

foreach (var line in linesArray)
{
   score += CalcPickScore(line, Strategy.PartOne);
   score += CalcResultScore(line, Strategy.PartOne);
}

Console.WriteLine("Part One. " + score);

score = 0;

foreach (var line in linesArray)
{
   score += CalcPickScore(line, Strategy.PartTwo);
   score += CalcResultScore(line, Strategy.PartTwo);
}

Console.WriteLine("Part Two. " + score);


const int SCORE_ROCK = 1;
const int SCORE_PAPER = 2;
const int SCORE_SCISSORS = 3;

int CalcPickScore(string line, Strategy strat)
{
   var letters = line.Split(' ');
   return strat switch
   {
      Strategy.PartOne => letters[1] switch
      {
         "X" => SCORE_ROCK,
         "Y" => SCORE_PAPER,
         "Z" => SCORE_SCISSORS,
         _ => throw new NotImplementedException()
      },
      Strategy.PartTwo => line switch
      {
         "A X" => SCORE_SCISSORS,
         "A Y" => SCORE_ROCK,
         "A Z" => SCORE_PAPER,

         "B X" => SCORE_ROCK,
         "B Y" => SCORE_PAPER,
         "B Z" => SCORE_SCISSORS,

         "C X" => SCORE_PAPER,
         "C Y" => SCORE_SCISSORS,
         "C Z" => SCORE_ROCK,
         _ => throw new NotImplementedException()
      },
      _ => throw new NotImplementedException()
   };
}

const int SCORE_WIN = 6;
const int SCORE_DRAW = 3;
const int SCORE_LOSS = 0;

int CalcResultScore(string line, Strategy strat)
{
   var letters = line.Split(' ');
   return strat switch
   {
      Strategy.PartOne => line switch
      {
         "A X" => SCORE_DRAW,
         "A Y" => SCORE_WIN,
         "A Z" => SCORE_LOSS,

         "B X" => SCORE_LOSS,
         "B Y" => SCORE_DRAW,
         "B Z" => SCORE_WIN,

         "C X" => SCORE_WIN,
         "C Y" => SCORE_LOSS,
         "C Z" => SCORE_DRAW,

         _ => throw new NotImplementedException()
      },
      Strategy.PartTwo => letters[1] switch
      {
         "X" => SCORE_LOSS,
         "Y" => SCORE_DRAW,
         "Z" => SCORE_WIN,
         _ => throw new NotImplementedException()
      },
      _ => throw new NotImplementedException()
   };
}

internal enum Strategy
{
   PartOne,
   PartTwo
}
