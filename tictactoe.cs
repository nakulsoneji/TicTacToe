using System;

class tictactoe
{
  private static int[] board = new int[9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
  private static int playerTurn;
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
  }
  private static void guess(int[] array)
  {
    Console.WriteLine($"type the row you want to place a {playerTurn} on");
    string row = Console.ReadLine()!;
    while (Int32.TryParse(row, out int res) != true)
    {
      Console.WriteLine("invalid input, try again");
      Console.WriteLine($"type the row you want to place a {playerTurn} on");
      row = Console.ReadLine()!;
    }
    Console.WriteLine($"type the column you want to place a {playerTurn} on");
    string column = Console.ReadLine()!;
    while (Int32.TryParse(column, out int res) != true)
    {
      Console.WriteLine("invalid input, try again");
      Console.WriteLine($"type the column you want to place a {playerTurn} on");
      column = Console.ReadLine()!;
    }
    int index = 3 * (Int32.Parse(row) - 1) + (Int32.Parse(column) - 1);
    while (array[index] == 1 || array[index] == 2)
    {
      Console.WriteLine("that space is already occupied, try again");
      Console.WriteLine($"type the row you want to place a {playerTurn} on");
      row = Console.ReadLine()!;
      Console.WriteLine($"type the column you want to place a {playerTurn} on");
      column = Console.ReadLine()!;
      index = 3 * (Int32.Parse(row) - 1) + (Int32.Parse(column) - 1);
    }
    
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
