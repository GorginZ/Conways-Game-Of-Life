using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System.Text;

namespace ConwaysGameOfLife
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.BackgroundColor = ConsoleColor.DarkGray;
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Clear();
      var userInput = new UserInput();
      int rowDimension;
      int columnDimension;
      List<RowColumn> coordinateList;

      var introString = "\nWelcome to Conways Game of Life.\n \nJohn Horton Conway has contributed immensely to many fields of mathematical theory and his Game of Life is one of his most famous and fun contributions which presents fun and interesting challenges for programmers and captures interest beyond those already enaged in mathematical theory. \n\nJohn Conway passed away in April 2020 just three days after developing COVID19 symptoms. This is a huge loss to the mathematical community and to the world more broadly. RIP John Conway. \n\n In the Game of Life we set a world of cells and apply a series of rules to them in each 'tick', the tick represents the discrete moment in time where the state of the world changes. This tick changes the state, living or dead, of all of the cells.\n\nthe rules: \n\n1. Any live cell with fewer than two live neighbours dies, as if by underpopulation. \n2. Any live cell with two or three live neighbours lives on to the next generation. \n3. Any live cell with more than three live neighbours dies, as if by overpopulation. \n4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction. \n\nYou will set dimensions of the world and the initial state of the cells by selecting coordinates and watch how they behave.";
      Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (introString.Length / 2)) + "}", introString));


      var rowPrompt = "\nHow many rows in the world?";
      Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (rowPrompt.Length / 2)) + "}", rowPrompt));

      rowDimension = GetValidDimensions();
      var columnPrompt = "\nHow many columns in the world?";
      Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (columnPrompt.Length / 2)) + "}", columnPrompt));

      columnDimension = GetValidDimensions();
      var world = new World(rowDimension, columnDimension);

      var grid = VisualizeGridInConsole(world.GetGrid());
      Console.WriteLine(grid);

      Console.WriteLine("innoculate world with some live cells");
      Console.WriteLine("input your coordinates in the following format: 0,0 0,1 0,2 4,4 2,2 ");

      coordinateList = GetValidIndexList();
      world.PopulateGrid(coordinateList);

      while (1 < 100)
      {
        Console.Clear();
        // Console.WriteLine(world.PrintWorld());
        var heading = "CONWAYS GAME OF LIFE";
        var stringWorld = VisualizeGridInConsole(world.GetGrid());

        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (heading.Length / 2)) + "}", heading));
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth) + (stringWorld.Length)) + "}", stringWorld));

        Thread.Sleep(1000);
        Console.Beep();
        world.Tick();
      }
    }

    private static string VisualizeGridInConsole(Grid<CellState> grid)
    {
      var seeSB = new StringBuilder();

      for (int i = 0; i < grid.RowCount; i++)
      {
        for (int j = 0; j < grid.ColumnCount; j++)
        {
          if (grid[i, j] == CellState.Alive)
          {
            seeSB.Append("X");
          }
          else
          {
            seeSB.Append(" ");
          }
        }
        seeSB.Append("\n");
      }
      return seeSB.ToString();

    }

    private static List<RowColumn> GetValidIndexList()
    {
      var input = Console.ReadLine();
      List<RowColumn> coordinateList;

      while (!InputParser.TryParseInputIndexes(input, out coordinateList))
      {
        Console.WriteLine("input your coordinates in the following format: 0,0 0,1 0,2 4,4 2,2 ");
        input = Console.ReadLine();

      }
      return coordinateList;
    }

    private static int GetValidDimensions()
    {
      var input = Console.ReadLine();
      int dimension;
      int.TryParse(input, out dimension);

      while (!ValidDimension(dimension))
      {
        Console.WriteLine("please enter a number between 3 and 100 ");
        input = Console.ReadLine();
        int.TryParse(input, out dimension);
      }
      return dimension;
    }

    private static bool ValidDimension(int dimension)
    {
      if (dimension > 2 && dimension < 41)
      {
        return true;
      }
      else
      {
        return false;
      }
    }


  }
}
