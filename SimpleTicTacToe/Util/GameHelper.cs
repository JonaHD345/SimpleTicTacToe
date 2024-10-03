using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicTacToe.Util
{
  public class GameHelper
  {
    public static void PrintPlayboard(Dictionary<int, int> moves)
    {
      string playboard = string.Empty;
      int counter = 1;

      foreach (int field in moves.Keys)
      {
        playboard += $"[{(moves[field] == -1 ? " " : (moves[field] == 1 ? "X" : "0"))}]{(counter % 3 == 0 ? Environment.NewLine : "")}";
        counter++;
      }
      Console.WriteLine(playboard);
    }

    public static bool CheckWinner(List<int[]> possibleSolutions, Dictionary<int, int> moves)
    {
      bool winner = false;

      foreach (int[] possibleSolution in possibleSolutions)
      {
        if (moves[possibleSolution[0]] == -1) { continue; }
        if (moves[possibleSolution[0]] == moves[possibleSolution[1]] && moves[possibleSolution[1]] == moves[possibleSolution[2]])
        {
          winner = true;
          break;
        }
      }
      return winner;
    }

    public static bool IsCorrectInput(string input, Dictionary<int, int> moves)
    {
      return  int.TryParse(input, out _) &&
        int.Parse(input) > 0 && int.Parse(input) < 10 &&
        moves[int.Parse(input)] == -1;
    }
  }
}
