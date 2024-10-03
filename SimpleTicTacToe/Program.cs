using SimpleTicTacToe.Util;

Console.WriteLine("   _____ _                 _   _______ _   _______      _______         \r\n  / ____(_)               | | |__   __(_) |__   __|    |__   __|        \r\n | (___  _ _ __ ___  _ __ | | ___| |   _  ___| | __ _  ___| | ___   ___ \r\n  \\___ \\| | '_ ` _ \\| '_ \\| |/ _ \\ |  | |/ __| |/ _` |/ __| |/ _ \\ / _ \\\r\n  ____) | | | | | | | |_) | |  __/ |  | | (__| | (_| | (__| | (_) |  __/\r\n |_____/|_|_| |_| |_| .__/|_|\\___|_|  |_|\\___|_|\\__,_|\\___|_|\\___/ \\___|\r\n                    | |                                                 \r\n                    |_|                                                 ");
Console.WriteLine("Made by Jona");
Console.WriteLine("");
Console.WriteLine("Player 1: X");
Console.WriteLine("Player 2: O");
Console.WriteLine("");
Console.WriteLine("Press any key, to start the game...");
Console.ReadKey();



List<int[]> possibleSolutions = new List<int[]>() { new int[]{ 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 }, new int[] { 3, 6, 9 }, new int[] { 1, 5, 9 }, new int[] { 3, 5, 7 } };
Dictionary<int, int> moves = new Dictionary<int, int>() { { 1, -1 }, { 2, -1 }, { 3, -1 }, { 4, -1 }, { 5, -1 }, { 6, -1 }, { 7, -1 }, { 8, -1 }, { 9, -1 }, };

bool isWinnerExisting = false;
bool isCurrentPlayer1 = true;
int moveCounter = 0;


Console.WriteLine("");
Console.WriteLine("Overview field numbers:\n[1][2][3]\n[4][5][6]\n[7][8][9]");
Console.WriteLine("");
while (!isWinnerExisting)
{
  if (moveCounter == 9)
  {
    Console.WriteLine("");
    Console.WriteLine("Draw. Nobody has won!");
    Console.WriteLine("");
    break;
  }

  Console.WriteLine($"Player {(isCurrentPlayer1 ? 1 : 2)}:");
  
  bool correctInput = false;

  while (!correctInput)
  {
    Console.WriteLine("Enter field number:");
    string input = Console.ReadLine();

    correctInput = GameHelper.IsCorrectInput(input, moves);
    if (correctInput)
    {
      moves[int.Parse(input)] = isCurrentPlayer1 ? 1 : 2;
    }
  }
  GameHelper.PrintPlayboard(moves);

  isWinnerExisting = GameHelper.CheckWinner(possibleSolutions, moves);
  if (isWinnerExisting)
  {
    Console.WriteLine("");
    Console.WriteLine($"Player {(isCurrentPlayer1 ? 1 : 2)} has won! Congratulations!");
    Console.WriteLine("");
  }

  isCurrentPlayer1 = !isCurrentPlayer1;
  moveCounter++;
}

Console.WriteLine("");
Console.WriteLine("");
Console.Write("Game is over. Press any key to exit the game.");
Console.ReadKey();