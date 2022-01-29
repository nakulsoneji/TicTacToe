using System;

class tictactoe
{
  private static int[] board = new int[9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
  private static int playerTurn = 1;
  private static void Main(string[] args) 
  {
    printBoard(board);
    while (CheckWin(board) == 0)
    {
      guess(board);
      if (CheckWin(board) == 1 || CheckWin(board) == 2)
      {
        Console.WriteLine(CheckWin(board) + " wins!");
      }
    }
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
    board = array;
  }
  private static void guess(int[] array)
  {
    Console.WriteLine($"type the row you want to place a {playerTurn} on");
    int row = Int32.Parse(Console.ReadLine()!) - 1;
    Console.WriteLine($"type the column you want to place a {playerTurn} on");
    int column = Int32.Parse(Console.ReadLine()!) - 1;
    int index = 3 * row + column;
    array[index] = playerTurn;
    printBoard(array);
    
    switch (playerTurn)
    {
      case 1:
        playerTurn = 2;
        break;
      case 2:
        playerTurn = 1;   
        break;
    }
  }
  private static int CheckWin(int[] array)
  {
    int win = 0;
    for (int r = 0; r < 7; r += 3)
    {
      if (array[r] == array[r + 1]  && array[r + 1] == array[r + 2] && array[r] != 0)
      {
        win = array[r];
        return win;
      }
    }
    for (int r = 0; r < 3; r++)
    {
      if (array[r] == array[r + 3] && array[r + 3] == array[r + 6] && array[r] != 0)
      {
        win = array[r];
        return win;
      }
    }

    for (int r = 0; r < 3; r += 2)
    {
      if (r == 0)
      {
        if (array[r] == array[r + 4] && array[r + 4]  == array [r + 8] && array[r] != 0)
        {
          win = array[r];
          return win;
        }
      }
      else if (r == 2)
      {
        if (array[r]  == array[r + 2] && array[r + 2]  == array [r + 4] && array[r] != 0)
        {
          win = array[r];
          return win;
        }
      }  
    }
  return win;
  }
}
