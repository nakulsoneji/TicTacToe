using System;

class tictactoe
{
  private static int[] board = new int[9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
  private static int playerTurn = 1;
  private static void Main(string[] args) 
  {
    printBoard(board);
    guess(board, playerTurn);
    guess(board, playerTurn);
    guess(board, playerTurn);
    guess(board, playerTurn);
  }
  private static void printBoard(int[] array)
  {
    for (var i = 0; i < 9; i++)
    {
      if ((i + 1) % 3 == 0)
      {
        Console.Write(array[i] + "\n");
      }
      else
      {
        Console.Write(array[i] + "  ");
      }
    }
  }
  private static void guess(int[] array, int turn)
  {
    Console.WriteLine($"type the row you want to place a {turn} on");
    int row = Int32.Parse(Console.ReadLine()!) - 1;
    Console.WriteLine($"type the column you want to place a {turn} on");
    int column = Int32.Parse(Console.ReadLine()!) - 1;
    int index = 3 * row + column;
    array[index] = turn;
    printBoard(array);
    Console.WriteLine(turn);
    switch (turn)
    {
      case 1:
        turn = 2;
        break;
      case 2:
        turn = 1;
        break;
    }
  }
}
